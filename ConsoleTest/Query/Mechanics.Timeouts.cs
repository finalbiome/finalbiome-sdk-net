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
    public partial class Mechanics
    {
        /// <summary>
        ///  Schedule when mechanics time out<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.Tuple_Empty> Timeouts(Ajuna.NetApi.Model.Types.Primitive.U32 u32, FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, Ajuna.NetApi.Model.Types.Primitive.U32 u320, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                u32,
                accountId32,
                u320,
            };

            string req = RequestGenerator.GetStorage("Mechanics", "Timeouts", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.Tuple_Empty>(req, hash, token);
        }
    }
}
