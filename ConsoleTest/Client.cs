using System;
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Primitive;

namespace FinalBiome.Sdk
{
    public class Client
    {
        public SubstrateClient client;
        public FinalBiome.Sdk.Query.Query Query;

        public Client(string url)
        {
            client = new SubstrateClient(new Uri(url), ChargeTransactionPayment.Default());

            Query = new Query.Query(this);
        }
    }
}

