///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class NonFungibleAssets
{
    /// <summary>
    ///  Storing the next class id<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId?> NextClassId(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "NextClassId", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Storing the next class id<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId?> NextClassIdSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "NextClassId", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

