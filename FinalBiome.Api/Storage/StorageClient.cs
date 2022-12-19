using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Storage;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

/// <summary>
/// Query the runtime storage.
/// </summary>
public partial class StorageClient
{
    /// <summary>
    /// Fetch the encoded data value at the address/key given.
    /// </summary>
    /// <typeparam name="TResuls"></typeparam>
    /// <param name="key"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<string?> FetchRaw(List<byte> key, IEnumerable<byte>? hash)
    {
        Hash? decodedHash = new();
        if (hash is not null) decodedHash.Init(hash.ToArray());
        else decodedHash = null;
        return await client.Rpc.Storage<string>(key, decodedHash).ConfigureAwait(false);
    }

    /// <summary>
    /// Fetch a decoded value from storage at a given address and optional block hash.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="address"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<TResult?> Fetch<TResult>(StorageAddress address, IEnumerable<byte>? hash) where TResult : Codec, new()
    {
        var lookupBytes = StorageUtils.StorageAddressBytes(address);
        var raw = await client.Storage.FetchRaw(lookupBytes, hash).ConfigureAwait(false);
        if (raw is null || raw.Length == 0) return null;
        TResult result = new();
        result.Init(raw);
        return result;
    }

    /// <summary>
    /// Fetch up to `count` keys for a storage map in lexicographic order.
    ///
    /// Supports pagination by passing a value to `start_key`.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="count"></param>
    /// <param name="startKey"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public async Task<List<List<byte>>> FetchKeys(List<byte> queryKey, uint count, List<byte>? startKey, IEnumerable<byte>? hash)
    {
        Hash? decodedHash = new();
        if (hash is not null) decodedHash.Init(hash.ToArray());
        else decodedHash = null;
        return await client.Rpc.StorageKeysPaged(queryKey, count, startKey, decodedHash).ConfigureAwait(false);
    }

    /// <summary>
    /// Storage subscription. It creates a message for each block which changes the specified storage keys.
    ///
    /// **Note** <typeparamref name="TResult"/> must be match of the storage value type, otherwise error will happen
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="key"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async IAsyncEnumerable<TResult?> SubscribeStorage<TResult>(StorageAddress address, CancellationToken? cancellationToken = null) where TResult : Codec, new()
    {
        List<byte> lookupBytes = StorageUtils.StorageAddressBytes(address);
        var sub = await client.Rpc.SubscribeStorage(new List<byte>[] { lookupBytes }, cancellationToken).ConfigureAwait(false);
        CancellationToken ct = cancellationToken ?? default;
        try
        {
            await foreach (var changeSet in sub.data(ct).ConfigureAwait(false))
            {
                foreach (var change in changeSet.Changes)
                {
                    if (!Enumerable.SequenceEqual(change.StorageKey, lookupBytes))
                        throw new Exception("Unexpected key found in the storage change set ");
                    if (change.StorageValue is not null)
                    {
                        TResult value = new();
                        value.InitFromHex(hexString: change.StorageValue);
                        yield return value;
                    }
                    else
                    {
                        yield return null;
                    }
                }
            }
        }
        finally
        {
            // from listen loop we exit only if cancellation occurs
            // unsubscribe from subscription on the network
            await client.Rpc.Unsubscribe(sub).ConfigureAwait(false);
        }
    }
}

