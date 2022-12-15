using System;
using FinalBiome.Api.Types.PrimitiveTypes;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;
using FinalBiome.Api.Rpc;
using FinalBiome.Api.Rpc.Types;
using FinalBiome.Api.Extensions;
using Newtonsoft.Json.Linq;

namespace FinalBiome.Api.Rpc;

using Index = U32;
using AccountId = FinalBiome.Api.Types.SpCore.Crypto.AccountId32;
using Hash = H256;
using BlockNumber = U32;
using StorageKey = List<byte>;
/// <summary>
/// Client for substrate rpc interfaces
/// </summary>
public class Rpc : IDisposable
{
    readonly RpcClient client;
    /// <summary>
    /// Create a new [`Rpc`]
    /// </summary>
    /// <param name="client"></param>
    public Rpc(RpcClient client)
    {
        this.client = client;
    }

    /// <summary>
    /// Fetch the data for a given storage key
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="key"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<TResult> Storage<TResult>(List<byte> key, Hash? hash)
    {
        return await client.Request<TResult>("state_getStorage", RpcClient.RpcParams(key.ToHex(), hash?.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the keys with prefix with pagination support.
    /// Up to `count` keys will be returned.
    /// If `start_key` is passed, return next keys in storage in lexicographic order.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="count"></param>
    /// <param name="startKey"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<List<StorageKey>> StorageKeysPaged(List<byte> key, uint count, List<byte>? startKey, Hash? hash)
    {
        var res = await client.Request<List<string>>("state_getKeysPaged", RpcClient.RpcParams(key.ToHex(), count, startKey?.ToHex(), hash?.ToHex())).ConfigureAwait(false);
        return res.Select(v => HexUtils.HexToBytes(v).ToList()).ToList();
    }

    /// <summary>
    /// Query historical storage entries
    /// </summary>
    /// <param name="keys"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public async Task<List<StorageChangeSet>> QueryStorage(List<List<byte>> keys, Hash from, Hash? to)
    {
        List<string> keysHashes = keys.Select(k => k.ToHex()!).ToList();
        return await client.Request<List<StorageChangeSet>>("state_queryStorage", RpcClient.RpcParams(keysHashes, from.ToHex(), to?.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Query historical storage entries
    /// </summary>
    /// <param name="keys"></param>
    /// <param name="at"></param>
    /// <returns></returns>
    public async Task<List<StorageChangeSet>> QueryStorageAt(List<List<byte>> keys, Hash? at)
    {
        List<string> keysHashes = keys.Select(k => k.ToHex()!).ToList();
        return await client.Request<List<StorageChangeSet>>("state_queryStorageAt", RpcClient.RpcParams(keysHashes, at?.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Storage subscription.
    /// If storage keys are specified, it creates a message for each block which changes the specified storage keys.
    /// If none are specified, then it creates a message for every block
    /// </summary>
    /// <param name="storageKeys"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Subscription<StorageChangeSet>> SubscribeStorage(IEnumerable<StorageKey>? storageKeys, CancellationToken? cancellationToken = null)
    {
        var parameters = storageKeys?.Select(k => k.ToHex()).ToArray();

#pragma warning disable CS8601 // Possible null reference assignment.
        return await client.Subscribe<StorageChangeSet>(
            "state_subscribeStorage",
            new object[] { parameters },
            "state_unsubscribeStorage",
            cancellationToken
            ).ConfigureAwait(false);
#pragma warning restore CS8601 // Possible null reference assignment.
    }

    /// <summary>
    /// Fetch the genesis hash
    /// </summary>
    /// <returns></returns>
    public async Task<Hash> GenesisHash()
    {
        uint blockZero = 0;
        var parameters = RpcClient.RpcParams(blockZero);

        var genesisHash = await client.Request<Hash>("chain_getBlockHash", parameters).ConfigureAwait(false);
        return genesisHash;
    }

    /// <summary>
    /// Fetch the metadata.
    ///
    /// Now as Raw bytes TODO: make response as Metadata type
    /// </summary>
    /// <returns></returns>
    public async Task<string> Metadata()
    {
        return await client.Request<string>("state_getMetadata", RpcClient.RpcParams()).ConfigureAwait(false);
    }

    /// <summary>
    /// Fetch system properties
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SystemProperties()
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fetch system health
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SystemHealth()
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fetch system chain
    /// </summary>
    /// <returns></returns>
    public async Task<string> SystemChain()
    {
        return await client.Request<string>("system_chain", RpcClient.RpcParams()).ConfigureAwait(false);
    }
    /// <summary>
    /// Fetch system name
    /// </summary>
    /// <returns></returns>
    public async Task<string> SystemName()
    {
        return await client.Request<string>("system_name", RpcClient.RpcParams()).ConfigureAwait(false);
    }
    /// <summary>
    /// Fetch system version
    /// </summary>
    /// <returns></returns>
    public async Task<string> SystemVersion()
    {
        return await client.Request<string>("system_version", RpcClient.RpcParams()).ConfigureAwait(false);
    }

    /// <summary>
    /// Fetch the current nonce for the given account ID.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<ulong> SystemAccountNextIndex(AccountId account)
    {
        return await client.Request<ulong>("system_accountNextIndex", RpcClient.RpcParams(AddressUtils.GetAddressFrom(account.Encode()))).ConfigureAwait(false);
    }

    /// <summary>
    /// Get a header
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<Header> Header(Hash hash)
    {
        return await client.Request<Header>("chain_getHeader", RpcClient.RpcParams(hash.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Get a block hash, returns hash of latest block by default
    /// </summary>
    /// <param name="blockNumber"></param>
    /// <returns></returns>
    public async Task<Hash> BlockHash(BlockNumber? blockNumber)
    {
        return await client.Request<Hash>("chain_getBlockHash", RpcClient.RpcParams(blockNumber?.Value)).ConfigureAwait(false);
    }

    /// <summary>
    /// Get a block hash of the latest finalized block
    /// </summary>
    /// <returns></returns>
    public async Task<Hash> FinalizedHead()
    {
        return await client.Request<Hash>("chain_getFinalizedHead", RpcClient.RpcParams()).ConfigureAwait(false);
    }

    /// <summary>
    /// Get a Block
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<ChainBlockResponse> Block(Hash hash)
    {
        return await client.Request<ChainBlockResponse>("chain_getBlock", RpcClient.RpcParams(hash.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Reexecute the specified `block_hash` and gather statistics while doing so.
    ///
    /// This function requires the specified block and its parent to be available
    /// at the queried node. If either the specified block or the parent is pruned,
    /// this function will return `None`.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="blockHash"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<T> BlockStats<T>(Hash blockHash)
    {
        throw new NotImplementedException();
        return await client.Request<T>("dev_getBlockStats", RpcClient.RpcParams(blockHash.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Get proof of storage entries at a specific block's state.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keys"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<T> ReadProof<T>(List<List<byte>> keys, Hash hash)
    {
        List<string> keysHashes = keys.Select(k => k.ToHex()!).ToList();
        return await client.Request<T>("state_getReadProof", RpcClient.RpcParams(keysHashes, hash.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Fetch the runtime version
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="at"></param>
    /// <returns></returns>
    public async Task<RuntimeVersion> RuntimeVersion(Hash? at)
    {
        return await client.Request<RuntimeVersion>("state_getRuntimeVersion", RpcClient.RpcParams(at?.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to all new best block headers.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<Header>> SubscribeBestBlockHeaders(CancellationToken? cancellationToken = null)
    {
        return await client.Subscribe<Header>(
            // Despite the name, this returns a stream of all new blocks
            // imported by the node that happen to be added to the current best chain
            // (ie all best blocks).
            "chain_subscribeNewHeads",
            RpcClient.RpcParams(),
            "chain_unsubscribeNewHeads",
            cancellationToken
            ).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to all new block headers.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<Header>> SubscribeAllBlockHeaders(CancellationToken? cancellationToken = null)
    {
        return await client.Subscribe<Header>(
            // Despite the name, this returns a stream of all new blocks
            // imported by the node that happen to be added to the current best chain
            // (ie all best blocks).
            "chain_subscribeAllHeads",
            RpcClient.RpcParams(),
            "chain_unsubscribeAllHeads",
            cancellationToken
            ).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to finalized block headers.
    ///
    /// Note: this may not produce _every_ block in the finalized chain;
    /// sometimes multiple blocks are finalized at once, and in this case only the
    /// latest one is returned. the higher level APIs that use this "fill in" the
    /// gaps for us.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<Header>> SubscribeFinalizedBlockHeaders(CancellationToken? cancellationToken = null)
    {
        return await client.Subscribe<Header>(
            "chain_subscribeFinalizedHeads",
            RpcClient.RpcParams(),
            "chain_unsubscribeFinalizedHeads",
            cancellationToken
            ).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to runtime version updates that produce changes in the metadata.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<RuntimeVersion>> SubscribeRuntimeVersion(CancellationToken? cancellationToken = null)
    {
        return await client.Subscribe<RuntimeVersion>(
            "state_subscribeRuntimeVersion",
            RpcClient.RpcParams(),
            "state_unsubscribeRuntimeVersion",
            cancellationToken
            ).ConfigureAwait(false);
    }

    /// <summary>
    /// Create and submit an extrinsic and return corresponding Hash if successful
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="extrinsic"></param>
    /// <returns></returns>
    public async Task<Hash> SubmitExtrinsic(IEnumerable<byte> extrinsic)
    {
        return await client.Request<Hash>("author_submitExtrinsic", RpcClient.RpcParams(extrinsic.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Create and submit an extrinsic and return a subscription to the events triggered.
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="extrinsic"></param>
    /// <returns></returns>
    public async Task<Subscription<SubstrateTxStatus>> WatchExtrinsic(IEnumerable<byte> extrinsic, CancellationToken? cancellationToken = null)
    {
        return await client.Subscribe<SubstrateTxStatus>(
            "author_submitAndWatchExtrinsic",
            RpcClient.RpcParams(extrinsic.ToHex()),
            "author_unwatchExtrinsic",
            cancellationToken
            ).ConfigureAwait(false);
    }

    /// <summary>
    /// Insert a key into the keystore.
    /// </summary>
    /// <param name="keyType"></param>
    /// <param name="suri"></param>
    /// <param name="public_"></param>
    /// <returns></returns>
    public async Task InsertKey(string keyType, Str suri, List<byte> publicKey)
    {
        await client.Request<BaseVoid>("author_insertKey", RpcClient.RpcParams(keyType, suri.ToHex(), publicKey.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Generate new session keys and returns the corresponding public keys.
    /// </summary>
    /// <returns></returns>
    public async Task<byte[]> RotateKeys()
    {
        var resp = await client.Request<Vec<U8>>("author_rotateKeys", RpcClient.RpcParams()).ConfigureAwait(false);
        return resp.Encode();
    }

    /// <summary>
    /// Checks if the keystore has private keys for the given session public keys.
    ///
    /// `session_keys` is the SCALE encoded session keys object from the runtime.
    ///
    /// Returns `true` iff all private keys could be found.
    /// </summary>
    /// <param name="sessionKeys">Hex-serialized shim for Vec u8.</param>
    /// <returns></returns>
    public async Task<bool> HasSessionKeys(Vec<U8> sessionKeys)
    {
        return await client.Request<bool>("author_hasSessionKeys", RpcClient.RpcParams(sessionKeys.ToHex())).ConfigureAwait(false);
    }

    /// <summary>
    /// Checks if the keystore has private keys for the given public key and key type.
    ///
    /// Returns `true` if a private key could be found.
    /// </summary>
    /// <param name="publicKey"></param>
    /// <param name="keyType"></param>
    /// <returns></returns>
    public async Task<bool> HasKey(IEnumerable<byte> publicKey, string keyType)
    {
        return await client.Request<bool>("author_hasKey", RpcClient.RpcParams(publicKey.ToHex(), keyType)).ConfigureAwait(false);
    }

    /// <summary>
    /// Submits the extrinsic to the dry_run RPC, to test if it would succeed.
    ///
    /// Returns `Ok` with an [`ApplyExtrinsicResult`], which is the result of applying of an extrinsic.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="encodedSigned"></param>
    /// <param name="at"></param>
    /// <returns></returns>
    public async Task<ApplyExtrinsicResult> DryRun(IEnumerable<byte> encodedSigned, Hash? at)
    {
        return await client.Request<ApplyExtrinsicResult>("system_dryRun", RpcClient.RpcParams(encodedSigned.ToHex(), at?.ToHex())).ConfigureAwait(false);
    }

    public async Task Unsubscribe<TResult>(Subscription<TResult> subscription)
    {
        await client.Unsubscribe(subscription).ConfigureAwait(false);
    }

    public void Dispose()
    {
        client.Dispose();
        GC.SuppressFinalize(this);
    }
}

