///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpRuntime.Multiaddress
{
    /// <summary>
    /// Generated from meta with Type Id 121
    /// </summary>
    public enum InnerMultiAddress : byte
    {
        Id = 0,
        Index = 1,
        Raw = 2,
        Address32 = 3,
        Address20 = 4,
    }
    /// <summary>
    /// Generated from meta with Type Id 121
    /// </summary>
    public class MultiAddress : Enum<InnerMultiAddress, FinalBiome.Api.Types.SpCore.Crypto.AccountId32, FinalBiome.Api.Types.CompactTuple_Empty, FinalBiome.Api.Types.VecU8, FinalBiome.Api.Types.Array32U8, FinalBiome.Api.Types.Array20U8>
    {
        public override string TypeName() => "MultiAddress";
    }
}
