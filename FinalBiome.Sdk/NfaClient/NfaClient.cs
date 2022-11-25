namespace FinalBiome.Sdk;

public class NfaClient
{
    readonly Client client;

    public NfaClient(Client client)
    {
        this.client = client;
    }

    public static async Task<NfaClient> Create(Client client)
    {
        NfaClient nfaClient = new(client);

        return nfaClient;
    }
}
