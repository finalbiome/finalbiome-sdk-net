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
        ///  The number of changes (both in terms of keys and underlying economic responsibilities)<br/>
        ///  in the "set" of Grandpa validators from genesis.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> CurrentSetId(CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("Grandpa", "CurrentSetId", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(req, token);
        }
    }
}
