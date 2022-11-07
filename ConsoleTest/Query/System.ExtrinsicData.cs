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
    public partial class System
    {
        /// <summary>
        ///  Extrinsics data for the current block (maps an extrinsic's index to its data).<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.VecU8> ExtrinsicData(Ajuna.NetApi.Model.Types.Primitive.U32 u32, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.Twox64Concat,
            };
            IType[] keys = new IType[] {
                u32,
            };

            string req = RequestGenerator.GetStorage("System", "ExtrinsicData", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.VecU8>(req, hash, token);
        }
    }
}
