///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.FrameSystem.LastRuntimeUpgradeInfo?> LastRuntimeUpgrade(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "LastRuntimeUpgrade", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.FrameSystem.LastRuntimeUpgradeInfo>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.FrameSystem.LastRuntimeUpgradeInfo?> LastRuntimeUpgradeSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "LastRuntimeUpgrade", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.FrameSystem.LastRuntimeUpgradeInfo>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

