///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Grandpa
{
    /// <summary>
    ///  A mapping from grandpa set ID to the index of the *most recent* session for which its<br/>
    ///  members were responsible.<br/>
    /// <para></para>
    ///  TWOX-NOTE: `SetId` is not under user control.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U32?> SetIdSession(FinalBiome.Api.Types.Primitive.U64 u64, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u64, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "SetIdSession", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U32>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  A mapping from grandpa set ID to the index of the *most recent* session for which its<br/>
    ///  members were responsible.<br/>
    /// <para></para>
    ///  TWOX-NOTE: `SetId` is not under user control.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U32?> SetIdSessionSubscribe(FinalBiome.Api.Types.Primitive.U64 u64, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u64, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "SetIdSession", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

