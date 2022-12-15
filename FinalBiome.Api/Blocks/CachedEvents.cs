
namespace FinalBiome.Api.Blocks;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

/// <summary>
/// Acquire lock on the events cache. We either get back our events or we fetch and set them
/// before unlocking, so only one fetch call should ever be made. We do this because the
/// same events can be shared across all extrinsics in the block.
/// </summary>
public class CachedEvents
{
    private Events.Events? cachedEvents = null;

    public async Task<Events.Events> GetEvents(
        Client client,
        Hash blockHash)
    {
        if (this.cachedEvents is null)
        {
            Events.EventsClient ev = new Events.EventsClient(client);
            this.cachedEvents = await ev.At(blockHash).ConfigureAwait(false);
        }

        return cachedEvents;
    }
}

