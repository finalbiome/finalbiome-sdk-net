///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.OrganizationIdentityEntries;
public class UsersOf : StorageEntry<FinalBiome.Api.Types.Tuple_Empty>
{
    /// <summary>
    ///  Users of organizations.<br/>
    /// <para></para>
    ///  Stores users who has been onboarded into the game<br/>
    /// </summary>
    public UsersOf(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId320) :
        base(client, "OrganizationIdentity", "UsersOf")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(accountId320, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

