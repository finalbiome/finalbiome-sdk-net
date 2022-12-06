namespace FinalBiome.Sdk.Test;

using FinalBiome.Api;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;
using FinalBiome.Sdk.Test;
using FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet;
using FinalBiome.Api.Extensions;

using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.SpCore.Crypto;
using FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor;
using FinalBiome.Api.Types.SpCore;
using FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId;
using FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance;
using System.Numerics;
using FinalBiome.Api.Types.PalletSupport.Characteristics;
using FinalBiome.Api.Types.PalletSupport.Characteristics.Purchased;
using FinalBiome.Api.Types.PalletSupport;

/// <summary>
/// Manipulation with network state for tests.
/// </summary>
static public class NetworkHelpers
{
    /// <summary>
    /// Exec BuyNfaMechanics in the Eve game by Dave of Nfa 1 and offer 0
    /// </summary>
    static public async Task<(NfaClassId classId, NfaInstanceId instanceId)> ExecBuyNfaMechanic()
    {
        Client api = await Client.New();
        PairSigner signer = new(AccountKeyring.Dave());

        NonFungibleClassId classId = new();
        classId.Init(1);
        U32 offerId = U32.From(0);

        var callTx = api.Tx.Mechanics.ExecBuyNfa(classId, offerId);
        var buyNfa = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var events = await buyNfa.WaitForFinalizedSuccess();
        
        // find Issuance of nfa instance
        var ev = events.First(e => 
            e.Event.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.NonFungibleAssets && 
            ((Event)e.Event.Value2).Value == InnerEvent.Issued &&
            AddressUtils.GetAddressFrom(((EventIssued)((Event)e.Event.Value2).Value2).Owner.Bytes) == "5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy");
        if (ev is null) throw new Exception("Event NonFungibleAssets.Issued not found");
        var data = (EventIssued)((Event)ev.Event.Value2).Value2;
        return (data.ClassId, data.AssetId);
    }
    /// <summary>
    /// Create attribute. On behalf of Ferdie (manager of the Eve game)
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="attributeName"></param>
    /// <param name="attributeValue"></param>
    /// <returns></returns>
    static public async Task CreateClassAttribute(NfaClassId classId, string attributeName, string attributeValue)
    {
        Client api = await Client.New();
        PairSigner signer = new(signer: AccountKeyring.Ferdie());
        var organizationId = AccountKeyring.Eve().ToAddress();

        // construct attribute value
        Api.Types.PalletSupport.Attribute attr = new();
        BoundedVecU8 attrKey = new();
        attrKey.Init(ArrayUtils.SizePrefixedByteArray(attributeName.AsBytes()));
        Api.Types.PalletSupport.AttributeValue attrValue = new();
        BoundedVecU8 attrTextVal = new();
        attrTextVal.Init(ArrayUtils.SizePrefixedByteArray(attributeValue.AsBytes()));
        attrValue.Init(Api.Types.PalletSupport.InnerAttributeValue.Text, attrTextVal);
        attr.Decode(attrKey.Encode().Concat(attrValue.Encode()).ToArray());
        NonFungibleClassId nfaId = new();
        nfaId.Init(classId);
        CompactNonFungibleClassId compactNfaId = new();
        compactNfaId.Init(nfaId);


        var callTx = api.Tx.NonFungibleAssets.CreateAttribute(organizationId, compactNfaId, attr);
        var createAttr = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var _ = await createAttr.WaitForFinalizedSuccess();
    }
    /// <summary>
    /// Remove attribute. On behalf of Ferdie (manager of the Eve game)
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="attributeName"></param>
    /// <returns></returns>
    static public async Task RemoveClassAttribute(NfaClassId classId, string attributeName)
    {
        Client api = await Client.New();
        PairSigner signer = new(signer: AccountKeyring.Ferdie());
        var organizationId = AccountKeyring.Eve().ToAddress();

        BoundedVecU8 attrName = new();
        attrName.Init(ArrayUtils.SizePrefixedByteArray(attributeName.AsBytes()));

        NonFungibleClassId nfaId = new();
        nfaId.Init(classId);
        CompactNonFungibleClassId compactNfaId = new();
        compactNfaId.Init(nfaId);

        var callTx = api.Tx.NonFungibleAssets.RemoveAttribute(organizationId, compactNfaId, attrName);
        var createAttr = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var _ = await createAttr.WaitForFinalizedSuccess();
    }

