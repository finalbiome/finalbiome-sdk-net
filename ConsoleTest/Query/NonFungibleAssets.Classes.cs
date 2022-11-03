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
        ///  Details of asset classes.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletSupport.TypesNfa.ClassDetails> Classes(FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                nonFungibleClassId,
            };

            string req = RequestGenerator.GetStorage("NonFungibleAssets", "Classes", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletSupport.TypesNfa.ClassDetails>(req, token);
        }
    }
}
