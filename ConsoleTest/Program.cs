using System;
using Ajuna.NetApi;
using System.Threading;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using System.Numerics;
using FinalBiome.Sdk;
using FinalBiome.TypeGenerator;
using Newtonsoft.Json;
using ConsoleTest;
using Newtonsoft.Json.Converters;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //var currentDate = DateTime.Now;

            //Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");

            MainAsync().GetAwaiter().GetResult();

            //SerializeTypes();

            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
        }

        private static async Task MainAsync()
        {
            #region Connect to node
            string url = "ws://127.0.0.1:9944";
            Client client = new Client(url);

            CancellationToken token = CancellationToken.None;

            try
            {
                Console.WriteLine("Connecting to node...");
                await client.client.ConnectAsync();
                if (client.client.IsConnected)
                {
                    Console.WriteLine($"Client connected to node {url}");
                }

            } catch (Exception ex)
            {
                Console.WriteLine($"Caught Exception: {ex.Message}");
            }
            #endregion

            #region Get Metadata
            //string metadata = client.client.MetaData.Serialize();
            //await File.WriteAllTextAsync("metadata.json", metadata);
            #endregion

            #region Get Current Block

            string reqCurrentBlock = RequestGenerator.GetStorage("System", "Number", Storage.Type.Plain, null, null);
            U32 resCurrentBlock = await client.client.GetStorageAsync<U32>(reqCurrentBlock, token);

            Console.WriteLine($"Current Block data: {Stringify(resCurrentBlock)}");


            #endregion

            #region Generate types

            if (false)
            {
                var meta = client.client.MetaData;
                var types = meta.NodeMetadata.Types;

                TypeGenerator generator = new TypeGenerator(meta);
                List<ParsedType> primitives = new List<ParsedType>
            {
                new ParsedType("I8", "i8", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("I16", "i16", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("I32", "i32", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("I64", "i64", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("I128", "i128", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("I256", "i256", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("U8", "u8", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("U16", "u16", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("U32", "u32", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("U64", "u64", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("U128", "u128", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("U256", "u256", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("Str", "str", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
                new ParsedType("Bool", "bool", false, Namespace: "Ajuna.NetApi.Model.Types.Primitive"),
            };
                generator.AddExistedTypes(primitives);

                generator.Parse();

                generator.Save("../../..");


                Console.WriteLine($"=== Statistics ===");
                Console.WriteLine($"Found {generator.ParsedTypes.Count} types");
                int i = 0;
                foreach (var item in generator.ParsedTypes)
                {
                    if (item.Value.Parsed) i++;
                }
                Console.WriteLine($"Generated {i} types");
            }
            #endregion

            #region Get Account Info
            string address = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL";
            byte[] publicKey = Utils.GetPublicKeyFrom(address);

            Storage.Hasher[] hashers = new[] { Storage.Hasher.BlakeTwo128Concat };

            FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            accountId.Create(publicKey);

            IType[] keys = new[] { accountId };

            string req = RequestGenerator.GetStorage("System", "Account", Storage.Type.Map, hashers, keys);


            FinalBiome.Sdk.FrameSystem.AccountInfo res = await client.client.GetStorageAsync<FinalBiome.Sdk.FrameSystem.AccountInfo>(req, token);
            Console.WriteLine($"Account Info: {Stringify(res)}");
            #endregion

            #region Get NFA by id
            FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId();
            classId.Create(0);
            var nfaClassDetails = await client.Query.NonFungibleAssets.Classes(classId, token);
            Console.WriteLine($"nfaClassDetails: {Stringify(nfaClassDetails)}");
            FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nfaAssetId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId();
            nfaAssetId.Create(0);
            var nfaDetails = await client.Query.NonFungibleAssets.Assets(classId, nfaAssetId, token);

            #endregion

            #region Get FA by id

            FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId assetId = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
            assetId.Create(1);
            var faDetails = await client.Query.FungibleAssets.Assets(assetId, token);
            //Console.WriteLine($"faDetails:\n{JsonConvert.SerializeObject(faDetails, Formatting.Indented, sOpt)}");


            Console.WriteLine($"nfaClassDetails:\n{Stringify(nfaClassDetails)}");
            Console.WriteLine($"nfaDetails:\n{Stringify(nfaDetails)}");
            Console.WriteLine($"nfaDetails:\n{Stringify(nfaClassDetails)}");

            #endregion


            #region Close connection
            await client.client.CloseAsync();
            client.client.Dispose();
            #endregion
        }

        static string Stringify(IType value)
        {
            var sOpt = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = {
                    new ApiTypesJsonConverter(),
                    new StringEnumConverter(),
                }
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, sOpt);
        }
    }
}
