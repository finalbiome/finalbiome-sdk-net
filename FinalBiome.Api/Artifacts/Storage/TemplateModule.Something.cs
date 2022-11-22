///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class TemplateModule
{
    public async Task<FinalBiome.Api.Types.Primitive.U32?> Something(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("TemplateModule", "Something", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U32>(address, hash);
    }

    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U32?> SomethingSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("TemplateModule", "Something", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

