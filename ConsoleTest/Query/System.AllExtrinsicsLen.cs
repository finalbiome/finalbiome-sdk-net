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
        ///  Total length (in bytes) for all extrinsics put together, for the current block.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> AllExtrinsicsLen(CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("System", "AllExtrinsicsLen", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(req, token);
        }
    }
}
