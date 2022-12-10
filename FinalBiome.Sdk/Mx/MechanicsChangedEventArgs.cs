
using FinalBiome.Api.Types.PalletMechanics.Types;

namespace FinalBiome.Sdk;

/// <summary>
/// Event args of changing of some active mechanics
/// </summary>
public class MechanicsChangedEventArgs : EventArgs
{
    /// <summary>
    /// Id of the changed mechanics
    /// </summary>
    public MxId Id;

    /// <summary>
    /// New details of Nfa instance.<br/>
    /// If null - Nfa instance has been removed.
    /// </summary>
    public MechanicDetails? Details;

    public MechanicsChangedEventArgs(MxId id, MechanicDetails? details)
    {
        Id = id;
        Details = details;
    }
}
