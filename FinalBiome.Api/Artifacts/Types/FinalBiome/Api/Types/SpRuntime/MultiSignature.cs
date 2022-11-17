///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 201
    /// </summary>
    public enum InnerMultiSignature : byte
    {
        Ed25519 = 0,
        Sr25519 = 1,
        Ecdsa = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 201
    /// </summary>
    public class MultiSignature : Enum<InnerMultiSignature, FinalBiome.Api.Types.SpCore.Ed25519.Signature, FinalBiome.Api.Types.SpCore.Sr25519.Signature, FinalBiome.Api.Types.SpCore.Ecdsa.Signature>
    {
        public override string TypeName() => "MultiSignature";
    }
}
