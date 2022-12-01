namespace FinalBiome.Sdk;

using NfaClassId = UInt32;
using NfaInstanceId = UInt32;

public class NfaInstanceNotFoundException : Exception
{
    public NfaInstanceNotFoundException(NfaClassId classId, NfaInstanceId instanceId) : base(MessageFactory(classId, instanceId))
    {

    }

    static string MessageFactory(NfaClassId classId, NfaInstanceId instanceId)
    {
        return $"Nfa Instance not found. Class id {classId}, Instance id {instanceId}";
    }
}
