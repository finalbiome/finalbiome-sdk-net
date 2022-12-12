///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.RandomnessCollectiveFlipEntries;
public class RandomMaterial : StorageEntry<FinalBiome.Api.Types.PrimitiveTypes.BoundedVecH256>
{
    /// <summary>
    ///  Series of block headers from the last 81 blocks that acts as random seed material. This<br/>
    ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of<br/>
    ///  the oldest hash.<br/>
    /// </summary>
    public RandomMaterial(Client client) :
        base(client, "RandomnessCollectiveFlip", "RandomMaterial")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
