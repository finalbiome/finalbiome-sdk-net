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
    public partial class NonFungibleAssets
    {
        /// <summary>
        ///  The classes owned by any given account.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.Tuple_Empty> ClassAccounts(FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                accountId32,
                nonFungibleClassId,
            };

            string req = RequestGenerator.GetStorage("NonFungibleAssets", "ClassAccounts", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.Tuple_Empty>(req, hash, token);
        }
    }
}
