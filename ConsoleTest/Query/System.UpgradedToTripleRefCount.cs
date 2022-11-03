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
        ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False
        ///  (default) if not.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<Ajuna.NetApi.Model.Types.Primitive.Bool> UpgradedToTripleRefCount(CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("System", "UpgradedToTripleRefCount", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.Bool>(req, token);
        }
    }
}
