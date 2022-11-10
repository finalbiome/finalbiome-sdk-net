using System;
using System.Diagnostics;
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
using Ajuna.NetApi.Model.Types.Metadata.V14;
using System.Security.Principal;
using Ajuna.NetApi.TypeConverters;
using System.Drawing;

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

            if (true)
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

                generator.Save("../../../Test");


                Console.WriteLine($"=== Statistics ===");
                Console.WriteLine($"Generated {generator.CountParsedTypes()} types");
                Console.WriteLine($"Generated {generator.CountParsedStorages()} storages");
                Console.WriteLine($"Generated {generator.CountParsedTransactionTypes()} transaction types");
                return;
            }
            #endregion

            #region Get Account Info

            if (false)
            {

                string address = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL";
                byte[] publicKey = Utils.GetPublicKeyFrom(address);

                FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
                accountId.Create(publicKey);

                var r = await client.Query.System.Account(accountId);
                Console.WriteLine($"Account Info: {Stringify(r)}");
            }

            #endregion

            #region Get NFA by id

            if (false)
            {

                FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId();
                classId.Create(0);

                var nfaClassDetails = await client.Query.NonFungibleAssets.Classes(classId);
                Console.WriteLine($"nfaClassDetails: {Stringify(nfaClassDetails)}");
            }
            //FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nfaAssetId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId();
            //nfaAssetId.Create(0);
            //var nfaDetails = await client.Query.NonFungibleAssets.Assets(classId, nfaAssetId, token);

            #endregion

            #region Get FA by id

            if (false)
            {
                FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId assetId = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
                assetId.Create(1);
                var faDetails = await client.Query.FungibleAssets.Assets(assetId);
                Console.WriteLine($"faDetails:\n{Stringify(faDetails)}");
            }

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
                MiniSecret MiniSecretFerdie = new MiniSecret(Utils.HexToByteArray("0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842"), ExpandMode.Ed25519);
                Account Ferdie = Account.Build(KeyType.Sr25519, MiniSecretFerdie.ExpandToSecret().ToBytes(), MiniSecretFerdie.GetPair().Public.Key);

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
                //nfaName.Create(Utils.SizePrefixedByteArray(Encoding.UTF8.GetBytes("test4").ToList()));
                //await client.Tx.NonFungibleAssets.Create(Ferdie, orgId, nfaName);

                nfaName.Create(Utils.SizePrefixedByteArray(Encoding.UTF8.GetBytes("test5").ToList()));
                var txHash = await client.Tx.NonFungibleAssets.Create(Ferdie, orgId, nfaName, actionExtrinsicUpdate);

                Console.WriteLine($"Tx Hash {txHash}");

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

            //var evs = await client.Events.At();

            //Console.WriteLine($"Events: {Stringify(evs.EventRecords)}");
            //Console.WriteLine($"Events: {evs.EventRecords}");


            #endregion

            #region Subscribe block events NOT DONE

            if (false)
            {
                async void makeTransfersInLoop()
                {
                    MiniSecret MiniSecretAlice = new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
                    Account Alice = Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToBytes(), MiniSecretAlice.GetPair().Public.Key);
                    MiniSecret MiniSecretBob = new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
                    Account Bob = Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);

                    var amount = 1_000_000_000;
                    CompactU128 transferAmount = new CompactU128();
                    transferAmount.Create(amount);

                    FinalBiome.Sdk.SpRuntime.Multiaddress.InnerMultiAddress bobAddressType = FinalBiome.Sdk.SpRuntime.Multiaddress.InnerMultiAddress.Id;
                    FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress bobMulti = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
                    FinalBiome.Sdk.SpCore.Crypto.AccountId32 bobAccountId32 = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
                    bobAccountId32.Create(MiniSecretBob.GetPair().Public.Key);
                    bobMulti.Create(bobAddressType, bobAccountId32);

                    Func<string, ExtrinsicStatus, Task> subTx = async (subId, status) =>
                    {
                        Console.WriteLine($"Transaction state: {status.ExtrinsicState}");
                    };

                    var transferTx = await client.Tx.Balances.Transfer(Alice, bobMulti, transferAmount);
                    Console.WriteLine($"Transfer Tx Hash: {transferTx}");

                    while (true)
                    {
                        amount += 100_000_000;
                        CompactU128 transferAmountNext = new CompactU128();
                        transferAmountNext.Create(amount);

                        var transferTxNext = await client.Tx.Balances.Transfer(Alice, bobMulti, transferAmountNext);
                        Console.WriteLine($"Transfer Tx Hash: {transferTxNext}");

                        Thread.Sleep(3_000);

                    }
                }

                // Get each finalized block as it arrives.
                Func<string, FinalBiome.Sdk.Blocks.Block, Task> cb = async (subId, block) =>
                {
                    // Ask for the events for this block.
                    var events = await block.Events();
                    var blockHash = block.Hash.Value;

                    Console.WriteLine($"  Dynamic event details: {blockHash}:");
                    foreach (var e in events.EventRecords.Value)
                    {
                        Console.WriteLine($"    {Stringify(e)}");
                    }

                    var blockBody = await block.Body();
                    foreach (var ext in blockBody.Extrinsics())
                    {
                        Console.WriteLine($"  Extrinsic index: {ext.Index}");
                    };
                };

                // Subscribe to (in this case, finalized) blocks.
                string sub = await client.Block.SubscribeFinalized(cb);

                // While this subscription is active, balance transfers are made somewhere
                Thread t = new Thread(makeTransfersInLoop);
                t.Start();

                Thread.Sleep(30_000);
                t.Interrupt();
            }

            #endregion

            #region Check hash of block

            Hash lastFinalizedBlockHash = await client.client.Chain.GetFinalizedHeadAsync();
            Header lastFinalizedBlockHeader = await client.client.Chain.GetHeaderAsync(lastFinalizedBlockHash);

            Debug.Assert(Enumerable.SequenceEqual(lastFinalizedBlockHash.Bytes, lastFinalizedBlockHeader.Hash().Bytes));

            if (false)
            {

                Header h = new Header();
                var p = new Hash();
                p.Create(HashExtension.Blake2(Encoding.UTF8.GetBytes("1000"), 256));
                h.ParentHash = p;
                var n = new BaseCom<U32>();
                n.Create(2000);
                h.Number = n;
                var s = new Hash();
                s.Create(HashExtension.Blake2(Encoding.UTF8.GetBytes("3000"), 256));
                h.StateRoot = s;

                var e1 = new Hash();
                e1.Create(HashExtension.Blake2(Encoding.UTF8.GetBytes("4000"), 256));
                h.ExtrinsicsRoot = e1;

                var d = new Digest();

                var log0 = new DigestItem();

                var t = new BaseVec<U8>();
                List<U8> b0 = new List<U8>();
                foreach (var b01 in Encoding.UTF8.GetBytes("5000"))
                {
                    var a = new U8();
                    a.Create(b01);
                    b0.Add(a);
                }
                t.Create(b0.ToArray());
                log0.Create(innerDigestItem.Other, t);

                d.Create(new DigestItem[] { log0 });
                h.Digest = d;



                Console.WriteLine("[{0}]", string.Join(", ", h.Bytes));

                var checkDecode = new byte[]
                {
                197, 243, 254, 225, 31, 117, 21, 218, 179, 213, 92, 6, 247, 164, 230, 25, 47, 166,
                140, 117, 142, 159, 195, 202, 67, 196, 238, 26, 44, 18, 33, 92, 65, 31, 219, 225,
                47, 12, 107, 88, 153, 146, 55, 21, 226, 186, 110, 48, 167, 187, 67, 183, 228, 232,
                118, 136, 30, 254, 11, 87, 48, 112, 7, 97, 31, 82, 146, 110, 96, 87, 152, 68, 98,
                162, 227, 222, 78, 14, 244, 194, 120, 154, 112, 97, 222, 144, 174, 101, 220, 44,
                111, 126, 54, 34, 155, 220, 253, 124, 4, 0, 16, 53, 48, 48, 48
                };

                Debug.Assert(Enumerable.SequenceEqual(h.Bytes, checkDecode));
            }


            if (false)
            {
                /// checking encoding of the digest
                var d2 = new Digest();

                var log0 = new DigestItem();

                var t = new BaseVec<U8>();
                List<U8> b0 = new List<U8>();
                for (byte i = 1; i < 4; i++)
                {
                    var a = new U8();
                    a.Create(i);
                    b0.Add(a);
                }
                t.Create(b0.ToArray());
                log0.Create(innerDigestItem.Other, t);



                var log1 = new DigestItem();
                var t0 = new BaseVec<U8>();
                List<U8> b3 = new List<U8>();
                for (byte i = 1; i < 4; i++)
                {
                    var a = new U8();
                    a.Create(i);
                    b3.Add(a);
                }
                t0.Create(b3.ToArray());

                var c = new ConsensusEngineId();
                List<U8> b1 = new List<U8>();
                foreach (var i in Encoding.UTF8.GetBytes("test"))
                {
                    var a = new U8();
                    a.Create(i);
                    b1.Add(a);
                }
                c.Create(b1.ToArray());

                var sealData = new BaseTuple<ConsensusEngineId, BaseVec<U8>>();
                sealData.Create(c, t0);
                log1.Create(innerDigestItem.Seal, sealData);

                d2.Create(new DigestItem[] { log0, log1 });

                var json = JsonConvert.SerializeObject(d2, Formatting.Indented, new GenericTypeConverter<DigestItem>());
                Console.WriteLine(json);

                byte[] sss = d2.Logs.Bytes;
                Console.WriteLine(Utils.Bytes2HexString(sss));
                Debug.Assert(Utils.Bytes2HexString(sss) == "0x08000C01020305746573740C010203");

                //string json = "{\"logs\":[\"0x000c010203\",\"0x05746573740c010203\"]}";
                //string json = "\"0x05746573740c010203\"";
                //DigestItem di = JsonConvert.DeserializeObject<DigestItem>(json, new GenericTypeConverter<DigestItem>());

                //Console.WriteLine(di);

            }

            #endregion

            #region Chech Block Response

            if (false)
            {
                ChainBlockResponse cbr = await client.client.Chain.GetBlockAsync();
                Console.WriteLine(Stringify(cbr));
            }

            #endregion

            if (false)
            {

                // r1SFrTG1XHznHryM
                Hash h = new Hash();
                h.Create("0xB8ECA7A10CD653CE7B9D68DC670DCE456BD2CCCA17384CCA69D22B7ACB83F33F");

                var block = await client.Block.At(h);
                var body = await block.Body();
                foreach (var e in body.Extrinsics())
                {
                    //Console.WriteLine($"  Extrinsic {e.Index} : {e.}");
                    var ev = await e.Events();
                    foreach (var er in ev)
                    {
                        Console.WriteLine($"   Event of the extrinsic {ev.ExtrinsicHash}:\n" +
                                          $"{Stringify(er, Formatting.None)}");

                    }
                }
            }

            if (false)
            {
                FinalBiome.Sdk.FrameSystem.VecEventRecord ev = new FinalBiome.Sdk.FrameSystem.VecEventRecord();
                ev.Create("0x1400000000000000001c6c0900000000020000000100000005081cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c21ce24050000000000000000000000000000010000000b0009000000e659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4e00000100000006001cbd2d43530a44705ad088af313e18f80b53ef16b36177cd4b77b846f2a5f07c21ce24050000000000000000000000000000000000000000000000000000000000000100000000008093dc1400000000000000");
            }

            #region Close connection
            await client.client.CloseAsync();
            client.client.Dispose();
            #endregion
        }

        static string Stringify(IType value, Formatting formatting = Formatting.Indented)
        {
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
}
