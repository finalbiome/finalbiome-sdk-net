namespace FinalBiome.Sdk;

using NfaClassId = UInt32;

public class NfaClassNotFoundException : Exception
{
    public NfaClassNotFoundException(NfaClassId classId) : base(MessageFactory(classId))
    {

    }

    static string MessageFactory(NfaClassId classId)
    {
        return $"Nfa Class not found. Id {classId}";
    }
}
