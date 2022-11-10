using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Events
{
    public class EventClient
    {
        readonly Client _client;

        public EventClient(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// /// Obtain events at some block hash.
        ///
        /// # Warning
        ///
        /// This call only supports blocks produced since the most recent
        /// runtime upgrade. You can attempt to retrieve events from older blocks,
        /// but may run into errors attempting to work with them.
        /// </summary>
        /// <param name="blockHash"></param>
        public async Task<Events> At(Hash? blockHash = null)
        {
            Hash hash;
            if (blockHash is not null) hash = blockHash;
            else
            {
                hash = await _client.client.Chain.GetBlockHashAsync();
            }

            var events = await _client.Query.System.Events(hash.Encode());

            return new Events(hash, events);
        }
    }
}

