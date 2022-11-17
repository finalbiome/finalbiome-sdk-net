///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class OrganizationIdentity
{
    /// <summary>
    ///  Details of an organization.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletOrganizationIdentity.Types.OrganizationDetails?> Organizations(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("OrganizationIdentity", "Organizations", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletOrganizationIdentity.Types.OrganizationDetails>(address, hash);
    }
}

