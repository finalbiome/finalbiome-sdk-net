using System;
using System.Numerics;
using Newtonsoft.Json;

namespace FinalBiome.Api.Codegen.Metadata;

public class CompactIntegerType : Codec
{
    public override string  TypeName() => "CompactInteger";

    public int TypeSize { get; set; } = 0;

    public void Create(string str)
    {
        throw new NotImplementedException();
    }

    public void Create(byte[] byteArray)
    {
        throw new NotImplementedException();
    }

    public void CreateFromJson(string str)
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        Value = U32.From((uint)CompactNum.CompactFrom(byteArray, ref p));
    }

    public override byte[] Encode()
    {
        return Value.Encode();
    }

    public override string ToString() => JsonConvert.SerializeObject(Value);

    public Codec New() => this;

    public U32 Value { get; set; }

}

public class TType : CompactIntegerType
{
    public override string TypeName() => "T::Type";

}

public enum TypeDefEnum
{
    /// A composite type (e.g. a struct or a tuple)
    Composite = 0,
    /// A variant type (e.g. an enum)
    Variant = 1,
    /// A sequence type with runtime known length.
    Sequence = 2,
    /// An array type with compile-time known length.
    Array = 3,
    /// A tuple type.
    Tuple = 4,
    /// A Rust primitive type.
    Primitive = 5,
    /// A type using the [`Compact`] encoding
    Compact = 6,
    /// A type representing a sequence of bits.
    BitSequence = 7
}

public class TypeDefComposite : Codec
{
    public override string TypeName() => "TypeDefComposite<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Fields = new Vec<Field>();
        Fields.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Vec<Field> Fields { get; private set; }

}

public class TypeDefVariant : Codec
{
    public override string TypeName() => "TypeDefVariant<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        TypeParam = new Vec<Variant>();
        TypeParam.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Vec<Variant> TypeParam { get; private set; }
}

public class TypeDefSequence : Codec
{
    public override string TypeName() => "TypeDefSequence<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        TypeParam = new TType();
        TypeParam.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public TType TypeParam { get; private set; }
}

public class TypeDefArray : Codec
{
    public override string TypeName() => "TypeDefArray<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Len = new U32();
        Len.Decode(byteArray, ref p);

        TypeParam = new TType();
        TypeParam.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public U32 Len { get; private set; }
    public TType TypeParam { get; private set; }
}

public class TypeDefTuple : Codec
{
    public override string TypeName() => "TypeDefTuple<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Fields = new Vec<TType>();
        Fields.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Vec<TType> Fields { get; private set; }
}

public enum TypeDefPrimitive
{
    /// `bool` type
    Bool,
    /// `char` type
    Char,
    /// `str` type
    Str,
    /// `u8`
    U8,
    /// `u16`
    U16,
    /// `u32`
    U32,
    /// `u64`
    U64,
    /// `u128`
    U128,
    /// 256 bits unsigned int (no rust equivalent)
    U256,
    /// `i8`
    I8,
    /// `i16`
    I16,
    /// `i32`
    I32,
    /// `i64`
    I64,
    /// `i128`
    I128,
    /// 256 bits signed int (no rust equivalent)
    I256,
}

public class TypeDefCompact : Codec
{
    public override string TypeName() => "TypeDefCompact<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        TypeParam = new TType();
        TypeParam.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public TType TypeParam { get; private set; }
}

public class TypeDefBitSequence : Codec
{
    public override string TypeName() => "TypeDefBitSequence<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        BitStoreType = new TType();
        BitStoreType.Decode(byteArray, ref p);

        BitOrderType = new TType();
        BitOrderType.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public TType BitStoreType { get; private set; }
    public TType BitOrderType { get; private set; }
}

public class Variant : Codec
{
    public override string TypeName() => "Variant<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        VariantName = new Str();
        VariantName.Decode(byteArray, ref p);

        VariantFields = new Vec<Field>();
        VariantFields.Decode(byteArray, ref p);

        Index = new U8();
        Index.Decode(byteArray, ref p);

        Docs = new Vec<Str>();
        Docs.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Str VariantName { get; private set; }
    public Vec<Field> VariantFields { get; private set; }
    public U8 Index { get; private set; }
    public Vec<Str> Docs { get; private set; }
}

public class PortableRegistry : Vec<PortableType>
{
    public override string TypeName() => "PortableRegistry";
}

public class PortableType : Codec
{
    public override string TypeName() => "PortableType";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        // #[codec(compact)]
        Id = new U32();
        Id.Init((uint)CompactNum.CompactFrom(byteArray, ref p));

        Ty = new TypePortableForm();
        Ty.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public U32 Id { get; private set; }
    public TypePortableForm Ty { get; private set; }
}

public class TypePortableForm : Codec
{
    public override string TypeName() => "Type<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        Path = new Path();
        Path.Decode(byteArray, ref p);

        TypeParams = new Vec<TypeParameter>();
        TypeParams.Decode(byteArray, ref p);

        TypeDef = new Enum<TypeDefEnum, TypeDefComposite, TypeDefVariant, TypeDefSequence, TypeDefArray, TypeDefTuple, Enum<TypeDefPrimitive>, TypeDefCompact, TypeDefBitSequence, BaseVoid>();
        TypeDef.Decode(byteArray, ref p);

        Docs = new Vec<Str>();
        Docs.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Path Path { get; private set; }
    public Vec<TypeParameter> TypeParams { get; private set; }
    public Enum<TypeDefEnum, TypeDefComposite, TypeDefVariant, TypeDefSequence, TypeDefArray, TypeDefTuple,Enum <TypeDefPrimitive>, TypeDefCompact, TypeDefBitSequence, BaseVoid> TypeDef { get; private set; }
    public Vec<Str> Docs { get; private set; }
}

public class Path : Vec<Str>
{
    public override string TypeName() => "Path<T: Form = MetaForm>";
}

public class TypeParameter : Codec
{
    public override string TypeName() => "TypeParameter<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        TypeParameterName = new Str();
        TypeParameterName.Decode(byteArray, ref p);

        TypeParameterType = new Option<TType>();
        TypeParameterType.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Str TypeParameterName { get; private set; }
    public Option<TType> TypeParameterType { get; private set; }
}

public class Storage
{
    public enum Type
    {
        Plain,
        Map,
        DoubleMap,
        NMap
    }

    //public enum Modifier
    //{
    //    Optional,
    //    Default
    //}

    //public enum Hasher
    //{
    //    None = -1,
    //    BlakeTwo128,
    //    BlakeTwo256,
    //    BlakeTwo128Concat,
    //    Twox128,
    //    Twox256,
    //    Twox64Concat,
    //    Identity
    //}
}

public enum Modifier
{
    Optional,
    Default
}

public enum Hasher
{
    None = -1,
    BlakeTwo128,
    BlakeTwo256,
    BlakeTwo128Concat,
    Twox128,
    Twox256,
    Twox64Concat,
    Identity
}