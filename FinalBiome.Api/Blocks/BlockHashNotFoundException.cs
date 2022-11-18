
namespace FinalBiome.Api.Blocks;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class BlockHashNotFoundException : Exception
{
    public BlockHashNotFoundException(Hash blockHash) : base(MessageFactory(blockHash))
    {

    }

    static string MessageFactory(Hash blockHash)
    {
        return $"Could not find a block with hash " +
               $"{blockHash.Encode().ToHex()}" +
               $" (perhaps it was on a non-finalized fork?)";
    }
}

