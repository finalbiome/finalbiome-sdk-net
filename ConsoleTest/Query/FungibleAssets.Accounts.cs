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
    public partial class FungibleAssets
    {
        /// <summary>
        ///  The holdings of a specific account for a specific asset<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletFungibleAssets.Types.AssetAccount> Accounts(FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                accountId32,
                fungibleAssetId,
            };

            string req = RequestGenerator.GetStorage("FungibleAssets", "Accounts", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletFungibleAssets.Types.AssetAccount>(req, token);
        }
    }
}
