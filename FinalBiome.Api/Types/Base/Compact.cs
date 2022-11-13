using System;
using System.Collections;
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Types
{
    public abstract class Compact<T>: Codec where T : Codec, new()
    {
        protected BigInteger _value;
        public T Value { get; internal set; }
        public override string TypeName() => $"Compact<{new T().TypeName()}>";
        public override int TypeSize { get => Value.TypeSize; }
        public override byte[] Bytes { get => Value.Bytes; }

        public override byte[] Encode() => CompactNum.CompactTo(_value);
        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;
            _value = CompactNum.CompactFrom(bytes, ref pos);
            TypeSize = pos - start;
        }
    }

    // public class CompactU322 : Compact<U32>, IFromNative<CompactU322, uint>
    // {
    //     public override void Decode(byte[] bytes, ref int pos)
    //     {
    //         base.Decode(bytes, ref pos);
    //         Value = U32.From((uint)_value);
    //     }

    //     public static CompactU322 From(uint value)
    //     {
    //         var val = new CompactU322();
    //         var i = U32.From(value);
    //         val.Init(i);
    //         return val;
    //     }

    //     public void Init(U32 value)
    //     {
    //         Value = value;
    //         _value = new BigInteger(value.Value);
    //     }
    // }

    //public class CompactI32 : Compact<I32>, IFromNative<CompactI32, int>
    //{
    //    public static CompactI32 From(int value)
    //    {
    //        var val = new CompactI32();
    //        var i = I32.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(I32 value) 
    //    {
    //        Value = value;
    //        _value = new BigInteger(value.Value);
    //    }
    //}

    //public class CompactU64 : Compact<U64>, IFromNative<CompactU64, ulong>
    //{
    //    public static CompactU64 From(ulong value)
    //    {
    //        var val = new CompactU64();
    //        var i = U64.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(U64 value) 
    //    {
    //        Value = value;
    //        _value = new BigInteger(value.Value);
    //    }
    //}

    //public class CompactI64 : Compact<I64>, IFromNative<CompactI64, long>
    //{
    //    public static CompactI64 From(long value)
    //    {
    //        var val = new CompactI64();
    //        var i = I64.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(I64 value) 
    //    {
    //        Value = value;
    //        _value = new BigInteger(value.Value);
    //    }
    //}

    //public class CompactU128 : Compact<U128>, IFromNative<CompactU128, BigInteger>
    //{
    //    public static CompactU128 From(BigInteger value)
    //    {
    //        var val = new CompactU128();
    //        var i = U128.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(U128 value) 
    //    {
    //        Value = value;
    //        _value = value.Value;
    //    }
    //}

    //public class CompactI128 : Compact<I128>, IFromNative<CompactI128, BigInteger>
    //{
    //    public static CompactI128 From(BigInteger value)
    //    {
    //        var val = new CompactI128();
    //        var i = I128.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(I128 value) 
    //    {
    //        Value = value;
    //        _value = value.Value;
    //    }
    //}

    //public class CompactU256 : Compact<U256>, IFromNative<CompactU256, BigInteger>
    //{
    //    public static CompactU256 From(BigInteger value)
    //    {
    //        var val = new CompactU256();
    //        var i = U256.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(U256 value) 
    //    {
    //        Value = value;
    //        _value = value.Value;
    //    }
    //}

    //public class CompactI256 : Compact<I256>, IFromNative<CompactI256, BigInteger>
    //{
    //    public static CompactI256 From(BigInteger value)
    //    {
    //        var val = new CompactI256();
    //        var i = I256.From(value);
    //        val.Init(i);
    //        return val;
    //    }

    //    public void Init(I256 value) 
    //    {
    //        Value = value;
    //        _value = value.Value;
    //    }
    //}
}

