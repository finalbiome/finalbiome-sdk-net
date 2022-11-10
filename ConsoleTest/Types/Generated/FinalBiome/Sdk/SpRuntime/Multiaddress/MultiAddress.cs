///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.SpRuntime.Multiaddress
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
    public class MultiAddress : BaseEnumExt<InnerMultiAddress, FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.CompactTuple_Empty, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.Model.Types.Base.Array32U8, FinalBiome.Sdk.Model.Types.Base.Array20U8>
    {
        public override string TypeName() => "MultiAddress";
    }
}
