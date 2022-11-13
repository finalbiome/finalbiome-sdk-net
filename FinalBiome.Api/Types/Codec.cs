using System;
using System.Collections;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;

namespace FinalBiome.Api.Types
{
    public abstract class Codec
    {
        public static T Decode<T>(byte[] bytes, ref int pos) where T : Codec, new()
        {
            var val = new T();
            val.Decode(bytes, ref pos);
            return val;
        }

        public abstract string TypeName();
        [JsonIgnore]
        public virtual int TypeSize { get; internal set; }
#pragma warning disable CS8618
        [JsonIgnore]
        public virtual byte[] Bytes { get; internal set; }
#pragma warning restore CS8618
        public abstract byte[] Encode();
        public abstract void Decode(byte[] bytes, ref int pos);
        public virtual void Decode(byte[] bytes)
        {
            int pos = 0;
            Decode(bytes, ref pos);
        }
        //public abstract void Init(string str);
        public virtual void InitFromHex(string hexString)
        {
            var bytes = HexUtils.HexToBytes(hexString);
            Init(bytes);
        }
        public virtual void Init(byte[] bytes)
        {
            Decode(bytes);
        }

        public virtual void Init(string str) => Init(HexUtils.HexToBytes(str));

    }
}

