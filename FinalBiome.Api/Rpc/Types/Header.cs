using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types.PrimitiveTypes;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FinalBiome.Api.Rpc;

public class Header : Codec
{
    private int _size;
    public override int TypeSize => _size;
    public override string TypeName() => "Header";


    public H256 ParentHash { get; set; }

    public Compact<U32> Number { get; set; }

    public H256 StateRoot { get; set; }

    public H256 ExtrinsicsRoot { get; set; }

    public Digest Digest { get; set; }



    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        ParentHash = new H256();
        ParentHash.Decode(byteArray, ref p);

        Number = new CompactU32();
        Number.Decode(byteArray, ref p);

        StateRoot = new H256();
        StateRoot.Decode(byteArray, ref p);

        ExtrinsicsRoot = new H256();
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

        bytes.AddRange(ParentHash.Bytes);
        bytes.AddRange(Number.Bytes);
        bytes.AddRange(StateRoot.Bytes);
        bytes.AddRange(ExtrinsicsRoot.Bytes);
        bytes.AddRange(Digest.Bytes);

        return bytes.ToArray();
    }
    /// <summary>
    /// Returns the hash of the header.
    /// </summary>
    /// <returns></returns>
    public H256 Hash()
    {
        H256 hash = new H256();
        hash.Init(Hasher.BlakeTwo256(this.Bytes));
        return hash;
    }
}
