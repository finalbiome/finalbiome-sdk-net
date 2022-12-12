///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.SystemEntries;
public class System
{
    readonly Client client;
    public System(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  The full account information for a particular account ID.<br/>
    /// </summary>
    public Account Account(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new Account(client, accountId32);
    }

    /// <summary>
    ///  Total extrinsics count for the current block.<br/>
    /// </summary>
    public ExtrinsicCount ExtrinsicCount()
    {
        return new ExtrinsicCount(client);
    }

    /// <summary>
    ///  The current weight for the block.<br/>
    /// </summary>
    public BlockWeight BlockWeight()
    {
        return new BlockWeight(client);
    }

    /// <summary>
    ///  Total length (in bytes) for all extrinsics put together, for the current block.<br/>
    /// </summary>
    public AllExtrinsicsLen AllExtrinsicsLen()
    {
        return new AllExtrinsicsLen(client);
    }

    /// <summary>
    ///  Map of block numbers to block hashes.<br/>
    /// </summary>
    public BlockHash BlockHash(FinalBiome.Api.Types.Primitive.U32 u32)
    {
        return new BlockHash(client, u32);
    }

    /// <summary>
    ///  Extrinsics data for the current block (maps an extrinsic's index to its data).<br/>
    /// </summary>
    public ExtrinsicData ExtrinsicData(FinalBiome.Api.Types.Primitive.U32 u32)
    {
        return new ExtrinsicData(client, u32);
    }

    /// <summary>
    ///  The current block number being processed. Set by `execute_block`.<br/>
    /// </summary>
    public Number Number()
    {
        return new Number(client);
    }

    /// <summary>
    ///  Hash of the previous block.<br/>
    /// </summary>
    public ParentHash ParentHash()
    {
        return new ParentHash(client);
    }

    /// <summary>
    ///  Digest of the current block, also part of the block header.<br/>
    /// </summary>
    public Digest Digest()
    {
        return new Digest(client);
    }

    /// <summary>
    ///  Events deposited for the current block.<br/>
    /// <para></para>
    ///  NOTE: The item is unbound and should therefore never be read on chain.<br/>
    ///  It could otherwise inflate the PoV size of a block.<br/>
    /// <para></para>
    ///  Events have a large in-memory size. Box the events to not go out-of-memory<br/>
    ///  just in case someone still reads them from within the runtime.<br/>
    /// </summary>
    public Events Events()
    {
        return new Events(client);
    }

    /// <summary>
    ///  The number of events in the `Events&lt;T&gt;` list.<br/>
    /// </summary>
    public EventCount EventCount()
    {
        return new EventCount(client);
    }

    /// <summary>
    ///  Mapping between a topic (represented by T::Hash) and a vector of indexes<br/>
    ///  of events in the `&lt;Events&lt;T&gt;&gt;` list.<br/>
    /// <para></para>
    ///  All topic vectors have deterministic storage locations depending on the topic. This<br/>
    ///  allows light-clients to leverage the changes trie storage tracking mechanism and<br/>
    ///  in case of changes fetch the list of events of interest.<br/>
    /// <para></para>
    ///  The value has the type `(T::BlockNumber, EventIndex)` because if we used only just<br/>
    ///  the `EventIndex` then in case if the topic has the same contents on the next block<br/>
    ///  no notification will be triggered thus the event might be lost.<br/>
    /// </summary>
    public EventTopics EventTopics(FinalBiome.Api.Types.PrimitiveTypes.H256 h256)
    {
        return new EventTopics(client, h256);
    }

    /// <summary>
    ///  Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.<br/>
    /// </summary>
    public LastRuntimeUpgrade LastRuntimeUpgrade()
    {
        return new LastRuntimeUpgrade(client);
    }

    /// <summary>
    ///  True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.<br/>
    /// </summary>
    public UpgradedToU32RefCount UpgradedToU32RefCount()
    {
        return new UpgradedToU32RefCount(client);
    }

    /// <summary>
    ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False<br/>
    ///  (default) if not.<br/>
    /// </summary>
    public UpgradedToTripleRefCount UpgradedToTripleRefCount()
    {
        return new UpgradedToTripleRefCount(client);
    }

    /// <summary>
    ///  The execution phase of the block.<br/>
    /// </summary>
    public ExecutionPhase ExecutionPhase()
    {
        return new ExecutionPhase(client);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
