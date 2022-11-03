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
        ///  Counts of members in organization.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U8> MemberCount(FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                accountId32,
            };

            string req = RequestGenerator.GetStorage("OrganizationIdentity", "MemberCount", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U8>(req, token);
        }
    }
}
