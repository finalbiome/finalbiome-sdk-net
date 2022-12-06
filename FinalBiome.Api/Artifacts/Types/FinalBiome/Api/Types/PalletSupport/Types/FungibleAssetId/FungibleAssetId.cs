///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId
{
    /// <summary>
    /// Generated from meta with Type Id 42
    /// </summary>
    public class FungibleAssetId : FinalBiome.Api.Types.Primitive.U32
    {
        public override string TypeName() => "FungibleAssetId";
        public static implicit operator uint(FungibleAssetId v) => v.Value;
        public static implicit operator FungibleAssetId(uint v) {
            FungibleAssetId res = new();
            res.Init(v);
            return res;
        }
    }
}
