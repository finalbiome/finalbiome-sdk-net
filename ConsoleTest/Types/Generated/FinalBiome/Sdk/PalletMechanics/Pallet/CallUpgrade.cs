///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Pallet
{
    /// <summary>
    /// Upgrade mechanic<br/>
    ///
    ///
    /// Generated from meta with Type Id 163, Variant Id 2
    /// </summary>
    public class CallUpgrade : BaseType
    {
        public override string TypeName() => "CallUpgrade";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletMechanics.Types.MechanicUpgradeData UpgrageData { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            UpgrageData = new FinalBiome.Sdk.PalletMechanics.Types.MechanicUpgradeData();
            UpgrageData.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
