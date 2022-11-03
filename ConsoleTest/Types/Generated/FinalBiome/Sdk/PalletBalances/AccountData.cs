///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances
{
    /// <summary>
    /// Generated from meta with Type Id 5
    /// </summary>
    public class AccountData : BaseType
    {
        public override string TypeName() => "AccountData";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U128 Free { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 Reserved { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 MiscFrozen { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 FeeFrozen { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Free = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Free.Decode(byteArray, ref p);

            Reserved = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Reserved.Decode(byteArray, ref p);

            MiscFrozen = new Ajuna.NetApi.Model.Types.Primitive.U128();
            MiscFrozen.Decode(byteArray, ref p);

            FeeFrozen = new Ajuna.NetApi.Model.Types.Primitive.U128();
            FeeFrozen.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
