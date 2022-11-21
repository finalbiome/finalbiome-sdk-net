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
}
