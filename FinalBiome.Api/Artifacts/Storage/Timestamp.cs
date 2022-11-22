///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.TimestampEntries;
public class Timestamp
{
    readonly Client client;
    public Timestamp(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  Current time for the current block.<br/>
    /// </summary>
    public Now Now()
    {
        return new Now(client);
    }

    /// <summary>
    ///  Did the timestamp get updated in this block?<br/>
    /// </summary>
    public DidUpdate DidUpdate()
    {
        return new DidUpdate(client);
    }

}

