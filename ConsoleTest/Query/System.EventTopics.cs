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
        ///  Mapping between a topic (represented by T::Hash) and a vector of indexes<br/>
        ///  of events in the `<Events<T>>` list.<br/>
        /// <para></para>
        ///  All topic vectors have deterministic storage locations depending on the topic. This<br/>
        ///  allows light-clients to leverage the changes trie storage tracking mechanism and<br/>
        ///  in case of changes fetch the list of events of interest.<br/>
        /// <para></para>
        ///  The value has the type `(T::BlockNumber, EventIndex)` because if we used only just<br/>
        ///  the `EventIndex` then in case if the topic has the same contents on the next block<br/>
        ///  no notification will be triggered thus the event might be lost.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.Model.Types.Base.VecTuple_U32_U32> EventTopics(FinalBiome.Sdk.PrimitiveTypes.H256 h256, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                h256,
            };

            string req = RequestGenerator.GetStorage("System", "EventTopics", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.Model.Types.Base.VecTuple_U32_U32>(req, hash, token);
        }
    }
}
