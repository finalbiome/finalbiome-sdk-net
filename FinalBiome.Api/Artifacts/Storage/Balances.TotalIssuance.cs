///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.BalancesEntries;
public class TotalIssuance : StorageEntry<FinalBiome.Api.Types.Primitive.U128>
{
    /// <summary>
    ///  The total units issued in the system.<br/>
    /// </summary>
    public TotalIssuance(Client client) :
        base(client, "Balances", "TotalIssuance")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
