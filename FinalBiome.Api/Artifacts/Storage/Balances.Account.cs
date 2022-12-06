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
public class Account : StorageEntry<FinalBiome.Api.Types.PalletBalances.AccountData>
{
    /// <summary>
    ///  The Balances pallet example of storing the balance of an account.<br/>
    /// <para></para>
    ///  # Example<br/>
    /// <para></para>
    ///  ```nocompile<br/>
    ///   impl pallet_balances::Config for Runtime {<br/>
    ///     type AccountStore = StorageMapShim&lt;Self::Account&lt;Runtime&gt;, frame_system::Provider&lt;Runtime&gt;, AccountId, Self::AccountData&lt;Balance&gt;&gt;<br/>
    ///   }<br/>
    ///  ```<br/>
    /// <para></para>
    ///  You can also store the balance of an account in the `System` pallet.<br/>
    /// <para></para>
    ///  # Example<br/>
    /// <para></para>
    ///  ```nocompile<br/>
    ///   impl pallet_balances::Config for Runtime {<br/>
    ///    type AccountStore = System<br/>
    ///   }<br/>
    ///  ```<br/>
    /// <para></para>
    ///  But this comes with tradeoffs, storing account balances in the system pallet stores<br/>
    ///  `frame_system` data alongside the account data contrary to storing account balances in the<br/>
    ///  `Balances` pallet, which uses a `StorageMap` to store balances data only.<br/>
    ///  NOTE: This is only used in the case that this pallet is used to store balances.<br/>
    /// </summary>
    public Account(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "Balances", "Account")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
