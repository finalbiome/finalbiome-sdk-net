using System;
using FinalBiome.Api;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConsoleApi;

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
