using System;
using System.Numerics;
using Newtonsoft.Json;

using System.Collections.Generic;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Rpc.JsonConverters;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

internal class HeaderJsonConverter : JsonConverter<Header>
{
    public override Header ReadJson(JsonReader reader, Type objectType, Header? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        //	TokenType StartObject
        Header header = new Header();
        reader.Read();
        while (reader.TokenType != JsonToken.EndObject)
        {
            if (reader.TokenType == JsonToken.PropertyName)
            {
                switch(reader.Value)
                {
                    case "parentHash":
                        reader.Read();
                        header.ParentHash = serializer.Deserialize<Hash>(reader)!;
                        break;
                    case "number":
                        reader.Read();
                        var num = new Compact<U32>();
                        var u32 = new U32();
                        u32.InitFromHex((string)reader.Value);

                        num.Decode(CompactNum.CompactTo(u32.Value));

                        header.Number = num;
                        break;
                    case "stateRoot":
                        reader.Read();
                        header.StateRoot = serializer.Deserialize<Hash>(reader)!;
                        break;
                    case "extrinsicsRoot":
                        reader.Read();
                        header.ExtrinsicsRoot = serializer.Deserialize<Hash>(reader)!;
                        break;
                    case "digest":
                        reader.Read(); // startObject
                        var digest = new Digest();
                        reader.Read(); // Log property
                        reader.Read(); // Log value
                        // array of logs
                        List<DigestItem> dis = new List<DigestItem>();
                        reader.Read(); // read first val
                        while (reader.TokenType != JsonToken.EndArray)
                        {
                            DigestItem di = new DigestItem();
                            di.InitFromHex((string) reader.Value);
                            dis.Add(di);
                            reader.Read();
                        }
                        digest.Init(dis.ToArray());
                        //string val = reader.Value;
                        //digest.Decode((string)reader.Value)
                        header.Digest = digest;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new JsonReaderException();
            }
            reader.Read();
        }

        return header;
    }

    public override void WriteJson(JsonWriter writer, Header? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

