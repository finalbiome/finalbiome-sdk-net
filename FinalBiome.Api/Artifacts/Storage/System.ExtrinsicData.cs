///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class ExtrinsicData : StorageEntry<FinalBiome.Api.Types.VecU8>
{
    /// <summary>
    ///  Extrinsics data for the current block (maps an extrinsic's index to its data).<br/>
    /// </summary>
    public ExtrinsicData(Client client, FinalBiome.Api.Types.Primitive.U32 u32) :
        base(client, "System", "ExtrinsicData")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
