///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Tx
{
    public partial class Users
    {
        /// <summary>
        /// Register a new account.<br/>
        /// <para></para>
        /// User can register only once.<br/>
        /// </summary>
        public StaticTxPayload SignUp(FinalBiome.Api.Types.BoundedVecU8 sign)
        {
            byte palletIsx = 9;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            sign.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
