using System;
using FinalBiome.Api.Types.PrimitiveTypes;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Rpc;

using Index = U32;
using AccountId = FinalBiome.Api.Types.SpCore.Crypto.AccountId32;
using Hash = H256;
using BlockNumber = U32;

/// <summary>
/// Client for substrate rpc interfaces
/// </summary>
public class Rpc
{
    RpcClient client;
    /// <summary>
    /// Create a new [`Rpc`]
    /// </summary>
    /// <param name="client"></param>
    public Rpc(RpcClient client)
    {
        this.client = client;
    }

    /// <summary>
    /// Fetch the genesis hash
    /// </summary>
    /// <returns></returns>
    public async Task<Hash> GenesisHash()
    {
        uint blockZero = 0;
        var parameters = RpcClient.RpcParams(blockZero);

        var genesisHash = await client.Request<Hash>("chain_getBlockHash", parameters);
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
        return await client.Request<string>("state_getMetadata", RpcClient.RpcParams());
    }

    /// <summary>
    /// Fetch system properties
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task System_Properties()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fetch system health
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SystemHealth()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fetch system chain
    /// </summary>
    /// <returns></returns>
    public async Task<string> SystemChain()
    {
        return await client.Request<string>("system_chain", RpcClient.RpcParams());
    }
    /// <summary>
    /// Fetch system name
    /// </summary>
    /// <returns></returns>
    public async Task<string> SystemName()
    {
        return await client.Request<string>("system_name", RpcClient.RpcParams());
    }
    /// <summary>
    /// Fetch system version
    /// </summary>
    /// <returns></returns>
    public async Task<string> SystemVersion()
    {
        return await client.Request<string>("system_version", RpcClient.RpcParams());
    }

    /// <summary>
    /// Fetch the current nonce for the given account ID.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Index> SystemAccountNextIndex(AccountId account)
    {
        return await client.Request<Index>("system_accountNextIndex", RpcClient.RpcParams(account));
    }

    /// <summary>
    /// Get a header
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<Header> Header(Hash hash)
    {
        return await client.Request<Header>("chain_getHeader", RpcClient.RpcParams(hash.ToHex()));
    }

    /// <summary>
    /// Get a block hash, returns hash of latest block by default
    /// </summary>
    /// <param name="blockNumber"></param>
    /// <returns></returns>
    public async Task<Hash> BlockHash(BlockNumber blockNumber)
    {
        
        return await client.Request<Hash>("chain_getBlockHash", RpcClient.RpcParams(blockNumber.Value));
    }

    /// <summary>
    /// Get a block hash of the latest finalized block
    /// </summary>
    /// <returns></returns>
    public async Task<Hash> FinalizedHead()
    {
        return await client.Request<Hash>("chain_getFinalizedHead", RpcClient.RpcParams());
    }

    /// <summary>
    /// Get a Block
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<ChainBlockResponse> Block(Hash hash)
    {
        return await client.Request<ChainBlockResponse>("chain_getBlock", RpcClient.RpcParams(hash.ToHex()));
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
        return await client.Request<T>("dev_getBlockStats", RpcClient.RpcParams(blockHash.ToHex()));
    }

    /// <summary>
    /// Get proof of storage entries at a specific block's state.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keys"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<T> ReadProof<T>(Vec<U8> keys, Hash hash)
    {
        throw new NotImplementedException();
        return await client.Request<T>("state_getReadProof", RpcClient.RpcParams(keys.ToHex(), hash.ToHex()));
    }

    /// <summary>
    /// Fetch the runtime version
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="at"></param>
    /// <returns></returns>
    public async Task<RuntimeVersion> RuntimeVersion(Hash? at)
    {
        string? hexHash = null;
        if (at is not null) hexHash = at.ToHex();
        return await client.Request<RuntimeVersion>("state_getRuntimeVersion", RpcClient.RpcParams(hexHash));
    }

    /// <summary>
    /// Subscribe to all new best block headers.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<Header>> SubscribeBestBlockHeaders()
    {
        return await client.Subscribe<Header>(
            // Despite the name, this returns a stream of all new blocks
            // imported by the node that happen to be added to the current best chain
            // (ie all best blocks).
            "chain_subscribeNewHeads",
            RpcClient.RpcParams(),
            "chain_unsubscribeNewHeads"
            );
    }

