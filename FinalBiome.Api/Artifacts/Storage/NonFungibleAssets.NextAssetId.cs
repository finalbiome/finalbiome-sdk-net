///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class NonFungibleAssets
{
    /// <summary>
    ///  Storing the next asset id<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId?> NextAssetId(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "NextAssetId", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Storing the next asset id<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId?> NextAssetIdSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "NextAssetId", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

