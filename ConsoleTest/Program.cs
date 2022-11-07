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
using Schnorrkel.Keys;
using Ajuna.NetApi.Model.Extrinsics;
using Newtonsoft.Json.Linq;
using System.Text;
using Ajuna.NetApi.Model.Rpc;
using Utils = Ajuna.NetApi.Utils;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //var currentDate = DateTime.Now;

            //Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");

            await MainAsync();

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
                return;
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
                Console.WriteLine($"Generated {generator.CountParsedTypes()} types");
                Console.WriteLine($"Generated {generator.CountParsedStorages()} storages");
                Console.WriteLine($"Generated {generator.CountParsedTransactionTypes()} transaction types");
                return;
            }
            #endregion

            #region Get Account Info

            string address = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL";
            byte[] publicKey = Utils.GetPublicKeyFrom(address);

            FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            accountId.Create(publicKey);

            var r = await client.Query.System.Account(accountId);
            Console.WriteLine($"Account Info: {Stringify(r)}");

            #endregion

            #region Get NFA by id

            FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId();
            classId.Create(0);

            var nfaClassDetails = await client.Query.NonFungibleAssets.Classes(classId);
            Console.WriteLine($"nfaClassDetails: {Stringify(nfaClassDetails)}");

            //FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nfaAssetId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId();
            //nfaAssetId.Create(0);
            //var nfaDetails = await client.Query.NonFungibleAssets.Assets(classId, nfaAssetId, token);

            #endregion

            #region Get FA by id

            FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId assetId = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
            assetId.Create(1);
            var faDetails = await client.Query.FungibleAssets.Assets(assetId);
            Console.WriteLine($"faDetails:\n{Stringify(faDetails)}");

            #endregion

            #region Exec Extrinsic Create NFA

            if (false)
            {

                FinalBiome.Sdk.SpRuntime.Multiaddress.InnerMultiAddress addressType = FinalBiome.Sdk.SpRuntime.Multiaddress.InnerMultiAddress.Id;
                FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress orgId = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
                FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32 = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();

                string addressOrgAcc = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw"; // Eve
                accountId32.Create(Utils.GetPublicKeyFrom(addressOrgAcc));
                orgId.Create(addressType, accountId32);

                //target/release/subkey inspect //Ferdie
                //Secret Key URI `//Ferdie` is account:
                //  Network ID:        substrate 
                // Secret seed:       0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842
                //  Public key (hex):  0x1cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c
                //  Account ID:        0x1cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c
                //  Public key (SS58): 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
                //  SS58 Address:      5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
                MiniSecret MiniSecretBob = new MiniSecret(Utils.HexToByteArray("0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842"), ExpandMode.Ed25519);
                Account Ferdie = Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);

                FinalBiome.Sdk.VecU8 nfaName = new FinalBiome.Sdk.VecU8();

                // with subscribe ext status
                Func<string, ExtrinsicStatus, Task> actionExtrinsicUpdate = async (subscriptionId, extrinsicStatus) =>
                {
                    Console.WriteLine($"extrinsicStatus:\n{extrinsicStatus}");
                    if (extrinsicStatus.Finalized is not null)
                    {
                        await client.client.Author.UnwatchExtrinsicAsync(subscriptionId);
                    }
                };


                /// Create as client native method
                nfaName.Create(Utils.SizePrefixedByteArray(Encoding.UTF8.GetBytes("test4").ToList()));
                await client.Tx.NonFungibleAssets.Create(Ferdie, orgId, nfaName);

                nfaName.Create(Utils.SizePrefixedByteArray(Encoding.UTF8.GetBytes("test5").ToList()));
                await client.Tx.NonFungibleAssets.Create(Ferdie, orgId, nfaName, actionExtrinsicUpdate);

                Thread.Sleep(5_000);
            }

            #endregion

            #region Get Storage at block

            if (false)
            {
                var res = await client.Query.Timestamp.Now();
                Console.WriteLine($"Now: {Stringify(res)}");
                var hash = await client.client.Chain.GetBlockHashAsync(token);

                Thread.Sleep(3_000);

                var res2 = await client.Query.Timestamp.Now(hash.Encode());
                Console.WriteLine($"Now at: {Stringify(res2)}");

                Console.WriteLine($"hash: {Utils.Bytes2HexString(hash.Encode())}");

            }
            #endregion

            #region Events

            var evs = await client.Events.At();

            Console.WriteLine($"Events: {Stringify(evs.EventRecords)}");
            Console.WriteLine($"Events: {evs.EventRecords}");


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
                //NullValueHandling = NullValueHandling.Ignore,
                Converters = {
                    new ApiTypesJsonConverter(),
                    new StringEnumConverter(),
                }
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, sOpt);
        }
    }
}
