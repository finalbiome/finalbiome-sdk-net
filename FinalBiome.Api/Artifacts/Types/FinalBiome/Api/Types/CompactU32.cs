///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using System.Numerics;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types;
    /// <summary>
    /// Generated from meta with Type Id 73
    /// </summary>
public class CompactU32 : Compact<FinalBiome.Api.Types.Primitive.U32>
{
    public override void Decode(byte[] bytes, ref int pos)
    {
        base.Decode(bytes, ref pos);
        Value = (FinalBiome.Api.Types.Primitive.U32)FinalBiome.Api.Types.Primitive.U32.From((uint)_value);
    }

    public void Init(FinalBiome.Api.Types.Primitive.U32 value)
    {
        Value = value;
        _value = new BigInteger(value.Value);
    }
    public static CompactU32 From(uint value)
    {
        var val = new CompactU32();
        FinalBiome.Api.Types.Primitive.U32 i = (FinalBiome.Api.Types.Primitive.U32)FinalBiome.Api.Types.Primitive.U32.From(value);
        val.Init(i);
        return val;
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
