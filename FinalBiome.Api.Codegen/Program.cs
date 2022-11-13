using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;

namespace FinalBiome.Api.Codegen;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var outputArtefactsFolderOption = new Option<DirectoryInfo?>(
            name: "--output",
            description: "The output directory for generated code.");
        var nodeEndpoint = new Option<string>(
            name: "--endpoint",
            description: "The endpoint for connecting to the node.",
            getDefaultValue: () => "ws://127.0.0.1:9944");



        var rootCommand = new RootCommand("Generate an API for interacting with a substrate node from FRAME metadata");
        rootCommand.AddOption(outputArtefactsFolderOption);
        rootCommand.AddOption(nodeEndpoint);

        rootCommand.SetHandler(async (directory, url) =>
        {
            await Generate(directory!, url!);
        },
            outputArtefactsFolderOption, nodeEndpoint);

        return await rootCommand.InvokeAsync(args);
    }

    internal static async Task Generate(DirectoryInfo outputDir, string url)
    {
        //string url = "ws://127.0.0.1:9944";
        SubstrateClient client = new SubstrateClient(new Uri(url), ChargeTransactionPayment.Default());

        try
        {
            Console.WriteLine("Connecting to node...");
            await client.ConnectAsync();
            if (client.IsConnected)
            {
                Console.WriteLine($"Client connected to node {url}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught Exception: {ex.Message}");
            return;
        }

        var meta = client.MetaData;
        TypeGenerator generator = new TypeGenerator(meta);
        List<ParsedType> primitives = new List<ParsedType>
            {
                new ParsedType("I8", "i8", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("I16", "i16", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("I32", "i32", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("I64", "i64", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("I128", "i128", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("I256", "i256", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("U8", "u8", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("U16", "u16", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("U32", "u32", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("U64", "u64", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("U128", "u128", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("U256", "u256", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("Bool", "bool", false, Namespace: "FinalBiome.Api.Types.Primitive"),
                new ParsedType("Str", "str", false, Namespace: "FinalBiome.Api.Types.Primitive"),
            };

        generator.AddExistedTypes(primitives);

        generator.Parse();

        generator.Save(outputDir.FullName);


        Console.WriteLine($"=== Statistics ===");
        Console.WriteLine($"Generated {generator.CountParsedTypes()} types");
        Console.WriteLine($"Generated {generator.CountParsedStorages()} storages");
        Console.WriteLine($"Generated {generator.CountParsedTransactionTypes()} transaction types");

        Console.Write($"{Environment.NewLine}Press any key to exit...");
        Console.ReadKey(true);
    }
}