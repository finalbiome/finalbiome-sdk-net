using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace ConsoleApi;

using AccountId32 = FinalBiome.Api.Types.SpCore.Crypto.AccountId32;
public class ApiTypesJsonConverter : JsonConverter
{
  readonly Type[] _types =
        {
            typeof(Bool),
            typeof(U8),
            typeof(U16),
            typeof(U32),
            typeof(U64),
            typeof(U128),
            typeof(Str),
            typeof(FinalBiome.Api.Types.Primitive.Char),
            typeof(AccountId32),
            typeof(BoundedVecU8),
        };

    public override bool CanConvert(Type objectType)
    {
        return (_types.Contains(objectType) ||
            _types.Contains(objectType.BaseType) ||
            (objectType.GetInterface(nameof(FinalBiome.Api.Types.Codec)) != null && objectType.GetProperty("Value") != null));
    }

    public override bool CanRead
    {
        get { return false; }
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
            return;
        }

        JToken token = JToken.FromObject(value);
        // write primitives
        if (_types.Contains(value.GetType()))
        {
            switch (value)
            {
                case Bool v:
                    writer.WriteValue(v.Value);
                    break;
                case U8 v:
                    writer.WriteValue(v.Value);
                    break;
                case U16 v:
                    writer.WriteValue(v.Value);
                    break;
                case U32 v:
                    writer.WriteValue(v.Value);
                    break;
                case U64 v:
                    writer.WriteValue(v.Value);
                    break;
                case U128 v:
                    writer.WriteValue(v.Value);
                    break;
                case Str v:
                    writer.WriteValue(v.Value);
                    break;
                case FinalBiome.Api.Types.Primitive.Char v:
                    writer.WriteValue(v.Value);
                    break;
                case AccountId32 v:
                    List<byte> b = new();
                    foreach (var i in v.Value) b.Add(i.Value);
                    string e = AddressUtils.GetAddressFrom(b.ToArray());
                    writer.WriteValue(e);
                    break;
                //case VecU8:
                case BoundedVecU8 v:
                    List<byte> b1 = new();
                    foreach (var i in v.Value) b1.Add(i.Value);

                    string a = System.Text.Encoding.UTF8.GetString(b1.ToArray());
                    writer.WriteValue(a);
                    break;
                default:
                    //t.WriteTo(writer);
                    throw new NotImplementedException();
                    //break;
            }
            return;
        }

        // deref wrappers
        int childTokensNum = token.Count();
        var valueProp = value.GetType().GetProperty("Value");
        if (childTokensNum == 1 && valueProp != null)
        {
            // deref value from Value prop
            var val = valueProp.GetValue(value);
            serializer.Serialize(writer, val);
        }
        else // write object as is
        {
            if (token.Type != JTokenType.Object)
            {
                token.WriteTo(writer);
                return;
            }

            // it's composite object. writes it as an object
            writer.WriteStartObject();
            foreach (JToken childToken in token.AsEnumerable())
            {
                string propName = childToken.Path;
                var propVal = value.GetType().GetProperty(propName);
                if (propVal is not null)
                {
                    var val = propVal.GetValue(value);
                    writer.WritePropertyName(propName);
                    serializer.Serialize(writer, val);
                }
            }
            writer.WriteEndObject();
        }
    }
}

