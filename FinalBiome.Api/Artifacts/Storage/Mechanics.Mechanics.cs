///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.MechanicsEntries;
public class MechanicsGet : StorageEntry<FinalBiome.Api.Types.PalletMechanics.Types.MechanicDetails>
{
    /// <summary>
    ///  Store of the Mechanics.<br/>
    /// </summary>
    public MechanicsGet(Client client, FinalBiome.Api.Types.PalletSupport.GamerAccount gamerAccount, FinalBiome.Api.Types.Primitive.U32 u32) :
        base(client, "Mechanics", "Mechanics")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(gamerAccount, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
