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
        ///  Details of assets.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletSupport.TypesNfa.AssetDetails> Assets(FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                nonFungibleClassId,
                nonFungibleAssetId,
            };

            string req = RequestGenerator.GetStorage("NonFungibleAssets", "Assets", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletSupport.TypesNfa.AssetDetails>(req, token);
        }
    }
}
