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
        ///  A mapping from grandpa set ID to the index of the *most recent* session for which its
        ///  members were responsible.
        /// 
        ///  TWOX-NOTE: `SetId` is not under user control.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U32> SetIdSession(Ajuna.NetApi.Model.Types.Primitive.U64 u64, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.Twox64Concat,
            };
            IType[] keys = new IType[] {
                u64,
            };

            string req = RequestGenerator.GetStorage("Grandpa", "SetIdSession", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U32>(req, token);
        }
    }
}
