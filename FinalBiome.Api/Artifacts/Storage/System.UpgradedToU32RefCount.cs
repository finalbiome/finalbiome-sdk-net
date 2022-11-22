///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.Bool?> UpgradedToU32RefCount(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "UpgradedToU32RefCount", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.Bool>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.Bool?> UpgradedToU32RefCountSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "UpgradedToU32RefCount", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.Bool>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

