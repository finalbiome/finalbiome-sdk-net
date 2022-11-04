using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleTest
{
    public class ApiTypesJsonConverter : JsonConverter
    {

        Type[] _types =
            {
                typeof(Ajuna.NetApi.Model.Types.Primitive.Bool),
                typeof(Ajuna.NetApi.Model.Types.Primitive.U8),
                typeof(Ajuna.NetApi.Model.Types.Primitive.U16),
                typeof(Ajuna.NetApi.Model.Types.Primitive.U32),
                typeof(Ajuna.NetApi.Model.Types.Primitive.U64),
                typeof(Ajuna.NetApi.Model.Types.Primitive.U128),
                typeof(Ajuna.NetApi.Model.Types.Primitive.U256),
                typeof(Ajuna.NetApi.Model.Types.Primitive.Str),
                typeof(Ajuna.NetApi.Model.Types.Primitive.PrimChar),
                typeof(FinalBiome.Sdk.SpCore.Crypto.AccountId32),
                typeof(FinalBiome.Sdk.BoundedVecU8),
            };

        public override bool CanConvert(Type objectType)
        {
            return (_types.Contains(objectType) ||
                _types.Contains(objectType.BaseType) ||
                (objectType.GetInterface(nameof(Ajuna.NetApi.Model.Types.IType)) != null && objectType.GetProperty("Value") != null));
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
                    case Ajuna.NetApi.Model.Types.Primitive.Bool v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.U8 v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.U16 v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.U32 v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.U64 v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.U128 v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.U256 v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.Str v:
                        writer.WriteValue(v.Value);
                        break;
                    case Ajuna.NetApi.Model.Types.Primitive.PrimChar v:
                        writer.WriteValue(v.Value);
                        break;
                    case FinalBiome.Sdk.SpCore.Crypto.AccountId32 v:
                        List<byte> b = new List<byte>();
                        foreach (var i in v.Value) b.Add(i.Value);
                        string e = Ajuna.NetApi.Utils.GetAddressFrom(b.ToArray());
                        writer.WriteValue(e);
                        break;
                    case FinalBiome.Sdk.BoundedVecU8 v:
                        List<byte> b1 = new List<byte>();
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
                foreach (var childToken in token.AsEnumerable())
                {
                    var propName = childToken.Path;
                    var propVal = value.GetType().GetProperty(propName);
                    var val = propVal.GetValue(value);

                    writer.WritePropertyName(propName);
                    serializer.Serialize(writer, val);

                }
                writer.WriteEndObject();
            }
        }
    }
}

