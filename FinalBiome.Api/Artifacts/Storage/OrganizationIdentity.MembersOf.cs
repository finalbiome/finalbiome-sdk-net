///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.OrganizationIdentityEntries;
public class MembersOf : StorageEntry<FinalBiome.Api.Types.Tuple_Empty>
{
    /// <summary>
    ///  Members of organizations.<br/>
    /// </summary>
    public MembersOf(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId320) :
        base(client, "OrganizationIdentity", "MembersOf")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(accountId320, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

