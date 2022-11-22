///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.BalancesEntries;
public class Balances
{
    readonly Client client;
    public Balances(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  The total units issued in the system.<br/>
    /// </summary>
    public TotalIssuance TotalIssuance()
    {
        return new TotalIssuance(client);
    }

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
    public Account Account(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new Account(client, accountId32);
    }

    /// <summary>
    ///  Any liquidity locks on some account balances.<br/>
    ///  NOTE: Should only be accessed when setting, changing and freeing a lock.<br/>
    /// </summary>
    public Locks Locks(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new Locks(client, accountId32);
    }

    /// <summary>
    ///  Named reserves on some account balances.<br/>
    /// </summary>
    public Reserves Reserves(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new Reserves(client, accountId32);
    }

    /// <summary>
    ///  Storage version of the pallet.<br/>
    /// <para></para>
    ///  This is set to v2.0.0 for new networks.<br/>
    /// </summary>
    public StorageVersion StorageVersion()
    {
        return new StorageVersion(client);
    }

}

