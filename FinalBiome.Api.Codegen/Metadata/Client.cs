using System;
using System.Net.WebSockets;
using FinalBiome.Api.Codegen.Metadata;
using StreamJsonRpc;

namespace FinalBiome.Api.Codegen.MetadataNs
{
    public class Client
    {
        readonly JsonRpc rpc;
        readonly Uri url;
        MetaDataV14? metadata;

        Client(JsonRpc rpc, Uri url)
        {
            this.rpc = rpc;
            this.url = url;

        }

        /// <summary>
        /// Construct a new [`Client`] using default settings which
        /// point to a locally running node on `ws://127.0.0.1:9944`.
        /// </summary>
        /// <returns></returns>
        public static async Task<Client> New()
        {
            string url = "ws://127.0.0.1:9944";
            return await Client.FromUrl(url);
        }

        /// <summary>
        /// Construct a new [`Client`], providing a URL to connect to.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<Client> FromUrl(string url)
        {
            return await Client.Build(new Uri(url));
        }

        internal static async Task<Client> Build(Uri url)
        {
            ClientWebSocket ws = new();
            await ws.ConnectAsync(url, CancellationToken.None);
            JsonRpc rpc = new(new WebSocketMessageHandler(ws));
            rpc.StartListening();
            return new Client(rpc, url);
        }

        private async Task<string> getMetadata()
        {
#pragma warning disable CA1825
            return await rpc.InvokeWithParameterObjectAsync<string>("state_getMetadata", new object[] { });
#pragma warning restore CA1825
        }

        public async Task<MetaDataV14> Metadata()
        {
            if (this.metadata is null)
            {
                string rawMetadata = await getMetadata();
                var md = new RuntimeMetadata();
                md.Init(rawMetadata);
                this.metadata = new MetaDataV14(md, url.OriginalString);
            }
            return this.metadata;
        }
    }
}

