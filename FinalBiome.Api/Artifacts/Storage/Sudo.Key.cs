///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Sudo
{
    /// <summary>
    ///  The `AccountId` of the sudo key.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.SpCore.Crypto.AccountId32?> Key(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Sudo", "Key", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.SpCore.Crypto.AccountId32>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The `AccountId` of the sudo key.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.SpCore.Crypto.AccountId32?> KeySubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Sudo", "Key", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.SpCore.Crypto.AccountId32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

