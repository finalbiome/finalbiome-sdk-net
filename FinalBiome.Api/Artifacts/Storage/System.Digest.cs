///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  Digest of the current block, also part of the block header.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.SpRuntime.Generic.Digest.Digest?> Digest(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "Digest", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.SpRuntime.Generic.Digest.Digest>(address, hash);
    }
}

