///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.TransactionPaymentEntries;
public class TransactionPayment
{
    readonly Client client;
    public TransactionPayment(Client client)
    {
        this.client = client;
    }
    public NextFeeMultiplier NextFeeMultiplier()
    {
        return new NextFeeMultiplier(client);
    }

    public StorageVersion StorageVersion()
    {
        return new StorageVersion(client);
    }

}

