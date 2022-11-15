using System;
using FinalBiome.Api;
using FinalBiome.Api.Client;
using FinalBiome.Api.Utils;

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
    }

}
