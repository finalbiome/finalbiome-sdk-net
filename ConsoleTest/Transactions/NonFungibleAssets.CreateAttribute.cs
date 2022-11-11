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
        /// <summary>
        /// Creates an attribute for the non fungible asset class.<br/>
        /// The origin must be Signed, be a member of the organization<br/>
        /// and that organization must be a owner of the asset class.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> CreateAttribute(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId classId, FinalBiome.Sdk.PalletSupport.Attribute attribute, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.PalletSupport.Attribute> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.PalletSupport.Attribute>();
            data.Create(organizationId, classId, attribute);
            byte[] parameters = data.Encode();
            Method method = new Method(11, 2, parameters);
            ChargeType charge = ChargeTransactionPayment.Default();
            uint lifeTime = 0;
            token = CancellationToken.None;
            
            if (subscription is null)
            {
                return (await _client.client.Author.SubmitExtrinsicAsync(method, account, charge, lifeTime, (CancellationToken)token)).Value;
            }
            else
            {
                string subscriptionId = await _client.client.Author.SubmitAndWatchExtrinsicAsync(subscription, method, account, charge, lifeTime, (CancellationToken)token);
                return subscriptionId;
            }
        }
    }
}
