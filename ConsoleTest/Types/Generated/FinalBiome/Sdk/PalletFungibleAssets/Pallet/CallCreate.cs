///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Pallet
{
    /// <summary>
    /// Issue a new fungible asset from.<br/>
    /// <para></para>
    /// This new asset has owner as orgaization.<br/>
    /// <para></para>
    /// The origin must be Signed.<br/>
    /// <para></para>
    /// <para></para>
    /// Parameters:<br/>
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
    /// <para></para>
    /// Emits `Created` event when successful.<br/>
    ///
    ///
    /// Generated from meta with Type Id 139, Variant Id 0
    /// </summary>
    public class CallCreate : BaseType
    {
        public override string TypeName() => "CallCreate";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress OrganizationId { get; private set; }
        public FinalBiome.Sdk.VecU8 Name { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA TopUpped { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionCupFA CupGlobal { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionCupFA CupLocal { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OrganizationId = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
            OrganizationId.Decode(byteArray, ref p);

            Name = new FinalBiome.Sdk.VecU8();
            Name.Decode(byteArray, ref p);

            TopUpped = new FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA();
            TopUpped.Decode(byteArray, ref p);

            CupGlobal = new FinalBiome.Sdk.Model.Types.Base.OptionCupFA();
            CupGlobal.Decode(byteArray, ref p);

            CupLocal = new FinalBiome.Sdk.Model.Types.Base.OptionCupFA();
            CupLocal.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
