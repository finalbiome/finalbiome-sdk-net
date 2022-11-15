using FinalBiome.Api.Types;
using Newtonsoft.Json;

namespace FinalBiome.Api.Rpc.JsonConverters;

public class PrimitiveCodecTypeConverter<T> : JsonConverter<T> where T : Codec, new()
{
    public override T? ReadJson(JsonReader reader, Type objectType, T? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value is null) return null;
        string hexString = (string) reader.Value;
        T value = new T();
        value.InitFromHex(hexString);
        return value;
    }

    public override void WriteJson(JsonWriter writer, T? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
        //writer.WriteValue(JsonConvert.SerializeObject(value));
    }
}

