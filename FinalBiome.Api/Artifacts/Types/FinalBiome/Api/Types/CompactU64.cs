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
    /// Generated from meta with Type Id 89
    /// </summary>
public class CompactU64 : Compact<FinalBiome.Api.Types.Primitive.U64>
{
    public override void Decode(byte[] bytes, ref int pos)
    {
        base.Decode(bytes, ref pos);
        Value = (FinalBiome.Api.Types.Primitive.U64)FinalBiome.Api.Types.Primitive.U64.From((ulong)_value);
    }

    public void Init(FinalBiome.Api.Types.Primitive.U64 value)
    {
        Value = value;
        _value = new BigInteger(value.Value);
    }
    public static CompactU64 From(ulong value)
    {
        var val = new CompactU64();
        FinalBiome.Api.Types.Primitive.U64 i = (FinalBiome.Api.Types.Primitive.U64)FinalBiome.Api.Types.Primitive.U64.From(value);
        val.Init(i);
        return val;
    }
}
