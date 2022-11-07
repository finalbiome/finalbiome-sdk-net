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
        ///  Details of an asset.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletFungibleAssets.Types.AssetDetails> Assets(FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                fungibleAssetId,
            };

            string req = RequestGenerator.GetStorage("FungibleAssets", "Assets", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletFungibleAssets.Types.AssetDetails>(req, hash, token);
        }
    }
}
