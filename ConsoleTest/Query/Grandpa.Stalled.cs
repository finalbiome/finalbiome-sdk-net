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
    public partial class Grandpa
    {
        /// <summary>
        ///  `true` if we are currently stalled.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.Model.Types.Base.Tuple_U32_U32> Stalled(byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("Grandpa", "Stalled", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.Model.Types.Base.Tuple_U32_U32>(req, hash, token);
        }
    }
}
