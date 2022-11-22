using System;
namespace FinalBiome.Api.Codegen.Metadata;

public class Field : Codec
{
    public override string TypeName() => "Field<T: Form = MetaForm>";

    public override byte[] Encode()
    {
        throw new NotImplementedException();
    }

    public override void Decode(byte[] byteArray, ref int p)
    {
        var start = p;

        FieldName = new Option<Str>();
        FieldName.Decode(byteArray, ref p);

        FieldTy = new TType();
        FieldTy.Decode(byteArray, ref p);

        FieldTypeName = new Option<Str>();
        FieldTypeName.Decode(byteArray, ref p);

        Docs = new Vec<Str>();
        Docs.Decode(byteArray, ref p);

        TypeSize = p - start;
    }
    public Option<Str> FieldName { get; private set; }
    public TType FieldTy { get; private set; }
    public Option<Str> FieldTypeName { get; private set; }
    public Vec<Str> Docs { get; private set; }
}

