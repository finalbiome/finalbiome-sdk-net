///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  The full account information for a particular account ID.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.FrameSystem.AccountInfo?> Account(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "Account", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.FrameSystem.AccountInfo>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The full account information for a particular account ID.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.FrameSystem.AccountInfo?> AccountSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "Account", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.FrameSystem.AccountInfo>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

