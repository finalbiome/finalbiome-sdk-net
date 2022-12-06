///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId
{
    /// <summary>
    /// Generated from meta with Type Id 45
    /// </summary>
    public class NonFungibleClassId : FinalBiome.Api.Types.Primitive.U32
    {
        public override string TypeName() => "NonFungibleClassId";
        public static implicit operator uint(NonFungibleClassId v) => v.Value;
        public static implicit operator NonFungibleClassId(uint v) {
            NonFungibleClassId res = new();
            res.Init(v);
            return res;
        }
    }
}
