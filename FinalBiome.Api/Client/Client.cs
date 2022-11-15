﻿using System;
using FinalBiome.Api.Blocks;
using FinalBiome.Api.Constants;
using FinalBiome.Api.Events;
using FinalBiome.Api.Rpc;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types.PrimitiveTypes;
using FinalBiome.Api.Types.SpVersion;

namespace FinalBiome.Api.Client;

using Hash = H256;

/// <summary>
/// A client that can be used to perform API calls.
/// </summary>
public class Client
{
    /// <summary>
    /// Return the genesis hash.
    /// </summary>
    public Hash GenesisHash { get; internal set; }
    /// <summary>
    /// Return the runtime version.
    /// </summary>
    public FinalBiome.Api.Rpc.RuntimeVersion RuntimeVersion { get; internal set; }
    /// <summary>
    /// Return the [`Metadata`] used in this client.
    /// </summary>
     public string Metadata { get; internal set; }

    /// <summary>
    /// Return an RPC client to make raw requests with.
    /// </summary>
    public Api.Rpc.Rpc Rpc { get; internal set; }

    /// Work with transactions.
    public TxClient Tx { get; internal set; }

    /// Work with events.
    public EventsClient Events { get; internal set; }

    /// Work with storage.
    public StorageClient Storage { get; internal set; }

    /// Access constants.
    public ConstantsClient Constants { get; internal set; }

    /// Work with blocks.
    public BlocksClient Blocks { get; internal set; }

    public Client(Hash genesisHash,
        FinalBiome.Api.Rpc.RuntimeVersion runtimeVersion,
        string metadata,
        Api.Rpc.Rpc rpc
        )
    {
        GenesisHash = genesisHash;
        RuntimeVersion = runtimeVersion;
        Metadata = metadata;

        Rpc = rpc;

        Tx = new TxClient();
        Events = new EventsClient();
        Storage = new StorageClient();
        Constants = new ConstantsClient();
        Blocks = new BlocksClient();
    }

    /// <summary>
    /// Construct a new [`Client`] using default settings which
    /// point to a locally running node on `ws://127.0.0.1:9944`.
    /// </summary>
    /// <returns></returns>
    public static async Task<Client> New()
    {
        string url = "ws://127.0.0.1:9944";
        return await Client.FromUrl(url);
    }

    /// <summary>
    /// Construct a new [`Client`], providing a URL to connect to.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static async Task<Client> FromUrl(string url)
    {
        RpcClient rpcClient = await RpcClient.Build(new Uri(url));
        return await Client.FromRpcClient(rpcClient);
    }

    /// <summary>
    /// Construct a new [`Client`] by providing an [`Rpc`] to drive the connection.
    /// </summary>
    /// <param name="rpcClient"></param>
    /// <returns></returns>
    public static async Task<Client> FromRpcClient(RpcClient rpcClient)
    {
        Api.Rpc.Rpc rpc = new Api.Rpc.Rpc(rpcClient);

        Task<Hash> genesisHashTask = rpc.GenesisHash();
        Task<FinalBiome.Api.Rpc.RuntimeVersion> runtimeVersionTask = rpc.RuntimeVersion(null);
        Task<string> metadataTask = rpc.Metadata();

        await Task.WhenAll(genesisHashTask, runtimeVersionTask, metadataTask);

        Hash genesisHash = await genesisHashTask;
        FinalBiome.Api.Rpc.RuntimeVersion runtimeVersion = await runtimeVersionTask;
        string metadata = await metadataTask;

        return new Client(
            genesisHash,
            runtimeVersion,
            metadata,
            rpc
            );

    }
    ~Client()
    {
        Console.WriteLine("Down..");
    }

    /// <summary>
    /// Create an object which can be used to keep the runtime up to date
    /// in a separate thread.
    /// </summary>
    public void SubscribeToUpdates()
    {
        throw new NotImplementedException(); // TODO: SubscribeToUpdates
    }

    
}

