///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class FungibleAssets
{
    /// <summary>
    ///  Storing next asset id<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId?> NextAssetId(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "NextAssetId", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Storing next asset id<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId?> NextAssetIdSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "NextAssetId", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

