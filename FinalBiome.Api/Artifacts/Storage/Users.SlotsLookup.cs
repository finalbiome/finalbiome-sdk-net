///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.UsersEntries;
public class SlotsLookup : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  Lookup from an account to the slot number.<br/>
    /// </summary>
    public SlotsLookup(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "Users", "SlotsLookup")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
