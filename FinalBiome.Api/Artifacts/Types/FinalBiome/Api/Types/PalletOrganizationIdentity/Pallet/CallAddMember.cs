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
    /// Add member to an organization.<br/>
    /// <para></para>
    /// # Events<br/>
    /// * `MemberAdded`<br/>
    /// # Errors<br/>
    /// * `NotOrganization` if origin not an organization<br/>
    /// * `MembershipLimitReached` if members limit exceeded<br/>
    /// * `InvalidMember` if member is organization<br/>
    /// * `AlreadyMember` if member already added<br/>
    ///
    ///
    /// Generated from meta with Type Id 131, Variant Id 1
    /// </summary>
    public class CallAddMember : Codec
    {
        public override string TypeName() => "CallAddMember";

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

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
