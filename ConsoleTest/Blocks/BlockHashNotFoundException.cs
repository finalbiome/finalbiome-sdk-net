using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.Blocks
{
    public class BlockHashNotFoundException : Exception
    {
        public BlockHashNotFoundException(Hash blockHash) : base(MessageFactory(blockHash))
        {

        }

        static string MessageFactory(Hash blockHash)
        {
            return $"Could not find a block with hash " +
                   $"{Ajuna.NetApi.Utils.Bytes2HexString(blockHash.Encode())}" +
                   $" (perhaps it was on a non-finalized fork?)";
        }
    }
}

