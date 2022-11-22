///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class ParentHash : StorageEntry<FinalBiome.Api.Types.PrimitiveTypes.H256>
{
    /// <summary>
    ///  Hash of the previous block.<br/>
    /// </summary>
    public ParentHash(Client client) :
        base(client, "System", "ParentHash")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

