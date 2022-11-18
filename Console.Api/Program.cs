using System;
using System.Diagnostics;
using FinalBiome.Api;
using FinalBiome.Api.Rpc;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ConsoleApi;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class Program
{
    static async Task Main(string[] args)
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
        Console.WriteLine($"RuntimeVersion: {client.RuntimeVersion}");

        // get NFA
        FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId assetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
        assetId.Init(1);
        var faDetails = await client.Storage.FungibleAssets.Assets(assetId);
        Console.WriteLine($"faDetails:\n{Stringify(faDetails)}");

        var nextId = await client.Storage.FungibleAssets.NextAssetId();
        Console.WriteLine($"nextId:\n{Stringify(nextId)}");

        #region Checking calculation of the block hash

        Hash lastFinalizedBlockHash = await client.Rpc.FinalizedHead();
        Header lastFinalizedBlockHeader = await client.Rpc.Header(lastFinalizedBlockHash);

        Debug.Assert(Enumerable.SequenceEqual(lastFinalizedBlockHash.Bytes, lastFinalizedBlockHeader.Hash().Bytes));

        //Console.WriteLine($"Block 1: {lastFinalizedBlockHash.ToHex()}");
        //Console.WriteLine($"Block 2: {lastFinalizedBlockHeader.Hash().ToHex()}");
        #endregion

        // Subscribe to (in this case, finalized) blocks.
        var sub = client.Blocks.SubscribeFinalized(cancellationToken);

        await foreach (var block in sub)
        {
            Console.WriteLine($"Fin block: {block.Hash.ToHex()}\n");
            // Ask for the events for this block.
            var events = await block.Events();
            if (events.EventRecords is not null)
            {
                Console.WriteLine($"Events in the block: {block.Hash.ToHex()}\n");

                foreach (var ev in events.EventRecords.Value)
                {
                    Console.WriteLine($"Event: {Stringify(ev, Formatting.None)}");
                }
            }
        }

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
