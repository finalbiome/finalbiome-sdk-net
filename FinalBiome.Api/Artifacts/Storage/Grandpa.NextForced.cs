///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.GrandpaEntries;
public class NextForced : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  next block number where we can force a change.<br/>
    /// </summary>
    public NextForced(Client client) :
        base(client, "Grandpa", "NextForced")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

