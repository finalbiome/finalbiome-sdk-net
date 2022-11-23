using System;
using System.Diagnostics;
using ConsoleApi.Examples;
using FinalBiome.Api;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Rpc;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ConsoleApi;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) =>
        {
            Console.WriteLine("\nCanceling...");
            cts.Cancel();
            e.Cancel = true;
        };

        try
        {
            await Exec(cts.Token);
        }
        catch (TaskCanceledException)
        { }

        if (!cts.IsCancellationRequested)
        {
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
            cts.Dispose();
        }
    }

    static async Task Exec(CancellationToken cancellationToken)
    {
        Client client = await Client.New();

        Console.WriteLine($"GenesisHash: {client.GenesisHash.ToHex()}");
        Console.WriteLine("");

        #region get NFA
        //FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId assetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
        //assetId.Init(1);
        //var faDetails = await client.Storage.FungibleAssets.Assets(assetId);
        //Console.WriteLine($"faDetails:\n{Stringify(faDetails)}");

        //var nextId = await client.Storage.FungibleAssets.NextAssetId();
        //Console.WriteLine($"nextId:\n{Stringify(nextId)}");
        #endregion

        #region Checking calculation of the block hash

        Hash lastFinalizedBlockHash = await client.Rpc.FinalizedHead();
        Header lastFinalizedBlockHeader = await client.Rpc.Header(lastFinalizedBlockHash);

        Debug.Assert(Enumerable.SequenceEqual(lastFinalizedBlockHash.Bytes, lastFinalizedBlockHeader.Hash().Bytes));

        //Console.WriteLine($"Block 1: {lastFinalizedBlockHash.ToHex()}");
        //Console.WriteLine($"Block 2: {lastFinalizedBlockHeader.Hash().ToHex()}");
        #endregion

        #region Subscribe to (in this case, finalized) blocks.
        //var sub = client.Blocks.SubscribeFinalized(cancellationToken);

        //await foreach (var block in sub)
        //{
        //    Console.WriteLine($"Fin block: {block.Hash.ToHex()}\n");
        //    // Ask for the events for this block.
        //    var events = await block.Events();
        //    if (events.EventRecords is not null)
        //    {
        //        Console.WriteLine($"Events in the block: {block.Hash.ToHex()}\n");

        //        foreach (var ev in events.EventRecords.Value)
        //        {
        //            Console.WriteLine($"Event: {Stringify(ev, Formatting.None)}");
        //        }
        //    }
        //}
        #endregion

        #region Create NFA
        // Init signer account
        //Account ferdie = Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
        //                                  HexUtils.HexToBytes("0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842"));

        //// Init NFA name
        //FinalBiome.Api.Types.Vec<U8> nfaName = new FinalBiome.Api.Types.Vec<U8>();
        //nfaName.Init(ArrayUtils.SizePrefixedByteArray("test5".AsBytes()));
        //// Init Organization address
        //FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
        //FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32 = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
        //accountId32.Init(AddressUtils.GetPublicKeyFrom("5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw"));
        //organizationId.Init(FinalBiome.Api.Types.SpRuntime.Multiaddress.InnerMultiAddress.Id,
        //                    accountId32);
        //// Construct call payload
        //byte palletIsx = 11;
        //byte callIsx = 0;
        //List<byte> callData = new List<byte>();
        //organizationId.EncodeTo(ref callData);
        //nfaName.EncodeTo(ref callData);
        //StaticTxPayload call = new StaticTxPayload(palletIsx, callIsx, callData);
        //PairSigner signer = new PairSigner(ferdie);
        //Hash h = await client.Tx.SignAndSubmitDefault(call, signer);
        //Console.WriteLine($"Ext hash: {h.ToHex()}");

        #endregion

        await SubmitAndWatch.HandleTransferEvents();
        await GetStorageData.SimpleGet();
        await GetStorageData.GetAndWatch(cancellationToken);
    }

    static string Stringify(Codec? value, Formatting formatting = Formatting.Indented)
    {
        if (value is null) return "null";
        var sOpt = new JsonSerializerSettings
        {
            //NullValueHandling = NullValueHandling.Ignore,
            Converters = {
                    new ApiTypesJsonConverter(),
                    new StringEnumConverter(),
                }
        };

        return JsonConvert.SerializeObject(value, formatting, sOpt);
    }

}
