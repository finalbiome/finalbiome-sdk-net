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
using FinalBiome.Api.Types.SpRuntime.Multiaddress;
using FinalBiome.Api.Types.PalletOrganizationIdentity.Types;

/// <summary>
/// Manipulation with network state for tests.
/// </summary>
static public class NetworkHelpers
{
    /// <summary>
    /// Create game client and init it with Eve game
    /// </summary>
    /// <returns></returns>
    static public async Task<Sdk.Client> GetSdkClientForEveGame()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath(),
            NotAutoLogin = true,
        };
        return await Sdk.Client.Create(config);
    }

    /// <summary>
    /// Exec BuyNfaMechanics in the Eve game by Dave of Nfa 1 and offer 0
    /// </summary>
    static public async Task<(NfaClassId classId, NfaInstanceId instanceId)> ExecBuyNfaMechanic(PairSigner signer)
    {
        Client api = await Client.New();
        var organizationId = AccountKeyring.Eve();

        NonFungibleClassId classId = new();
        classId.Init(1);
        U32 offerId = U32.From(0);

        var callTx = api.Tx.Mechanics.ExecBuyNfa(organizationId, classId, offerId);
        var buyNfa = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var txInBlock = await buyNfa.WaitForInBlock();
        var events = await txInBlock.WaitForSuccess();

        var account = signer.AccountId;
        
        // find Issuance of nfa instance
        var ev = events.First(e => 
            e.Event.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.NonFungibleAssets && 
            ((Event)e.Event.Value2).Value == InnerEvent.Issued &&
            // AddressUtils.GetAddressFrom(((EventIssued)((Event)e.Event.Value2).Value2).Owner.Bytes) == "5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy");
            Enumerable.SequenceEqual(((EventIssued)((Event)e.Event.Value2).Value2).Owner.Bytes, account.Bytes));
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
        var txInBlock = await createAttr.WaitForInBlock();
        var _ = await txInBlock.WaitForSuccess();
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
        var txInBlock = await createAttr.WaitForInBlock();
        var _ = await txInBlock.WaitForSuccess();
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
        var txInBlock = await txProgress.WaitForInBlock();
        var _ = await txInBlock.WaitForSuccess();
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
        var txInBlock = await txProgress.WaitForInBlock();
        var _ = await txInBlock.WaitForSuccess();
    }

    /// <summary>
    /// Top up the account balance if it is below a certain threshold.
    /// Makes as a transfer from Alice.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    static public async Task TopupAccountBalance(MultiAddress account)
    {
        BigInteger THRESHOLD = 10_000_000_000;

        Client api = await Client.New();

        var entity = api.Storage.System.Account((AccountId32)account.Value2);
        var accInfo = await entity.Fetch();

        if (accInfo is not null && accInfo.Data.Free >= THRESHOLD) return;

        PairSigner signer = new(signer: AccountKeyring.Alice());

        CompactU128 val = new();
        val.Init(THRESHOLD);

        var payload = api.Tx.Balances.Transfer(account, val);
        var txProgress = await api.Tx.SignAndSubmitThenWatchDefault(payload, signer);
        var txInBlock = await txProgress.WaitForInBlock();
        var _ = await txInBlock.WaitForSuccess();
    }

    /// <summary>
    /// Convertor from email of the test user to the address.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    static public AccountId32 TestAccountToAddress(string email)
    {
        string ss58Address = email switch
        {
            "testdave@finalbiome.net" => "5GYyqgLd4qTqRzc3crZNqxrZnwBroGeUvob3t73CQXixPydQ",
            _ => throw new Exception("Email not found"),
        };
        AccountId32 acc = new();
        acc.Init(Api.Utils.AddressUtils.GetPublicKeyFrom(ss58Address));
        return acc;
    }

    /// <summary>
    /// Set onboarding assets for the Eve game.
    /// Set as fa 0 - 100_000; fa 1 - 200_000;
    /// </summary>
    /// <returns></returns>
    static public async Task SetGameOnboardingData()
    {
        Client api = await Client.New();
        PairSigner signer = new(signer: AccountKeyring.Ferdie());
        var organizationId = AccountKeyring.Eve();

        OptionBoundedVecAirDropAsset assets = new();

        BoundedVecAirDropAsset ass = new();
        AirDropAsset a1 = new();
        FungibleAssetId a1InnerId = 0;
        FungibleAssetBalance a1InnerB = (BigInteger)100_000;
        Tuple<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance> a1t = new();
        a1t.Init(a1InnerId, a1InnerB);
        a1.Init(InnerAirDropAsset.Fa, a1t);
        AirDropAsset a2 = new();
        FungibleAssetId a2InnerId = 1;
        FungibleAssetBalance a2InnerB = (BigInteger)200_000;
        Tuple<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance> a2t = new();
        a2t.Init(a2InnerId, a2InnerB);
        a2.Init(InnerAirDropAsset.Fa, a2t);
        
        ass.Init(new AirDropAsset[] {a1, a2});
        assets.Init(ass);

        var payload = api.Tx.OrganizationIdentity.SetOnboardingAssets(organizationId, assets);
        var txProgress = await api.Tx.SignAndSubmitThenWatchDefault(payload, signer);
        var txInBlock = await txProgress.WaitForInBlock();
        var _ = await txInBlock.WaitForSuccess();
    }
}
