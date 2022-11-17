using System;
using FinalBiome.Api;

namespace FinalBiome.Api.Events;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

/// <summary>
/// A client for working with events.
/// </summary>
public class EventsClient
{
    readonly Client client;

    public EventsClient(Client client)
    {
        this.client = client;
    }

    /// <summary>
    /// /// Obtain events at some block hash.
    ///
    /// # Warning
    ///
    /// This call only supports blocks produced since the most recent
    /// runtime upgrade. You can attempt to retrieve events from older blocks,
    /// but may run into errors attempting to work with them.
    /// </summary>
    /// <param name="blockHash"></param>
    public async Task<Events> At(Hash? blockHash = null)
    {
        Hash hash;
        // If block hash is not provided, get the hash
        // for the latest block and use that.
        if (blockHash is not null) hash = blockHash;
        else
        {
            hash = await client.Rpc.BlockHash(null);
        }

        var events = await client.Storage.System.Events(hash.Encode());

        return new Events(hash, events);
    }
}

