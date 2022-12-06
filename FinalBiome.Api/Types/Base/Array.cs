using System;
using System.Collections;

namespace FinalBiome.Api.Types;

public class Array<T> : Codec where T : Codec, new()
{
    public override string TypeName() => $"Array<{new T().TypeName}>";

    public T[] Value { get; internal set; }

    int? typeSize;
    int innerTypeSize;

    public override int TypeSize
    {
        get
        {
            if (typeSize is null) throw new Exception($"Type {TypeName()} has no Size. Define size of the array first (SetSize)");
            return (int)typeSize;
        }
        internal set => typeSize = value;
    }

    /// <summary>
    /// Set size of the array in numbers of elements
    /// </summary>
    /// <param name="size"></param>
    public void SetSize(int size)
    {
        typeSize = size;
    }

    public override void Decode(byte[] bytes, ref int pos)
    {
        var start = pos;
        var array = new T[TypeSize / innerTypeSize];
        for (var i = 0; i < array.Length; i++)
        {
            var t = new T();
            t.Decode(bytes, ref pos);
            array[i] = t;
        };
        var bytesLength = pos - start;
        Bytes = new byte[bytesLength];
        System.Array.Copy(bytes, start, Bytes, 0, bytesLength);
        Value = array;
    }

    /// <summary>
    /// Decode all `bytes` array as it containing only Array data.
    /// </summary>
    /// <param name="bytes"></param>
    public override void Decode(byte[] bytes)
    {
        int pos = 0;
        var start = pos;
        var result = new List<T>();
        while (pos < bytes.Length)
        {
            var t = new T();
            t.Decode(bytes, ref pos);
            result.Add(t);
        }
        Bytes = new byte[bytes.Length];
        System.Array.Copy(bytes, start, Bytes, 0, bytes.Length);
        Value = result.ToArray();
        TypeSize = Value.Length * innerTypeSize;
    }

    public override byte[] Encode()
    {
        var result = new List<byte>();
        foreach (var v in Value) { result.AddRange(v.Encode()); };
        return result.ToArray();
    }

    public void Init(T[] array)
    {
        Value = array;
        Bytes = Encode();
        TypeSize = Value.Length * innerTypeSize;
    }

    public Array()
    {
        innerTypeSize = new T().TypeSize;
    }

    public static implicit operator T[](Array<T> v) => v.Value;
    public static implicit operator Array<T>(T[] v) {
        var res = new Array<T>();
        res.Init(v);
        return res;
    }
    
}

