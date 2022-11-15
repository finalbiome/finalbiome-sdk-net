using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc;

///
/// Bytes representing an extrinsic in a [`ChainBlock`].
///
using ChainBlockExtrinsic = Vec<U8>;
///
/// The encoded justification specific to a consensus engine.
///
using EncodedJustification = Vec<U8>;

/// <summary>
/// The rpc response from `chain_getBlock`
/// </summary>
public class ChainBlockResponse : Codec
{
    public override string TypeName() => "ChainBlockResponse";

    private int _size;
    public override int TypeSize => _size;
    /// <summary>
    /// The block itself.
    /// </summary>
    public ChainBlock Block;
    /// <summary>
    /// Block justification.
    /// </summary>
    public Option<Justifications> Justifications;

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Block = new ChainBlock();
        Block.Decode(byteArray, ref p);

        Justifications = new Option<Justifications>();
        Justifications.Decode(byteArray, ref p);

        _size = p - start;

        Bytes = new byte[TypeSize];
        Array.Copy(byteArray, start, Bytes, 0, TypeSize);
    }

    public override byte[] Encode()
    {
        var bytes = new List<byte>();

        bytes.AddRange(Block.Encode());
        bytes.AddRange(Justifications.Encode());

        return bytes.ToArray();
    }
}

/// <summary>
/// Block details in the [`ChainBlockResponse`].
/// </summary>
public class ChainBlock : Codec
{
    private int _size;
    public override int TypeSize => _size;
    public override string TypeName() => "ChainBlock";
    /// <summary>
    /// The block header.
    /// </summary>
    public Header Header;
    /// <summary>
    /// The accompanying extrinsics.
    /// </summary>
    public Vec<ChainBlockExtrinsic> Extrinsics;

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Header = new Header();
        Header.Decode(byteArray, ref p);

        Extrinsics = new Vec<ChainBlockExtrinsic>();
        Extrinsics.Decode(byteArray, ref p);

        _size = p - start;

        Bytes = new byte[TypeSize];
        Array.Copy(byteArray, start, Bytes, 0, TypeSize);
    }

    public override byte[] Encode()
    {
        var bytes = new List<byte>();

        bytes.AddRange(Header.Encode());
        bytes.AddRange(Extrinsics.Encode());

        return bytes.ToArray();
    }
}

/// <summary>
/// Collection of justifications for a given block, multiple justifications may
/// be provided by different consensus engines for the same block.
/// </summary>
public class Justifications : Vec<Justification>
{
    public override string TypeName() => "Justifications";
}

/// <summary>
/// An abstraction over justification for a block's validity under a consensus algorithm.
///
/// Essentially a finality proof. The exact formulation will vary between consensus
/// algorithms. In the case where there are multiple valid proofs, inclusion within
/// the block itself would allow swapping justifications to change the block's hash
/// (and thus fork the chain). Sending a `Justification` alongside a block instead
/// bypasses this problem.
///
/// Each justification is provided as an encoded blob, and is tagged with an ID
/// to identify the consensus engine that generated the proof (we might have
/// multiple justifications from different engines for the same block).
/// </summary>
public class Justification : Types.Tuple<ConsensusEngineId, EncodedJustification>
{
    public override string TypeName() => "Justification";
}

