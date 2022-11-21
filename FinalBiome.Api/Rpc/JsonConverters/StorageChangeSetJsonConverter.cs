using FinalBiome.Api.Utils;
using Newtonsoft.Json;

namespace FinalBiome.Api.Rpc.JsonConverters;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class StorageChangeSetJsonConverter : JsonConverter<StorageChangeSet>
{
    public override StorageChangeSet? ReadJson(JsonReader reader, Type objectType, StorageChangeSet? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        StorageChangeSet storageChangeSet = new StorageChangeSet();
        reader.Read();
        while (reader.TokenType != JsonToken.EndObject)
        {
            switch (reader.Value)
            {
                case "block":
                    reader.Read();
                    storageChangeSet.Block = serializer.Deserialize<Hash>(reader)!;
                    break;
                case "changes":
                    reader.Read(); // start Array Object
                    reader.Read(); // first value
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        reader.Read(); // skip start inner Array Object
                        string key = (string)reader.Value;
                        reader.Read(); // second value
                        string data = (string)reader.Value;
                        StorageChange storageChange = new StorageChange(HexUtils.HexToBytes(key).ToList(), data);
                        storageChangeSet.AddStorageChange(storageChange);
                        reader.Read(); // exit from inner array
                    }
                    reader.Read(); // exit from changes arrays
                    break;
                default:
                    throw new JsonReaderException();
            }
            reader.Read();
        }
        return storageChangeSet;
    }

    public override void WriteJson(JsonWriter writer, StorageChangeSet? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

