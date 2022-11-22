///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class OrganizationIdentity
{
    /// <summary>
    ///  Details of an members.<br/>
    ///  ATTENTION: The store also includes organizations.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Tuple_Empty?> Members(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("OrganizationIdentity", "Members", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Tuple_Empty>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Details of an members.<br/>
    ///  ATTENTION: The store also includes organizations.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Tuple_Empty?> MembersSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("OrganizationIdentity", "Members", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Tuple_Empty>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

