
using FinalBiome.Api.Types.PalletMechanics.Types;

namespace FinalBiome.Sdk;

/// <summary>
/// Event args of dropping by timeout of some active mechanics.
/// </summary>
public class MechanicsDroppedEventArgs : EventArgs
{
    /// <summary>
    /// Id of the dropped mechanics
    /// </summary>
    public MxId Id;

    public MechanicsDroppedEventArgs(MxId id)
    {
        Id = id;
    }
}
