///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Sudo
{
    /// <summary>
    ///  The `AccountId` of the sudo key.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.SpCore.Crypto.AccountId32?> Key(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Sudo", "Key", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.SpCore.Crypto.AccountId32>(address, hash);
    }
}

