///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class NonFungibleAssets
    {
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SetCharacteristic(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId classId, FinalBiome.Sdk.PalletSupport.Characteristics.Characteristic characteristic, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.PalletSupport.Characteristics.Characteristic> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.PalletSupport.Characteristics.Characteristic>();
            data.Create(organizationId, classId, characteristic);
            byte[] parameters = data.Encode();
            Method method = new Method(11, 4, parameters);
            ChargeType charge = ChargeTransactionPayment.Default();
            uint lifeTime = 0;
            token = CancellationToken.None;
            
            if (subscription is null)
            {
                await _client.client.Author.SubmitExtrinsicAsync(method, account, charge, lifeTime, (CancellationToken)token);
                return null;
            }
            else
            {
                string subscriptionId = await _client.client.Author.SubmitAndWatchExtrinsicAsync(subscription, method, account, charge, lifeTime, (CancellationToken)token);
                return subscriptionId;
            }
        }
    }
}
