///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class Number : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  The current block number being processed. Set by `execute_block`.<br/>
    /// </summary>
    public Number(Client client) :
        base(client, "System", "Number")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

