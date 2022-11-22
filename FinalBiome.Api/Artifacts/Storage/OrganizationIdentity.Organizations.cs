///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.OrganizationIdentityEntries;
public class Organizations : StorageEntry<FinalBiome.Api.Types.PalletOrganizationIdentity.Types.OrganizationDetails>
{
    /// <summary>
    ///  Details of an organization.<br/>
    /// </summary>
    public Organizations(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "OrganizationIdentity", "Organizations")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

