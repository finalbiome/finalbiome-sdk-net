using System.Threading;
using FinalBiome.Api.Rpc;

namespace FinalBiome.Api.Blocks;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class BlocksClient
{
    readonly Client client;

    public BlocksClient(Client client)
    {
        this.client = client;
    }

    public async Task<Block> At(Hash? blockHash = null)
    {
        // If block hash is not provided, get the hash
        // for the latest block and use that.
        Hash hash;
        if (blockHash is not null) hash = blockHash;
        else
        {
            hash = await client.Rpc.BlockHash(null);
        }

        Header header = await client.Rpc.Header(hash);
        if (header.Digest is null) throw new BlockHashNotFoundException(hash);

        return new Block(header, client);
    }

    /// <summary>
    /// Subscribe to finalized blocks.
    /// </summary>
    /// <returns></returns>
    /// <example>
    /// <code>
    /// var sub = client.Blocks.SubscribeFinalized(cancellationToken);
    /// await foreach (var block in sub)
    ///     {
    ///         Console.WriteLine($"Fin block: {block.Hash.ToHex()}\n");
    ///         // Ask for the events for this block.
    ///         var events = await block.Events();
    ///         if (events.EventRecords is not null)
    ///         {
    ///             Console.WriteLine($"Events in the block: {block.Hash.ToHex()}\n");
    /// 
    ///             foreach (var ev in events.EventRecords.Value)
    ///             {
    ///                 Console.WriteLine($"Event: {Stringify(ev, Formatting.None)}");
    ///             }
    ///         }
    ///     }
    /// </code>
    /// </example>
    public async IAsyncEnumerable<Block> SubscribeFinalized(CancellationToken? cancellationToken = null)
    {
        // Fetch the last finalised block details immediately, so that we'll get
        // all blocks after this one.
        // -- it will be need when and maybe we'll implement a next task - Adjust the subscription stream to fill in any missing blocks.
        //var lastFinalizedBlockHash = await client.Rpc.FinalizedHead();
        //var lastFinalizedBlockHeader = await client.Rpc.Header(lastFinalizedBlockHash);
        //var lastFinalizedBlockNum = lastFinalizedBlockHeader.Number;

        var sub = await client.Rpc.SubscribeFinalizedBlockHeaders(cancellationToken);

        await foreach (var header in sub.data())
        {
            Block block = new Block(header, this.client);
            yield return block;
        }
        // TODO: Adjust the subscription stream to fill in any missing blocks.
    }
}

