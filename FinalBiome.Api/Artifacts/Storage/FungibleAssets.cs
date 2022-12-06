///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.FungibleAssetsEntries;
public class FungibleAssets
{
    readonly Client client;
    public FungibleAssets(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  Details of an asset.<br/>
    /// </summary>
    public Assets Assets(FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId)
    {
        return new Assets(client, fungibleAssetId);
    }

    /// <summary>
    ///  Asset ids by owners (organizations).<br/>
    /// </summary>
    public AssetsOf AssetsOf(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId)
    {
        return new AssetsOf(client, accountId32, fungibleAssetId);
    }

    /// <summary>
    ///  The holdings of a specific account for a specific asset<br/>
    /// </summary>
    public Accounts Accounts(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId)
    {
        return new Accounts(client, accountId32, fungibleAssetId);
    }

    /// <summary>
    ///  Storing next asset id<br/>
    /// </summary>
    public NextAssetId NextAssetId()
    {
        return new NextAssetId(client);
    }

    /// <summary>
    ///  Storing assets which marked as Top Upped<br/>
    /// </summary>
    public TopUppedAssets TopUppedAssets()
    {
        return new TopUppedAssets(client);
    }

    /// <summary>
    ///  Accounts with assets which maybe need to top upped in next block.<br/>
    /// </summary>
    public TopUpQueue TopUpQueue(FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new TopUpQueue(client, fungibleAssetId, accountId32);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
