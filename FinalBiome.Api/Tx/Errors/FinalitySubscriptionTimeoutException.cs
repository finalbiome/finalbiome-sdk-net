using System;
using FinalBiome.Api.Extensions;
namespace FinalBiome.Api.Tx
{
    /// <summary>
    /// The finality subscription expired (after ~512 blocks we give up if the
    /// block hasn't yet been finalized).
    /// </summary>
    public class FinalitySubscriptionTimeoutException : Exception
    {
        public FinalitySubscriptionTimeoutException(IEnumerable<byte> extHash) : base(MessageFactory(extHash))
        {
        }

        static string MessageFactory(IEnumerable<byte> extHash)
        {
            return $"The finality subscription expired " +
                   $"for transaction " +
                   $"{extHash.ToHex()}";
        }
    }
}

