///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class TemplateModule
    {
        /// <summary>
        /// An example dispatchable that may throw a custom error.<br/>
        /// </summary>
        public StaticTxPayload CauseError()
        {
            byte palletIsx = 8;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
