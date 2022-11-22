///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.GrandpaEntries;
public class CurrentSetId : StorageEntry<FinalBiome.Api.Types.Primitive.U64>
{
    /// <summary>
    ///  The number of changes (both in terms of keys and underlying economic responsibilities)<br/>
    ///  in the "set" of Grandpa validators from genesis.<br/>
    /// </summary>
    public CurrentSetId(Client client) :
        base(client, "Grandpa", "CurrentSetId")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

