///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class Digest : StorageEntry<FinalBiome.Api.Types.SpRuntime.Generic.Digest.Digest>
{
    /// <summary>
    ///  Digest of the current block, also part of the block header.<br/>
    /// </summary>
    public Digest(Client client) :
        base(client, "System", "Digest")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

