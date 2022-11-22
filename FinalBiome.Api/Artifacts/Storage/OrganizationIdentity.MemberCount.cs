///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class OrganizationIdentity
{
    /// <summary>
    ///  Counts of members in organization.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U8?> MemberCount(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("OrganizationIdentity", "MemberCount", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U8>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Counts of members in organization.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U8?> MemberCountSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("OrganizationIdentity", "MemberCount", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U8>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

