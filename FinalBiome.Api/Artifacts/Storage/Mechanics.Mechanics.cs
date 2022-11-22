///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.MechanicsEntries;
public class MechanicsGet : StorageEntry<FinalBiome.Api.Types.PalletMechanics.Types.MechanicDetails>
{
    /// <summary>
    ///  Store of the Mechanics.<br/>
    /// </summary>
    public MechanicsGet(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.Primitive.U32 u32) :
        base(client, "Mechanics", "Mechanics")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

