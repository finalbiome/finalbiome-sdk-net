///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.GrandpaEntries;
public class State : StorageEntry<FinalBiome.Api.Types.PalletGrandpa.StoredState>
{
    /// <summary>
    ///  State of the current authority set.<br/>
    /// </summary>
    public State(Client client) :
        base(client, "Grandpa", "State")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

