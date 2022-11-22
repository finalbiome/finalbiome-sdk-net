///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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

