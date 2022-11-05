///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Newtonsoft.Json.Linq;

namespace FinalBiome.Sdk.Query
{
    public partial class System
    {
        /// <summary>
        ///  Events deposited for the current block.<br/>
        /// <para></para>
        ///  NOTE: The item is unbound and should therefore never be read on chain.<br/>
        ///  It could otherwise inflate the PoV size of a block.<br/>
        /// <para></para>
        ///  Events have a large in-memory size. Box the events to not go out-of-memory<br/>
        ///  just in case someone still reads them from within the runtime.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.FrameSystem.VecEventRecord> Events(CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("System", "Events", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.FrameSystem.VecEventRecord>(req, token);
        }
    }
}
