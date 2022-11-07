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
    public partial class RandomnessCollectiveFlip
    {
        /// <summary>
        ///  Series of block headers from the last 81 blocks that acts as random seed material. This<br/>
        ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of<br/>
        ///  the oldest hash.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PrimitiveTypes.BoundedVecH256> RandomMaterial(byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
            };
            IType[] keys = new IType[] {
            };

            string req = RequestGenerator.GetStorage("RandomnessCollectiveFlip", "RandomMaterial", Storage.Type.Plain, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PrimitiveTypes.BoundedVecH256>(req, hash, token);
        }
    }
}
