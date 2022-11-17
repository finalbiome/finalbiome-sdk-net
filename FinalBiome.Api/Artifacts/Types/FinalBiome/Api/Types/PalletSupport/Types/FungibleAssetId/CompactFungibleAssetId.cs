///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using System.Numerics;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId;
    /// <summary>
    /// Generated from meta with Type Id 144
    /// </summary>
public class CompactFungibleAssetId : Compact<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId>
{
    public override void Decode(byte[] bytes, ref int pos)
    {
        base.Decode(bytes, ref pos);
        Value = (FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId)FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId.From((uint)_value);
    }

    public void Init(FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId value)
    {
        Value = value;
        _value = new BigInteger(value.Value);
    }
    public static CompactFungibleAssetId From(uint value)
    {
        var val = new CompactFungibleAssetId();
        FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId i = (FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId)FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId.From(value);
        val.Init(i);
        return val;
    }
}
