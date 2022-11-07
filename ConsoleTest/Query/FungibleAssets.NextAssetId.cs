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
        ///  Storing next asset id<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId> NextAssetId(byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("FungibleAssets", "NextAssetId", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId>(req, hash, token);
        }
    }
}
