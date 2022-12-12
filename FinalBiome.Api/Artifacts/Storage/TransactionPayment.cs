///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
