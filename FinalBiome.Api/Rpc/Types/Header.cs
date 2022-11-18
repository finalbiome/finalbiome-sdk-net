using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types.PrimitiveTypes;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FinalBiome.Api.Rpc;

using Hash = H256;

public class Header : Codec
{
    private int _size;
    public override int TypeSize => _size;
    public override string TypeName() => "Header";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Hash ParentHash { get; set; }

    public Compact<U32> Number { get; set; }

    public Hash StateRoot { get; set; }

    public Hash ExtrinsicsRoot { get; set; }

    public Digest Digest { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        ParentHash = new Hash();
        ParentHash.Decode(byteArray, ref p);

        Number = new Compact<U32>();
        Number.Decode(byteArray, ref p);

        StateRoot = new Hash();
        StateRoot.Decode(byteArray, ref p);

        ExtrinsicsRoot = new Hash();
        ExtrinsicsRoot.Decode(byteArray, ref p);

        Digest = new Digest();
        Digest.Decode(byteArray, ref p);

        _size = p - start;

        Bytes = new byte[TypeSize];
        Array.Copy(byteArray, start, Bytes, 0, TypeSize);
    }

    public override byte[] Encode()
    {
        var bytes = new List<byte>();

        bytes.AddRange(ParentHash.Encode());
        bytes.AddRange(Number.Encode());
        bytes.AddRange(StateRoot.Encode());
        bytes.AddRange(ExtrinsicsRoot.Encode());
        bytes.AddRange(Digest.Encode());

        return bytes.ToArray();
    }
    /// <summary>
    /// Returns the hash of the header.
    /// </summary>
    /// <returns></returns>
    public Hash Hash()
    {
        Hash hash = new Hash();
        hash.Init(Hasher.BlakeTwo256(this.Encode()));
        return hash;
    }
}
