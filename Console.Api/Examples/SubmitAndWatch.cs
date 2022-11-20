///
/// To run this example, a local node should be running.
///
using System;
using FinalBiome.Api;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace ConsoleApi.Examples;

public static class SubmitAndWatch
{
    /// <summary>
    /// This is the highest level approach to using this API. We use <see cref="WaitForFinalizedSuccess"/>
    /// to wait for the transaction to make it into a finalized block, and also ensure that the
    /// transaction was successful according to the associated events.
    /// </summary>
    /// <returns></returns>
    public static async Task SimpleCreate()
    {
        Client api = await Client.New();

        PairSigner signer = new PairSigner(AccountKeyring.Ferdie());

        // Init Organization address
        FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
        FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32 = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
        accountId32.Init(AddressUtils.GetPublicKeyFrom("5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw"));
        organizationId.Init(FinalBiome.Api.Types.SpRuntime.Multiaddress.InnerMultiAddress.Id,
                            accountId32);
        // Init NFA name
        FinalBiome.Api.Types.Vec<U8> nfaName = new FinalBiome.Api.Types.Vec<U8>();
        nfaName.Init(ArrayUtils.SizePrefixedByteArray("test5".AsBytes()));

        // Construct call payload
        byte palletIsx = 11;
        byte callIsx = 0;
        List<byte> callData = new List<byte>();
        organizationId.EncodeTo(ref callData);
        nfaName.EncodeTo(ref callData);
        StaticTxPayload call = new StaticTxPayload(palletIsx, callIsx, callData);

        var createNfa = await api.Tx.SignAndSubmitThenWatchDefault(call, signer);
        var events = await createNfa.WaitForFinalizedSuccess();

        foreach (var ev in events)
        {
            Console.WriteLine($"{ev.ToHuman()}");
        }
    }
}

