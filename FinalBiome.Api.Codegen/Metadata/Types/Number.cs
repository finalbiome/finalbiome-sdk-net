﻿using System;
using System.Numerics;

namespace FinalBiome.Api.Codegen.Metadata
{
    public abstract class Number<T> : Primitive<T> where T : INumber<T>
    {
        public override byte[] Encode() => Bytes;

        public override void InitFromHex(string hexString)
        {
            var bytes = HexUtils.HexToBytes(hexString, false);
            Array.Reverse(bytes);
            var result = new byte[TypeSize];
            bytes.CopyTo(result, 0);
            Init(result);
        }
    }
}

