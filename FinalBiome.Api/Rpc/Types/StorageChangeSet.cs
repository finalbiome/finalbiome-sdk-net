using System.Collections;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
using StorageKey = Vec<U8>;
using StorageData = Vec<U8>;

/// <summary>
/// Storage change set
/// </summary>
public class StorageChangeSet : Codec
{
    public override string TypeName() => "StorageChangeSet";

    /// <summary>
    /// Block hash
    /// </summary>
    Hash Block { get; set; }

    /// <summary>
    /// A list of changes
    /// </summary>
    Vec<FinalBiome.Api.Types.Tuple<StorageKey, Option<StorageData>>> Changes { get; set; }

    public override void Decode(byte[] bytes, ref int pos)
    {
        var start = pos;

        Block = new Hash();
        Block.Decode(bytes, ref pos);

        Changes = new Vec<FinalBiome.Api.Types.Tuple<StorageKey, Option<StorageData>>>();
        Changes.Decode(bytes, ref pos);

        TypeSize = pos - start;
        Bytes = new byte[TypeSize];
        Array.Copy(bytes, start, Bytes, 0, TypeSize);
    }

    public override byte[] Encode()
    {
        var bytes = new List<byte>();

        bytes.AddRange(Block.Encode());
        bytes.AddRange(Changes.Encode());

        return bytes.ToArray();
    }
}

