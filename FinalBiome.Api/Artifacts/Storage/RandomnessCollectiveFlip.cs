///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
