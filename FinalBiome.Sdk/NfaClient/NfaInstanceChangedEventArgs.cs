namespace FinalBiome.Sdk;

using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using NfaInstanceDetails = Api.Types.PalletSupport.TypesNfa.AssetDetails;

/// <summary>
/// Event args of changing details of some non-fungible instance
/// </summary>
public class NfaInstanceChangedEventArgs : EventArgs
{
    /// <summary>
    /// Id of the changed class
    /// </summary>
    public NfaClassId classId;

    /// <summary>
    /// Id of the changed instance
    /// </summary>
    public NfaInstanceId instanceId;

    /// <summary>
    /// New details of Nfa instance.<br/>
    /// If null - Nfa instance has been removed.
    /// </summary>
    public NfaInstanceDetails? details;

    public NfaInstanceChangedEventArgs(NfaClassId classId, NfaInstanceId instanceId, NfaInstanceDetails? details)
    {
        this.classId = classId;
        this.instanceId = instanceId;
        this.details = details;
    }
}
