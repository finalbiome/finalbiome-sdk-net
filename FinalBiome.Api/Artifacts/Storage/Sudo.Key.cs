///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SudoEntries;
public class Key : StorageEntry<FinalBiome.Api.Types.SpCore.Crypto.AccountId32>
{
    /// <summary>
    ///  The `AccountId` of the sudo key.<br/>
    /// </summary>
    public Key(Client client) :
        base(client, "Sudo", "Key")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