    /// <summary>
    /// Creates nfa woth given name on behalf of Ferdie (manager of the Eve game) for Eve game
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    static public async Task<NfaClassId> CreateNfaClass(string className)
    {
        Client api = await Client.New();
        PairSigner signer = new(signer: AccountKeyring.Ferdie());
        var organizationId = AccountKeyring.Eve().ToAddress();

        VecU8 classNameU8 = new();
        classNameU8.Init(ArrayUtils.SizePrefixedByteArray(className.AsBytes()));
        var callTx = api.Tx.NonFungibleAssets.Create(organizationId, classNameU8);
        var txProgress = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var events = await txProgress.WaitForFinalizedSuccess();
        // get created class id
        foreach (var ev in events)
        {
            if (ev.Event.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.NonFungibleAssets)
            {
                var evData = ev.Event.Value2 as FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.Event;
                if (evData!.Value == InnerEvent.Created)
                {
                    var evData2 = evData.Value2 as FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventCreated;
                    if (Enumerable.SequenceEqual(evData2!.Owner.Bytes, ((AccountId32)AccountKeyring.Eve()).Bytes))
                    {
                        return evData2.ClassId;
                    }
                }
            }
        }
        throw new Exception("Something wrong. Event NonFungibleAssets.Created not found");
    }

    /// <summary>
    /// Set Bettor characteristics with nomber of rounds
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="rounds"></param>
    /// <returns></returns>
    static public async Task SetCharacteristicBettor(NfaClassId classId, uint rounds = 3)
    {
        Client api = await Client.New();
        PairSigner signer = new(signer: AccountKeyring.Ferdie());
        var organizationId = AccountKeyring.Eve().ToAddress();

        Bettor bettor = new();

        // create outcomes
        BoundedVecBettorOutcome outcomes = new();
        List<BettorOutcome> outcomesList = new();
        foreach (var o in new string[] {"Win", "Lose", "Draw"})
        {
            BoundedVecU8 classNameU8 = new();
            classNameU8.Init(ArrayUtils.SizePrefixedByteArray(o.AsBytes()));
            U32 probability = 1;
            OutcomeResult res = new();
            res.Init((InnerOutcomeResult)Enum.Parse(typeof(InnerOutcomeResult), o), new BaseVoid());

            BettorOutcome outcome = new();
            outcome.Decode(classNameU8.Encode()
                            .Concat(probability.Encode())
                            .Concat(res.Encode())
                            .ToArray());
            outcomesList.Add(outcome);
        }
        outcomes.Init(outcomesList.ToArray());

        // create winings
        BoundedVecBettorWinning winnings = new();
        BettorWinning winning = new();
        // wininng will be fa = 1
        FungibleAssetId id = 1;
        FungibleAssetBalance amount = (BigInteger)10;
        Tuple<FungibleAssetId, FungibleAssetBalance> win = new();
        win.Init(id, amount);
        winning.Init(InnerBettorWinning.Fa, win);
        winnings.Init(new BettorWinning[] { winning });
        // draw outcome
        DrawOutcomeResult drawOutcome = new();
        drawOutcome.Init(InnerDrawOutcomeResult.Lose, new BaseVoid());

        bettor.Decode(outcomes.Encode()
                      .Concat(winnings.Encode())
                      .Concat(rounds.Encode())
                      .Concat(drawOutcome.Encode())
                      .ToArray());
        CompactNonFungibleClassId comClassId = new();
        comClassId.Init(classId);
        Characteristic characteristic = new();
        OptionBettor opBettor = new();
        opBettor.Init(bettor);
        characteristic.Init(InnerCharacteristic.Bettor, opBettor);
        var txPayload = api.Tx.NonFungibleAssets.SetCharacteristic(organizationId,comClassId, characteristic);
        var txProgress = await api.Tx.SignAndSubmitThenWatchDefault(txPayload, signer);
        var _ = await txProgress.WaitForFinalizedSuccess();
    }

    /// <summary>
    /// Set Purchased characteristic for Nfa with given prise
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    static public async Task SetCharacteristicPurchased(NfaClassId classId, uint faAssetid, BigInteger amount)
    {
        Client api = await Client.New();
        PairSigner signer = new(signer: AccountKeyring.Ferdie());
        var organizationId = AccountKeyring.Eve().ToAddress();

        Purchased purchased = new();
        BoundedVecOffer offers = new();
        Offer offer = new();
        BoundedVecAttribute attrs = new();
        attrs.Init(Array.Empty<Attribute>());
        offer.Decode(
            faAssetid.Encode() // FungibleAssetId
            .Concat(((U128)amount).Encode()) //FungibleAssetBalance
            .Concat(attrs.Encode()) //BoundedVecAttribute
            .ToArray()
        );
        offers.Init(new Offer[] { offer });
        purchased.Init(offers.Encode());
        
        OptionPurchased opPurchased = new();
        opPurchased.Init(purchased);
        Characteristic characteristic = new();
        characteristic.Init(InnerCharacteristic.Purchased, opPurchased);
        CompactNonFungibleClassId comClassId = new();
        comClassId.Init(classId);
        var txPayload = api.Tx.NonFungibleAssets.SetCharacteristic(organizationId,comClassId, characteristic);
        var txProgress = await api.Tx.SignAndSubmitThenWatchDefault(txPayload, signer);
        var _ = await txProgress.WaitForFinalizedSuccess();
    }
}
