///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletMechanics.Pallet
{
    /// <summary>
    /// Upgrade mechanic<br/>
    ///
    ///
    /// Generated from meta with Type Id 172, Variant Id 2
    /// </summary>
    public class CallUpgrade : Codec
    {
        public override string TypeName() => "CallUpgrade";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 OrganizationId { get; private set; }
        public FinalBiome.Api.Types.PalletMechanics.Types.MechanicUpgradeData UpgrageData { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OrganizationId = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            OrganizationId.Decode(byteArray, ref p);

            UpgrageData = new FinalBiome.Api.Types.PalletMechanics.Types.MechanicUpgradeData();
            UpgrageData.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
