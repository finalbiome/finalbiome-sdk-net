using System;
using FinalBiome.Api.Rpc.Types;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using Newtonsoft.Json;

namespace FinalBiome.Api.Rpc.JsonConverters;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
public class SubstrateTxStatusJsonConverter : JsonConverter<SubstrateTxStatus>
{
    public override SubstrateTxStatus? ReadJson(JsonReader reader, Type objectType, SubstrateTxStatus? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        string value;
        string? data = null;
        List<string>? peers = null;

        if (reader.TokenType == JsonToken.String)
        {
            value = (string)reader.Value!;
        }
        else if (reader.TokenType == JsonToken.StartObject)
        {
            reader.Read();
            value = (string)reader.Value!;
            reader.Read();
            if (reader.TokenType != JsonToken.StartArray)
            {
                data = (string)reader.Value!;
            }
            else
            {
                // Broadcast status with List<string>
                while (reader.TokenType != JsonToken.EndArray)
                {
                    peers = new List<string>
                    {
                        (string)reader.Value!
                    };
                    reader.Read();
                }
            }
        }
        else
        {
            throw new JsonReaderException($"Found an unknown token: ({reader.TokenType}){reader.Value}");
        }

        var r = Enum.TryParse(value, true, out InnerSubstrateTxStatus status);
        if (!r) throw new JsonReaderException($"Found an unknown response status: {value}");

        SubstrateTxStatus result = new();
        switch (status)
        {
            case InnerSubstrateTxStatus.Future:
                result.Init(status, new BaseVoid());
                return result;
            case InnerSubstrateTxStatus.Ready:
                result.Init(status, new BaseVoid());
                return result;
            case InnerSubstrateTxStatus.Broadcast:
                if (peers is null) throw new Exception("Something wrong");
                List<Str> peersArr = new();
                foreach (var peer in peers)
                {
                    peersArr.Add(Str.From(peer));
                }
                Vec<Str> peersIds = new();
                peersIds.Init(peersArr.ToArray());
                result.Init(status, peersIds);
                return result;
            case InnerSubstrateTxStatus.InBlock:
                Hash hash = new();
                if (data is null) throw new Exception("Something wrong");
                hash.InitFromHex(data);
                result.Init(status, hash);
                return result;
            case InnerSubstrateTxStatus.Retracted:
                Hash hash1 = new();
                if (data is null) throw new Exception("Something wrong");
                hash1.InitFromHex(data);
                result.Init(status, hash1);
                return result;
            case InnerSubstrateTxStatus.FinalityTimeout:
                Hash hash2 = new();
                if (data is null) throw new Exception("Something wrong");
                hash2.InitFromHex(data);
                result.Init(status, hash2);
                return result;
            case InnerSubstrateTxStatus.Finalized:
                Hash hash3 = new();
                if (data is null) throw new Exception("Something wrong");
                hash3.InitFromHex(data);
                result.Init(status, hash3);
                return result;
            case InnerSubstrateTxStatus.Usurped:
                Hash hash4 = new();
                if (data is null) throw new Exception("Something wrong");
                hash4.InitFromHex(data);
                result.Init(status, hash4);
                return result;
            case InnerSubstrateTxStatus.Dropped:
                result.Init(status, new BaseVoid());
                return result;
            case InnerSubstrateTxStatus.Invalid:
                result.Init(status, new BaseVoid());
                return result;
            default:
                throw new JsonReaderException($"Found an unknown response status: {value}");
        }
    }

    public override void WriteJson(JsonWriter writer, SubstrateTxStatus? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

