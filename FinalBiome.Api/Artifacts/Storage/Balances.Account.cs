///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Balances
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
    public async Task<FinalBiome.Api.Types.PalletBalances.AccountData?> Account(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("Balances", "Account", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletBalances.AccountData>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
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
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletBalances.AccountData?> AccountSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("Balances", "Account", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletBalances.AccountData>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

