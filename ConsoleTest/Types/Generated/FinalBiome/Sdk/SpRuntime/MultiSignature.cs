///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.SpRuntime
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
    public class MultiSignature : BaseEnumExt<InnerMultiSignature, FinalBiome.Sdk.SpCore.Ed25519.Signature, FinalBiome.Sdk.SpCore.Sr25519.Signature, FinalBiome.Sdk.SpCore.Ecdsa.Signature>
    {
        public override string TypeName() => "MultiSignature";
    }
}
