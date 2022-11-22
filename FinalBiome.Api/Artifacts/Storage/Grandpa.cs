///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.GrandpaEntries;
public class Grandpa
{
    readonly Client client;
    public Grandpa(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  State of the current authority set.<br/>
    /// </summary>
    public State State()
    {
        return new State(client);
    }

    /// <summary>
    ///  Pending change: (signaled at, scheduled change).<br/>
    /// </summary>
    public PendingChange PendingChange()
    {
        return new PendingChange(client);
    }

    /// <summary>
    ///  next block number where we can force a change.<br/>
    /// </summary>
    public NextForced NextForced()
    {
        return new NextForced(client);
    }

    /// <summary>
    ///  `true` if we are currently stalled.<br/>
    /// </summary>
    public Stalled Stalled()
    {
        return new Stalled(client);
    }

    /// <summary>
    ///  The number of changes (both in terms of keys and underlying economic responsibilities)<br/>
    ///  in the "set" of Grandpa validators from genesis.<br/>
    /// </summary>
    public CurrentSetId CurrentSetId()
    {
        return new CurrentSetId(client);
    }

    /// <summary>
    ///  A mapping from grandpa set ID to the index of the *most recent* session for which its<br/>
    ///  members were responsible.<br/>
    /// <para></para>
    ///  TWOX-NOTE: `SetId` is not under user control.<br/>
    /// </summary>
    public SetIdSession SetIdSession(FinalBiome.Api.Types.Primitive.U64 u64)
    {
        return new SetIdSession(client, u64);
    }

}

