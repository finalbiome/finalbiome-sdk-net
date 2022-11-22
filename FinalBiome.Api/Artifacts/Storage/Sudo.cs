///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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

