///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet
{
    /// <summary>
    /// Removes a member from organization.<br/>
    /// <para></para>
    /// # Events<br/>
    /// * `MemberRemoved`<br/>
    /// <para></para>
    /// # Errors<br/>
    /// * `NotOrganization` if origin not an organization<br/>
    /// * `NotMember` if a member doesn't exist<br/>
    /// * ``<br/>
    ///
    ///
    /// Generated from meta with Type Id 131, Variant Id 2
    /// </summary>
    public class CallRemoveMember : Codec
    {
        public override string TypeName() => "CallRemoveMember";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Who { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Who = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Who.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
