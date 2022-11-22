///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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

