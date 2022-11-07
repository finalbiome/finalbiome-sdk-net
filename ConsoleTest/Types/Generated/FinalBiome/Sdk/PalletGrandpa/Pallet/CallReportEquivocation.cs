///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletGrandpa.Pallet
{
    /// <summary>
    /// Report voter equivocation/misbehavior. This method will verify the<br/>
    /// equivocation proof and validate the given key ownership proof<br/>
    /// against the extracted offender. If both are valid, the offence<br/>
    /// will be reported.<br/>
    ///
    ///
    /// Generated from meta with Type Id 98, Variant Id 0
    /// </summary>
    public class CallReportEquivocation : BaseType
    {
        public override string TypeName() => "CallReportEquivocation";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof EquivocationProof { get; private set; }
        public FinalBiome.Sdk.SpCore.Void KeyOwnerProof { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            EquivocationProof = new FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof();
            EquivocationProof.Decode(byteArray, ref p);

            KeyOwnerProof = new FinalBiome.Sdk.SpCore.Void();
            KeyOwnerProof.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
