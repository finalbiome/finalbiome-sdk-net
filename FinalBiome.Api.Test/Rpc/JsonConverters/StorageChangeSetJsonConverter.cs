using Newtonsoft.Json;
using FinalBiome.Api.Rpc.JsonConverters;
using FinalBiome.Api.Rpc;

namespace FinalBiome.Api.Test;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class StorageChangeSetJsonConverterTests
{
    [Test]
    public void StorageChangeSetJsonConverterTest()
    {
        string json = "{\"block\": \"0x4da35895e8dc0a8d76ab5c13dff23cc3a96f93218eb96f45db7e933d9c3a4cd6\",\"changes\": [[\"0xa3b3f3c9f10b799e5c0f367f30a54667f7c959581001db9593d2f756ba8202b8edeaa42c2163f68084a988529a0e2ec5e659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4e11d2df4e979aa105cf552e9544ebd2b500000000\",\"0x\"],[\"0xa3b3f3c9f10b799e5c0f367f30a54667f7c959581001db9593d2f756ba8202b8edeaa42c2163f68084a988529a0e2ec5e659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4ed82c12285b5d4551f88e8f6e7eb52b8101000000\",\"0x\"]]}";
        StorageChangeSet? val = JsonConvert.DeserializeObject<StorageChangeSet>(json, new JsonConverter[] { new StorageChangeSetJsonConverter(), new PrimitiveCodecTypeConverter<Hash>() });
        Assert.That(val?.Changes.Count, Is.EqualTo(2));
    }

    [Test]
    public void StorageChangeSetJsonConverterTest2()
    {
        string json = "{\"block\": \"0x4da35895e8dc0a8d76ab5c13dff23cc3a96f93218eb96f45db7e933d9c3a4cd6\",\"changes\": [[\"0xa3b3f3c9f10b799e5c0f367f30a54667f7c959581001db9593d2f756ba8202b8edeaa42c2163f68084a988529a0e2ec5e659a7a1628cdd93febc04a4e0646ea20e9f5f0ce097d9a05290d4a9e054df4e11d2df4e979aa105cf552e9544ebd2b500000000\",\"0x\"]]}";
        StorageChangeSet? val = JsonConvert.DeserializeObject<StorageChangeSet>(json, new JsonConverter[] { new StorageChangeSetJsonConverter(), new PrimitiveCodecTypeConverter<Hash>() });
        Assert.That(val?.Changes.Count, Is.EqualTo(1));
    }

    [Test]
    public void StorageChangeSetJsonConverterTest3()
    {
        string json = "{\"block\": \"0x4da35895e8dc0a8d76ab5c13dff23cc3a96f93218eb96f45db7e933d9c3a4cd6\",\"changes\": []}";
        StorageChangeSet? val = JsonConvert.DeserializeObject<StorageChangeSet>(json, new JsonConverter[] { new StorageChangeSetJsonConverter(), new PrimitiveCodecTypeConverter<Hash>() });
        Assert.That(val?.Changes.Count, Is.EqualTo(0));
    }
}
