///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
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
    public async Task<FinalBiome.Api.Types.FrameSystem.VecEventRecord?> Events(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "Events", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.FrameSystem.VecEventRecord>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Events deposited for the current block.<br/>
    /// <para></para>
    ///  NOTE: The item is unbound and should therefore never be read on chain.<br/>
    ///  It could otherwise inflate the PoV size of a block.<br/>
    /// <para></para>
    ///  Events have a large in-memory size. Box the events to not go out-of-memory<br/>
    ///  just in case someone still reads them from within the runtime.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.FrameSystem.VecEventRecord?> EventsSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "Events", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.FrameSystem.VecEventRecord>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

