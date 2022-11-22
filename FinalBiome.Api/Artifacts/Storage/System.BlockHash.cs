///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class BlockHash : StorageEntry<FinalBiome.Api.Types.PrimitiveTypes.H256>
{
    /// <summary>
    ///  Map of block numbers to block hashes.<br/>
    /// </summary>
    public BlockHash(Client client, FinalBiome.Api.Types.Primitive.U32 u32) :
        base(client, "System", "BlockHash")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

