///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.GrandpaEntries;
public class PendingChange : StorageEntry<FinalBiome.Api.Types.PalletGrandpa.StoredPendingChange>
{
    /// <summary>
    ///  Pending change: (signaled at, scheduled change).<br/>
    /// </summary>
    public PendingChange(Client client) :
        base(client, "Grandpa", "PendingChange")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

