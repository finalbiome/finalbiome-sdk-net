﻿using System.Collections.Generic;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc;

public class Digest : Codec
{
    public override string TypeName() => "Digest";

    private int _size;
    public override int TypeSize => _size;

    public Vec<DigestItem> Logs;

    public override byte[] Encode()
    {
        var bytes = new List<byte>();

        bytes.AddRange(Logs.Encode());

        return bytes.ToArray();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Logs = new Vec<DigestItem>();
        Logs.Decode(byteArray, ref p);

        _size = p - start;

        Bytes = new byte[TypeSize];
        Array.Copy(byteArray, start, Bytes, 0, TypeSize);
    }

    public void Create(DigestItem[] digestItems)
    {
        var logs = new Vec<DigestItem>();
        logs.Init(digestItems);
        Logs = logs;
        Bytes = Encode();
    }
}

/// <summary>
/// Digest item that is able to encode/decode 'system' digest items and
/// provide opaque access to other items.
///
/// <para>
/// Type of the digest item. Used to gain explicit control over `DigestItem` encoding
/// process. We need an explicit control, because final runtimes are encoding their own
/// digest items using `DigestItemRef` type and we can't auto-derive `Decode`
/// trait for `DigestItemRef`.
/// See sp-runtime `DigestItemType`
/// </para>
/// </summary>
public enum innerDigestItem : byte
{
    /// <summary>
    /// A pre-runtime digest.
    ///
    /// These are messages from the consensus engine to the runtime, although
    /// the consensus engine can (and should) read them itself to avoid
    /// code and state duplication. It is erroneous for a runtime to produce
    /// these, but this is not (yet) checked.
    ///
    /// NOTE: the runtime is not allowed to panic or fail in an `on_initialize`
    /// call if an expected `PreRuntime` digest is not present. It is the
    /// responsibility of a external block verifier to check this. Runtime API calls
    /// will initialize the block without pre-runtime digests, so initialization
    /// cannot fail when they are missing.
    /// </summary>
    PreRuntime = 6,
    /// <summary>
    /// A message from the runtime to the consensus engine. This should *never*
    /// be generated by the native code of any consensus engine, but this is not
    /// checked (yet).
    /// </summary>
    Consensus = 4,
    /// <summary>
    /// Put a Seal on it. This is only used by native code, and is never seen
    /// by runtimes.
    /// </summary>
    Seal = 5,
    /// <summary>
    /// /// Some other thing. Unsupported and experimental.
    /// </summary>
    Other = 0,
    /// <summary>
    /// An indication for the light clients that the runtime execution
    /// environment is updated.
    ///
    /// Currently this is triggered when:
    /// 1. Runtime code blob is changed or
    /// 2. `heap_pages` value is changed.
    /// </summary>
    RuntimeEnvironmentUpdated = 8
}

/// <summary>
/// Digest item that is able to encode/decode 'system' digest items and
/// provide opaque access to other items.
/// </summary>
//public class DigestItem : BaseEnumExt<innerDigestItem,
//                                      BaseTuple<ConsensusEngineId, BaseVec<U8>>, // PreRuntime
//                                      BaseTuple<ConsensusEngineId, BaseVec<U8>>, // Consensus
//                                      BaseTuple<ConsensusEngineId, BaseVec<U8>>, // Seal
//                                      BaseVec<U8>, // Other
//                                      BaseVoid> // RuntimeEnvironmentUpdated
// Hack: BaseEnumExt takes types for enum by order, not by value
public class DigestItem : Enum<innerDigestItem,
                                      Vec<U8>, // Other = 0,
                                      BaseVoid, // Undefined = 1,
                                      BaseVoid, // Undefined = 2,
                                      BaseVoid, // Undefined = 3,
                                      FinalBiome.Api.Types.Tuple<ConsensusEngineId, Vec<U8>>, // Consensus = 4,
                                      FinalBiome.Api.Types.Tuple<ConsensusEngineId, Vec<U8>>, // Seal = 5
                                      FinalBiome.Api.Types.Tuple<ConsensusEngineId, Vec<U8>>, // PreRuntime = 6,
                                      BaseVoid, // Undefined = 7,
                                      BaseVoid> // RuntimeEnvironmentUpdated = 8,
{
    public override string TypeName() => "DigestItem";
}

/// <summary>
/// It is [u8; 4] array
/// </summary>
public class ConsensusEngineId : Codec
{
#pragma warning disable CS8618
    private U8[] _value;
#pragma warning restore CS8618

    public override int TypeSize
    {
        get { return 4; }
    }

    public U8[] Value
    {
        get { return this._value; }
        set { this._value = value; }
    }

    public override string TypeName()
    {
        return string.Format("[{0}; {1}]", new U8().TypeName(), this.TypeSize);
    }

    public override byte[] Encode()
    {
        var result = new List<byte>();
        foreach (var v in Value) { result.AddRange(v.Encode()); };
        return result.ToArray();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;
        var array = new U8[TypeSize];
        for (var i = 0; i < array.Length; i++) { var t = new U8(); t.Decode(byteArray, ref p); array[i] = t; };
        var bytesLength = p - start;
        Bytes = new byte[bytesLength];
        System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        Value = array;
    }

    public void Create(U8[] array)
    {
        Value = array;
        Bytes = Encode();
    }
}
