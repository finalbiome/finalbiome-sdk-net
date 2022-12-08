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
namespace FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId;
    /// <summary>
    /// Generated from meta with Type Id 153
    /// </summary>
public class CompactNonFungibleClassId : Compact<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>
{
    public override void Decode(byte[] bytes, ref int pos)
    {
        base.Decode(bytes, ref pos);
        Value = (FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId)FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId.From((uint)_value);
    }

    public void Init(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId value)
    {
        Value = value;
        _value = new BigInteger(value.Value);
    }
    public static CompactNonFungibleClassId From(uint value)
    {
        var val = new CompactNonFungibleClassId();
        FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId i = (FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId)FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId.From(value);
        val.Init(i);
        return val;
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
