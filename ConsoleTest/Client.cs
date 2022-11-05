using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;

namespace FinalBiome.Sdk
{
    public class Client
    {
        public SubstrateClient client;
        public FinalBiome.Sdk.Query.Query Query;
        public FinalBiome.Sdk.Transactions.Transactions Tx;

        public Client(string url)
        {
            client = new SubstrateClient(new Uri(url), ChargeTransactionPayment.Default());

            Query = new Query.Query(this);
            Tx = new Transactions.Transactions(this);
        }
    }
}

