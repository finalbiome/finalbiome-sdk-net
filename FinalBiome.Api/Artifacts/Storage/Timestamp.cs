///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
