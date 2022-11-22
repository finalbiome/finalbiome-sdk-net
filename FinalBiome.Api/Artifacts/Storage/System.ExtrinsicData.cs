///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  Extrinsics data for the current block (maps an extrinsic's index to its data).<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.VecU8?> ExtrinsicData(FinalBiome.Api.Types.Primitive.U32 u32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "ExtrinsicData", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.VecU8>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Extrinsics data for the current block (maps an extrinsic's index to its data).<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.VecU8?> ExtrinsicDataSubscribe(FinalBiome.Api.Types.Primitive.U32 u32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "ExtrinsicData", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.VecU8>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

