///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.AuraEntries;
public class Aura
{
    readonly Client client;
    public Aura(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  The current authority set.<br/>
    /// </summary>
    public Authorities Authorities()
    {
        return new Authorities(client);
    }

    /// <summary>
    ///  The current slot of this block.<br/>
    /// <para></para>
    ///  This will be set in `on_initialize`.<br/>
    /// </summary>
    public CurrentSlot CurrentSlot()
    {
        return new CurrentSlot(client);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
