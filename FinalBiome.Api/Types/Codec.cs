using System;
using System.Collections;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;

namespace FinalBiome.Api.Types
{
    public abstract class Codec
    {
        public abstract string TypeName();
        [JsonIgnore]
        public virtual int TypeSize { get; internal set; }
        [JsonIgnore]
        public byte[] Bytes { get; internal set; }
        public abstract byte[] Encode();
        public abstract void Decode(byte[] bytes, ref int pos);
        //public abstract void Init(string str);
        public virtual void InitFromHex(string hexString)
        {
            var bytes = HexUtils.HexToBytes(hexString);
            Init(bytes);
        }
        public abstract void Init(byte[] bytes);

        public virtual void Init(string str) => Init(HexUtils.HexToBytes(str));

    }
}

