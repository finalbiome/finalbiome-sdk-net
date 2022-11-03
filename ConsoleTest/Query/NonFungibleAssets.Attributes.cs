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
        ///  Attributes of an assets.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletSupport.AttributeValue> Attributes(FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, FinalBiome.Sdk.BoundedVecU8 boundedVecU8, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                nonFungibleAssetId,
                boundedVecU8,
            };

            string req = RequestGenerator.GetStorage("NonFungibleAssets", "Attributes", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletSupport.AttributeValue>(req, token);
        }
    }
}
