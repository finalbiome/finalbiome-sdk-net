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
    public partial class Balances
    {
        /// <summary>
        ///  Storage version of the pallet.<br/>
        /// <para></para>
        ///  This is set to v2.0.0 for new networks.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletBalances.Releases> StorageVersion(CancellationToken token)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("Balances", "StorageVersion", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletBalances.Releases>(req, token);
        }
    }
}
