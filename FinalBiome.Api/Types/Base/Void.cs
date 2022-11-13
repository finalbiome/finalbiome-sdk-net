using System;
namespace FinalBiome.Api.Types
{
    public class BaseVoid : Codec
    {
        public override string TypeName() => "Void";
        public override int TypeSize => 0;

        public override byte[] Encode()
        {
            return new byte[] { };
        }

        public override void Decode(byte[] bytes, ref int pos)
        {
            Bytes = new byte[] { };
        }


    }
}

