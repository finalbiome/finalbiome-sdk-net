///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Mechanics
{
    /// <summary>
    ///  Store of the Mechanics.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletMechanics.Types.MechanicDetails?> MechanicsGet(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.Primitive.U32 u32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("Mechanics", "Mechanics", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletMechanics.Types.MechanicDetails>(address, hash);
    }
}

