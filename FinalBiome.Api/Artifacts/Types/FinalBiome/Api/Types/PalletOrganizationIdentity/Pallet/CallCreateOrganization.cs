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
namespace FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet
{
    /// <summary>
    /// Create an organization.<br/>
    /// Will return an OrganizationExists error if the organization has already<br/>
    /// been created. Will emit a CreatedOrganization event on success.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be Signed.<br/>
    ///
    ///
    /// Generated from meta with Type Id 140, Variant Id 0
    /// </summary>
    public class CallCreateOrganization : Codec
    {
        public override string TypeName() => "CallCreateOrganization";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.VecU8 Name { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

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
