///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
