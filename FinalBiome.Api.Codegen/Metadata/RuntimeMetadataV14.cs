using System;
namespace FinalBiome.Api.Codegen.Metadata;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

public class RuntimeMetadataV14 : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Types = new PortableRegistry();
        Types.Decode(byteArray, ref p);

        Modules = new Vec<PalletMetadata>();
        Modules.Decode(byteArray, ref p);

        Extrinsic = new ExtrinsicMetadataStruct();
        Extrinsic.Decode(byteArray, ref p);

        TypeId = new TType();
        TypeId.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public PortableRegistry Types { get; private set; }

    public Vec<PalletMetadata> Modules { get; private set; }

    public ExtrinsicMetadataStruct Extrinsic { get; private set; }

    public TType TypeId { get; private set; }
}

public class MetaDataInfo : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Magic = new U32();
        Magic.Decode(byteArray, ref p);

        Version = new U8();
        Version.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public U32 Magic { get; private set; }
    public U8 Version { get; private set; }

}

public class PalletMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        PalletName = new Str();
        PalletName.Decode(byteArray, ref p);

        PalletStorage = new Option<StorageMetadata>();
        PalletStorage.Decode(byteArray, ref p);

        PalletCalls = new Option<PalletCallMetadata>();
        PalletCalls.Decode(byteArray, ref p);

        PalletEvents = new Option<PalletEventMetadata>();
        PalletEvents.Decode(byteArray, ref p);

        PalletConstants = new Vec<PalletConstantMetadata>();
        PalletConstants.Decode(byteArray, ref p);

        PalletErrors = new Option<ErrorMetadata>();
        PalletErrors.Decode(byteArray, ref p);

        Index = new U8();
        Index.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public Str PalletName { get; private set; }
    public Option<StorageMetadata> PalletStorage { get; private set; }
    public Option<PalletCallMetadata> PalletCalls { get; private set; }
    public Option<PalletEventMetadata> PalletEvents { get; private set; }
    public Vec<PalletConstantMetadata> PalletConstants { get; private set; }
    public Option<ErrorMetadata> PalletErrors { get; private set; }
    public U8 Index { get; private set; }
}

public class StorageMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Prefix = new Str();
        Prefix.Decode(byteArray, ref p);

        Entries = new Vec<StorageEntryMetadata>();
        Entries.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public Str Prefix { get; private set; }
    public Vec<StorageEntryMetadata> Entries { get; private set; }
}

public class StorageEntryMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        StorageName = new Str();
        StorageName.Decode(byteArray, ref p);

        StorageModifier = new Enum<Modifier>();
        StorageModifier.Decode(byteArray, ref p);

        StorageType = new Enum<Storage.Type, TType, StorageEntryTypeMap>();
        StorageType.Decode(byteArray, ref p);

        StorageDefault = new ByteGetter();
        StorageDefault.Decode(byteArray, ref p);

        Documentation = new Vec<Str>();
        Documentation.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public Str StorageName { get; private set; }
    public Enum<Modifier> StorageModifier { get; private set; }
    public Enum<Storage.Type, TType, StorageEntryTypeMap> StorageType { get; private set; }
    public ByteGetter StorageDefault { get; private set; }
    public Vec<Str> Documentation { get; private set; }
}

public class ByteGetter : Vec<U8>
{
}

public class StorageEntryTypeMap : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Hashers = new Vec<Enum<Hasher>>();
        Hashers.Decode(byteArray, ref p);

        Key = new TType();
        Key.Decode(byteArray, ref p);

        Value = new TType();
        Value.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public Vec<Enum<Hasher>> Hashers { get; private set; }
    public TType Key { get; private set; }
    public TType Value { get; private set; }
}

public class PalletCallMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        CallType = new TType();
        CallType.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public TType CallType { get; private set; }
}

public class PalletEventMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        EventType = new TType();
        EventType.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public TType EventType { get; private set; }
}
public class PalletConstantMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        ConstantName = new Str();
        ConstantName.Decode(byteArray, ref p);

        ConstantType = new TType();
        ConstantType.Decode(byteArray, ref p);

        ConstantValue = new ByteGetter();
        ConstantValue.Decode(byteArray, ref p);

        Documentation = new Vec<Str>();
        Documentation.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public Str ConstantName { get; private set; }
    public TType ConstantType { get; private set; }
    public ByteGetter ConstantValue { get; private set; }
    public Vec<Str> Documentation { get; private set; }
}

public class ErrorMetadata : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        ErrorType = new TType();
        ErrorType.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public TType ErrorType { get; private set; }

}

public class ExtrinsicMetadataStruct : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        ExtrinsicType = new TType();
        ExtrinsicType.Decode(byteArray, ref p);

        Version = new U8();
        Version.Decode(byteArray, ref p);

        SignedExtensions = new Vec<SignedExtensionMetadataStruct>();
        SignedExtensions.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public TType ExtrinsicType { get; private set; }
    public U8 Version { get; private set; }
    public Vec<SignedExtensionMetadataStruct> SignedExtensions { get; private set; }
}

public class SignedExtensionMetadataStruct : Codec
{
    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        SignedIdentifier = new Str();
        SignedIdentifier.Decode(byteArray, ref p);

        SignedExtType = new TType();
        SignedExtType.Decode(byteArray, ref p);

        AddSignedExtType = new TType();
        AddSignedExtType.Decode(byteArray, ref p);

        TypeSize = p - start;
    }

    public override string TypeName()
    {
        throw new NotImplementedException();
    }

    public Str SignedIdentifier { get; private set; }
    public TType SignedExtType { get; private set; }
    public TType AddSignedExtType { get; private set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

