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
namespace FinalBiome.Api.Types.PalletGrandpa.Pallet
{
    /// <summary>
    /// Report voter equivocation/misbehavior. This method will verify the<br/>
    /// equivocation proof and validate the given key ownership proof<br/>
    /// against the extracted offender. If both are valid, the offence<br/>
    /// will be reported.<br/>
    ///
    ///
    /// Generated from meta with Type Id 106, Variant Id 0
    /// </summary>
    public class CallReportEquivocation : Codec
    {
        public override string TypeName() => "CallReportEquivocation";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpFinalityGrandpa.EquivocationProof EquivocationProof { get; private set; }
        public FinalBiome.Api.Types.SpCore.Void KeyOwnerProof { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            EquivocationProof = new FinalBiome.Api.Types.SpFinalityGrandpa.EquivocationProof();
            EquivocationProof.Decode(byteArray, ref p);

            KeyOwnerProof = new FinalBiome.Api.Types.SpCore.Void();
            KeyOwnerProof.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
