///
/// To run this example, a local node should be running.
///
using System;
using FinalBiome.Api;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Tx.Errors;
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
        var organizationId = AccountKeyring.Eve().ToAddress();
        // Init NFA name
        FinalBiome.Api.Types.Vec<U8> nfaName = new FinalBiome.Api.Types.Vec<U8>();
        nfaName.Init(ArrayUtils.SizePrefixedByteArray("test5".AsBytes()));

        // Construct call payload
        byte palletIsx = 11;
        byte callIsx = 0;
        List<byte> callData = new List<byte>();
        organizationId.EncodeTo(ref callData);
        nfaName.EncodeTo(ref callData);
        StaticTxPayload callTx = new StaticTxPayload(palletIsx, callIsx, callData);

        var createNfa = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var events = await createNfa.WaitForFinalizedSuccess();

        foreach (var ev in events)
        {
            Console.WriteLine($"{ev.ToHuman()}");
        }
    }

    /// <summary>
    /// This is very similar to `SimpleTransfer`, except to show that we can handle
    /// waiting for the transaction to be finalized separately from obtaining and checking
    /// for success on the events.
    /// </summary>
    /// <returns></returns>
    public static async Task SimpleTransferSeparateEvents()
    {
        Client api = await Client.New();

        PairSigner signer = new PairSigner(AccountKeyring.Ferdie());

        // Init Organization address
        var organizationId = AccountKeyring.Eve().ToAddress();
        // Init NFA name
        FinalBiome.Api.Types.Vec<U8> nfaName = new FinalBiome.Api.Types.Vec<U8>();
        nfaName.Init(ArrayUtils.SizePrefixedByteArray("test5".AsBytes()));

        // Construct call payload
        byte palletIsx = 11;
        byte callIsx = 0;
        List<byte> callData = new List<byte>();
        organizationId.EncodeTo(ref callData);
        nfaName.EncodeTo(ref callData);
        StaticTxPayload callTx = new StaticTxPayload(palletIsx, callIsx, callData);

        var createNfaProc = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);
        var createNfa = await createNfaProc.WaitForFinalized();

        // Now we know it's been finalized, we can get hold of a couple of
        // details, including events. Calling `wait_for_finalized_success` is
        // equivalent to calling `wait_for_finalized` and then `wait_for_success`:
        var _events = await createNfa.WaitForSuccess();

        // Alternately, we could just `fetch_events`, which grabs all of the events like
        // the above, but does not check for success, and leaves it up to you:
        var events = await createNfa.FetchEvents();

        foreach (var ev in events)
        {
            Console.WriteLine($"{ev.ToHuman()}");
        }
    }

    /// <summary>
    /// If we need more visibility into the state of the transaction, we can also ditch
    /// `wait_for_finalized` entirely and stream the transaction progress events, handling
    /// them more manually.
    /// </summary>
    /// <returns></returns>
    public static async Task HandleTransferEvents()
    {
        Client api = await Client.New();

        PairSigner signer = new PairSigner(AccountKeyring.Ferdie());

        // Organization address
        var organizationId = AccountKeyring.Eve().ToAddress();
        // NFA name
        FinalBiome.Api.Types.VecU8 nfaName = new FinalBiome.Api.Types.VecU8();
        nfaName.Init(ArrayUtils.SizePrefixedByteArray("test5".AsBytes()));

        // Construct call payload
        var callTx = api.Tx.NonFungibleAssets.Create(organizationId, nfaName);
        //byte palletIsx = 11;
        //byte callIsx = 0;
        //List<byte> callData = new List<byte>();
        //organizationId.EncodeTo(ref callData);
        //nfaName.EncodeTo(ref callData);
        //StaticTxPayload callTx = new StaticTxPayload(palletIsx, callIsx, callData);

        var createNfaProc = await api.Tx.SignAndSubmitThenWatchDefault(callTx, signer);

        await foreach (var txStatus in createNfaProc.NextItem())
        {
            switch (txStatus.Value)
            {
                // Made it into a block, but not finalized.
                case InnerTxStatus.InBlock:
                    {
                        var details = ((TxInBlock)txStatus.Value2);
                        Console.WriteLine($"Transaction {details.ExtrinsicHash.ToHex()} made it into block {details.BlockHash.ToHex()}");
                        try
                        {
                            var events = await details.WaitForSuccess();
                            Console.WriteLine("NFA created is now in block (but not finalized)");
                        }
                        catch (ExtrinsicFailedException e)
                        {
                            Console.WriteLine($"FAILED: {e.Message}");
                        }
                    }
                    break;
                case InnerTxStatus.Finalized:
                    {
                        var details = ((TxInBlock)txStatus.Value2);
                        Console.WriteLine($"Transaction {details.ExtrinsicHash.ToHex()} is finalized in block {details.BlockHash.ToHex()}");

                    }
                    break;
                default:
                    Console.WriteLine($"Current transaction status: {txStatus.Value}");
                    break;

            }
        }
    }

}

