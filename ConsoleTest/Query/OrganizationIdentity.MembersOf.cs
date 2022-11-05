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
    public partial class OrganizationIdentity
    {
        /// <summary>
        ///  Members of organizations.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.Tuple_Empty> MembersOf(FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId320, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                accountId32,
                accountId320,
            };

            string req = RequestGenerator.GetStorage("OrganizationIdentity", "MembersOf", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.Tuple_Empty>(req, token);
        }
    }
}
