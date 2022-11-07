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
        ///  The assets held by any given account.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.Tuple_Empty> Accounts(FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                accountId32,
                nonFungibleClassId,
                nonFungibleAssetId,
            };

            string req = RequestGenerator.GetStorage("NonFungibleAssets", "Accounts", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.Tuple_Empty>(req, hash, token);
        }
    }
}
