///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class Account : StorageEntry<FinalBiome.Api.Types.FrameSystem.AccountInfo>
{
    /// <summary>
    ///  The full account information for a particular account ID.<br/>
    /// </summary>
    public Account(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "System", "Account")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

