///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Newtonsoft.Json.Linq;

namespace FinalBiome.Sdk.Query
{
    public partial class Balances
    {
        /// <summary>
        ///  The Balances pallet example of storing the balance of an account.<br/>
        /// <para></para>
        ///  # Example<br/>
        /// <para></para>
        ///  ```nocompile<br/>
        ///   impl pallet_balances::Config for Runtime {<br/>
        ///     type AccountStore = StorageMapShim<Self::Account<Runtime>, frame_system::Provider<Runtime>, AccountId, Self::AccountData<Balance>><br/>
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
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<FinalBiome.Sdk.PalletBalances.AccountData> Account(FinalBiome.Sdk.SpCore.Crypto.AccountId32 accountId32, byte[]? hash = null, CancellationToken? token = null)
        {
            Storage.Hasher[] hashers = new Storage.Hasher[] {
                Storage.Hasher.BlakeTwo128Concat,
            };
            IType[] keys = new IType[] {
                accountId32,
            };

            string req = RequestGenerator.GetStorage("Balances", "Account", Storage.Type.Map, hashers, keys);

            return await _client.client.GetStorageAsync<FinalBiome.Sdk.PalletBalances.AccountData>(req, hash, token);
        }
    }
}
