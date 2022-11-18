using System;
using System.Collections.Generic;
using System.Net;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using Newtonsoft.Json;
namespace FinalBiome.Api.Rpc.JsonConverters;

public class ChainBlockJsonConverter : JsonConverter<ChainBlock>
{
    public override ChainBlock ReadJson(JsonReader reader, Type objectType, ChainBlock? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        ChainBlock chainBlock = new ChainBlock();
        reader.Read();
        while (reader.TokenType != JsonToken.EndObject)
        {
            switch (reader.Value)
            {
                case "header":

                    reader.Read();
                    chainBlock.Header = serializer.Deserialize<Header>(reader)!;
                    reader.Read();
                    break;

                case "extrinsics":

                    reader.Read(); // start Array Object
                    // because ChainBlockExtrinsic = Vec<U8>;
                    List<Vec<U8>> extrinsicsList = new List<Vec<U8>>();
                    reader.Read();
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        Vec<U8> extrinsic = new Vec<U8>();
                        extrinsic.InitFromHex((string)reader.Value);
                        extrinsicsList.Add(extrinsic);
                        reader.Read();
                    }
                    Vec<Vec<U8>> extrinsics = new Vec<Vec<U8>>();
                    extrinsics.Init(extrinsicsList.ToArray());
                    chainBlock.Extrinsics = extrinsics;
                    break;
                default:
                    throw new JsonReaderException();
            }
            reader.Read();
        }
        return chainBlock;
    }

    public override void WriteJson(JsonWriter writer, ChainBlock? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

