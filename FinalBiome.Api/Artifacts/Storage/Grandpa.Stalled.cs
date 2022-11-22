///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.GrandpaEntries;
public class Stalled : StorageEntry<FinalBiome.Api.Types.Tuple_U32_U32>
{
    /// <summary>
    ///  `true` if we are currently stalled.<br/>
    /// </summary>
    public Stalled(Client client) :
        base(client, "Grandpa", "Stalled")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

