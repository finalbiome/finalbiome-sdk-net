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
namespace FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    /// Issue a new non fungible class.<br/>
    /// <para></para>
    /// This new class has owner as orgaization.<br/>
    /// <para></para>
    /// The origin must be Signed.<br/>
    /// <para></para>
    /// Parameters:<br/>
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
    /// <para></para>
    /// Emits `Created` event when successful.<br/>
    ///
    ///
    /// Generated from meta with Type Id 154, Variant Id 0
    /// </summary>
    public class CallCreate : Codec
    {
        public override string TypeName() => "CallCreate";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress OrganizationId { get; private set; }
        public FinalBiome.Api.Types.VecU8 Name { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OrganizationId = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            OrganizationId.Decode(byteArray, ref p);

            Name = new FinalBiome.Api.Types.VecU8();
            Name.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
