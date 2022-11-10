///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 48
    /// </summary>
    public enum InnerAttributeValue : byte
    {
        Number = 0,
        Text = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 48
    /// </summary>
    public class AttributeValue : BaseEnumExt<InnerAttributeValue, FinalBiome.Sdk.PalletSupport.NumberAttribute, FinalBiome.Sdk.BoundedVecU8>
    {
        public override string TypeName() => "AttributeValue";
    }
}
