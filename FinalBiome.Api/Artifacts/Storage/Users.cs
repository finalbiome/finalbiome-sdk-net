///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.UsersEntries;
public class Users
{
    readonly Client client;
    public Users(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  The `AccountId` of the Registrar key.<br/>
    /// </summary>
    public RegistrarKey RegistrarKey()
    {
        return new RegistrarKey(client);
    }

    /// <summary>
    ///  Accounts which quotas should be restored when will be active specific slot.<br/>
    /// </summary>
    public Slots Slots(FinalBiome.Api.Types.Primitive.U32 u32)
    {
        return new Slots(client, u32);
    }

    /// <summary>
    ///  Lookup from an account to the slot number.<br/>
    /// </summary>
    public SlotsLookup SlotsLookup(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new SlotsLookup(client, accountId32);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
