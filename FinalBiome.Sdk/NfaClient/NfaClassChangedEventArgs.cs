namespace FinalBiome.Sdk;

using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using NfaClassDetails = Api.Types.PalletSupport.TypesNfa.ClassDetails;

/// <summary>
/// Event args of changing details of some non-fungible asset's class
/// </summary>
public class NfaClassChangedEventArgs : EventArgs
{
    /// <summary>
    /// Id of the changed class
    /// </summary>
    public NfaClassId classId;

    /// <summary>
    /// New details of Nfa.<br/>
    /// If null - Nfa class has been removed.
    /// </summary>
    public NfaClassDetails? details;

    public NfaClassChangedEventArgs(uint classId, NfaClassDetails? details)
    {
        this.classId = classId;
        this.details = details;
    }
}
