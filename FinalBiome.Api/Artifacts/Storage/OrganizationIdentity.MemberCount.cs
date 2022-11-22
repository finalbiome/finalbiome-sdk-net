///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.OrganizationIdentityEntries;
public class MemberCount : StorageEntry<FinalBiome.Api.Types.Primitive.U8>
{
    /// <summary>
    ///  Counts of members in organization.<br/>
    /// </summary>
    public MemberCount(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "OrganizationIdentity", "MemberCount")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

