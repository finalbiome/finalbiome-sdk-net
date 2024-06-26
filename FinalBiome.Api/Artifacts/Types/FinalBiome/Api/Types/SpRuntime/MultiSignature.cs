///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 207
    /// </summary>
    public enum InnerMultiSignature : byte
    {
        Ed25519 = 0,
        Sr25519 = 1,
        Ecdsa = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 207
    /// </summary>
    public class MultiSignature : Enum<InnerMultiSignature, FinalBiome.Api.Types.SpCore.Ed25519.Signature, FinalBiome.Api.Types.SpCore.Sr25519.Signature, FinalBiome.Api.Types.SpCore.Ecdsa.Signature>
    {
        public override string TypeName() => "MultiSignature";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
