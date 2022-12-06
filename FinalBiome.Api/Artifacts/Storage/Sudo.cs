///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.SudoEntries;
public class Sudo
{
    readonly Client client;
    public Sudo(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  The `AccountId` of the sudo key.<br/>
    /// </summary>
    public Key Key()
    {
        return new Key(client);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
