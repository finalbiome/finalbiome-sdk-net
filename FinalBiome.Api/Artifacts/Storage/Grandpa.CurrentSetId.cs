///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Grandpa
{
    /// <summary>
    ///  The number of changes (both in terms of keys and underlying economic responsibilities)<br/>
    ///  in the "set" of Grandpa validators from genesis.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U64?> CurrentSetId(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "CurrentSetId", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U64>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The number of changes (both in terms of keys and underlying economic responsibilities)<br/>
    ///  in the "set" of Grandpa validators from genesis.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U64?> CurrentSetIdSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "CurrentSetId", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U64>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

