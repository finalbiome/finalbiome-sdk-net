///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.RandomnessCollectiveFlipEntries;
public class RandomnessCollectiveFlip
{
    readonly Client client;
    public RandomnessCollectiveFlip(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  Series of block headers from the last 81 blocks that acts as random seed material. This<br/>
    ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of<br/>
    ///  the oldest hash.<br/>
    /// </summary>
    public RandomMaterial RandomMaterial()
    {
        return new RandomMaterial(client);
    }

}

