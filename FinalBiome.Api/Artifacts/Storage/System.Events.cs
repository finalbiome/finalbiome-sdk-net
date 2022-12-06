///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class Events : StorageEntry<FinalBiome.Api.Types.FrameSystem.VecEventRecord>
{
    /// <summary>
    ///  Events deposited for the current block.<br/>
    /// <para></para>
    ///  NOTE: The item is unbound and should therefore never be read on chain.<br/>
    ///  It could otherwise inflate the PoV size of a block.<br/>
    /// <para></para>
    ///  Events have a large in-memory size. Box the events to not go out-of-memory<br/>
    ///  just in case someone still reads them from within the runtime.<br/>
    /// </summary>
    public Events(Client client) :
        base(client, "System", "Events")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