    /// <summary>
    /// Subscribe to all new block headers.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<Header>> SubscribeAllBlockHeaders()
    {
        return await client.Subscribe<Header>(
            // Despite the name, this returns a stream of all new blocks
            // imported by the node that happen to be added to the current best chain
            // (ie all best blocks).
            "chain_subscribeAllHeads",
            RpcClient.RpcParams(),
            "chain_unsubscribeAllHeads"
            );
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
    public async Task<Subscription<Header>> SubscribeFinalizedBlockHeaders()
    {
        return await client.Subscribe<Header>(
            "chain_subscribeFinalizedHeads",
            RpcClient.RpcParams(),
            "chain_unsubscribeFinalizedHeads"
            );
    }

    /// <summary>
    /// Subscribe to runtime version updates that produce changes in the metadata.
    /// </summary>
    /// <returns></returns>
    public async Task<Subscription<RuntimeVersion>> SubscribeRuntimeVersion()
    {
        return await client.Subscribe<RuntimeVersion>(
            "state_subscribeRuntimeVersion",
            RpcClient.RpcParams(),
            "state_unsubscribeRuntimeVersion"
            );
    }

    /// <summary>
    /// Create and submit an extrinsic and return corresponding Hash if successful
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="extrinsic"></param>
    /// <returns></returns>
    public async Task<Hash> SubmitExtrinsic<T>(T extrinsic) where T : Codec
    {
        return await client.Request<Hash>("author_submitExtrinsic", RpcClient.RpcParams(extrinsic));
    }

    /// <summary>
    /// Create and submit an extrinsic and return a subscription to the events triggered.
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="extrinsic"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Subscription<T>> WatchExtrinsic<X, T>(T extrinsic) where T : Codec where X : Codec
    {
        throw new NotImplementedException();
        return await client.Subscribe<T>(
            "author_submitAndWatchExtrinsic",
            RpcClient.RpcParams(extrinsic),
            "author_unwatchExtrinsic"
            );
    }

    /// <summary>
    /// Insert a key into the keystore.
    /// </summary>
    /// <param name="keyType"></param>
    /// <param name="suri"></param>
    /// <param name="public_"></param>
    /// <returns></returns>
    public async Task InsertKey(string keyType, string suri, byte[] public_ )
    {
        await client.Request<BaseVoid>("author_insertKey", RpcClient.RpcParams(keyType, suri, public_));
    }

    /// <summary>
    /// Generate new session keys and returns the corresponding public keys.
    /// </summary>
    /// <returns></returns>
    public async Task<byte[]> RotateKeys()
    {
        var resp = await client.Request<Vec<U8>>("author_rotateKeys", RpcClient.RpcParams());
        return resp.Encode();
    }

    /// <summary>
    /// Checks if the keystore has private keys for the given session public keys.
    ///
    /// `session_keys` is the SCALE encoded session keys object from the runtime.
    ///
    /// Returns `true` iff all private keys could be found.
    /// </summary>
    /// <param name="sessionKeys"></param>
    /// <returns></returns>
    public async Task<bool> HasSessionKeys(byte[] sessionKeys)
    {
        return await client.Request<bool>("author_hasSessionKeys", RpcClient.RpcParams(sessionKeys));
    }

    /// <summary>
    /// Checks if the keystore has private keys for the given public key and key type.
    ///
    /// Returns `true` if a private key could be found.
    /// </summary>
    /// <param name="publicKey"></param>
    /// <param name="keyType"></param>
    /// <returns></returns>
    public async Task<bool> HasKey(byte[] publicKey, string keyType)
    {
        return await client.Request<bool>("author_hasKey", RpcClient.RpcParams(publicKey, keyType));
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
    /// <exception cref="NotImplementedException"></exception>
    public async Task<T> DryRun<T>(Vec<U8> encodedSigned, Hash at) where T : Codec
    {
        throw new NotImplementedException();
        return await client.Request<T>("system_dryRun", RpcClient.RpcParams(encodedSigned.ToHex(), at.ToHex()));
    }




}

