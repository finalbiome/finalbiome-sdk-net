using System;
using FinalBiome.Api.Types;
using Newtonsoft.Json;

namespace FinalBiome.Api.Rpc.JsonConverters;

public class ChainBlockResponseJsonConverter : JsonConverter<ChainBlockResponse>
{
    public override ChainBlockResponse ReadJson(JsonReader reader, Type objectType, ChainBlockResponse? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        ChainBlockResponse chainBlockResponse = new ChainBlockResponse();

        reader.Read();
        while (reader.TokenType != JsonToken.EndObject)
        {
            switch (reader.Value)
            {
                case "block":

                    reader.Read();
                    chainBlockResponse.Block = serializer.Deserialize<ChainBlock>(reader)!;
                    //reader.Read();
                    break;

                case "justifications":

                    reader.Read();
                    Option<Justifications> justifications = new Option<Justifications>();
                    if (reader.Value is null)
                    {
                        justifications.Init(null);
                    } else
                    {
                        justifications.InitFromHex((string)reader.Value);
                    }
                    chainBlockResponse.Justifications = justifications;

                    break;
                default:
                    throw new JsonReaderException();

            }
            reader.Read();
        }
        return chainBlockResponse;
    }

    public override void WriteJson(JsonWriter writer, ChainBlockResponse? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

