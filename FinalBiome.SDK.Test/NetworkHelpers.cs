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
        Api.Types.PalletSupport.AttributeValue attrValue = new()
        {
            Value = Api.Types.PalletSupport.InnerAttributeValue.Text
        };
        BoundedVecU8 attrTextVal = new();
        attrTextVal.Init(ArrayUtils.SizePrefixedByteArray(attributeValue.AsBytes()));
        attrValue.Value2 = attrTextVal;
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
}
