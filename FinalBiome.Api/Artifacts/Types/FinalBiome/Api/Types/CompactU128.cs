///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using System.Numerics;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types;
    /// <summary>
    /// Generated from meta with Type Id 124
    /// </summary>
public class CompactU128 : Compact<FinalBiome.Api.Types.Primitive.U128>
{
    public override void Decode(byte[] bytes, ref int pos)
    {
        base.Decode(bytes, ref pos);
        Value = (FinalBiome.Api.Types.Primitive.U128)FinalBiome.Api.Types.Primitive.U128.From((BigInteger)_value);
    }

    public void Init(FinalBiome.Api.Types.Primitive.U128 value)
    {
        Value = value;
        _value = value.Value;
    }
    public static CompactU128 From(BigInteger value)
    {
        var val = new CompactU128();
        FinalBiome.Api.Types.Primitive.U128 i = (FinalBiome.Api.Types.Primitive.U128)FinalBiome.Api.Types.Primitive.U128.From(value);
        val.Init(i);
        return val;
    }
}
