///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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

