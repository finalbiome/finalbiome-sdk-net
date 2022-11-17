///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpRuntime.Generic.Digest
{
    /// <summary>
    /// Generated from meta with Type Id 13
    /// </summary>
    public enum InnerDigestItem : byte
    {
        Other = 0,
        Unsupported_1 = 1,
        Unsupported_2 = 2,
        Unsupported_3 = 3,
        Consensus = 4,
        Seal = 5,
        PreRuntime = 6,
        Unsupported_7 = 7,
        RuntimeEnvironmentUpdated = 8,
    }
    /// <summary>
    /// Generated from meta with Type Id 13
    /// </summary>
    public class DigestItem : Enum<InnerDigestItem, FinalBiome.Api.Types.VecU8, BaseVoid, BaseVoid, BaseVoid, Tuple<FinalBiome.Api.Types.Array4U8, FinalBiome.Api.Types.VecU8>, Tuple<FinalBiome.Api.Types.Array4U8, FinalBiome.Api.Types.VecU8>, Tuple<FinalBiome.Api.Types.Array4U8, FinalBiome.Api.Types.VecU8>, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "DigestItem";
    }
}
