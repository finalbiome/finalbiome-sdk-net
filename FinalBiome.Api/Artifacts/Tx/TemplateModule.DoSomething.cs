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
    public partial class TemplateModule
    {
        /// <summary>
        /// An example dispatchable that takes a singles value as a parameter, writes the value to<br/>
        /// storage and emits an event. This function must be dispatched by a signed extrinsic.<br/>
        /// </summary>
        public StaticTxPayload DoSomething(FinalBiome.Api.Types.Primitive.U32 something)
        {
            byte palletIsx = 8;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            something.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
