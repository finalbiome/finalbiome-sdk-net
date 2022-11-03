///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.SpRuntime.Generic.Digest
{
    /// <summary>
    /// Generated from meta with Type Id 13
    /// </summary>
    public enum InnerDigestItem
    {
        PreRuntime,
        Consensus,
        Seal,
        Other,
        RuntimeEnvironmentUpdated,
    }
    /// <summary>
    /// Generated from meta with Type Id 13
    /// </summary>
    public class DigestItem : BaseEnumExt<InnerDigestItem, BaseTuple<FinalBiome.Sdk.Model.Types.Base.Array4U8, FinalBiome.Sdk.VecU8>, BaseTuple<FinalBiome.Sdk.Model.Types.Base.Array4U8, FinalBiome.Sdk.VecU8>, BaseTuple<FinalBiome.Sdk.Model.Types.Base.Array4U8, FinalBiome.Sdk.VecU8>, FinalBiome.Sdk.VecU8, BaseVoid>
    {
        public override string TypeName() => "DigestItem";
    }
}
