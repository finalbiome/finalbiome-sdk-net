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
namespace FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance
{
    /// <summary>
    /// Generated from meta with Type Id 44
    /// </summary>
    public class FungibleAssetBalance : FinalBiome.Api.Types.Primitive.U128
    {
        public override string TypeName() => "FungibleAssetBalance";
        public static implicit operator BigInteger(FungibleAssetBalance v) => v.Value;
        public static implicit operator FungibleAssetBalance(BigInteger v) {
            FungibleAssetBalance res = new();
            res.Init(v);
            return res;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
