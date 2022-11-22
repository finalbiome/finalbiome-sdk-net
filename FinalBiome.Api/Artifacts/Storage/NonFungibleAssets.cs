///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.NonFungibleAssetsEntries;
public class NonFungibleAssets
{
    readonly Client client;
    public NonFungibleAssets(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  Details of asset classes.<br/>
    /// </summary>
    public Classes Classes(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId)
    {
        return new Classes(client, nonFungibleClassId);
    }

    /// <summary>
    ///  The classes owned by any given account.<br/>
    /// </summary>
    public ClassAccounts ClassAccounts(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId)
    {
        return new ClassAccounts(client, accountId32, nonFungibleClassId);
    }

    /// <summary>
    ///  The assets held by any given account.<br/>
    /// </summary>
    public Accounts Accounts(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId)
    {
        return new Accounts(client, accountId32, nonFungibleClassId, nonFungibleAssetId);
    }

    /// <summary>
    ///  Details of assets.<br/>
    /// </summary>
    public Assets Assets(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId)
    {
        return new Assets(client, nonFungibleClassId, nonFungibleAssetId);
    }

    /// <summary>
    ///  Attributes of an assets.<br/>
    /// </summary>
    public Attributes Attributes(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8)
    {
        return new Attributes(client, nonFungibleAssetId, boundedVecU8);
    }

    /// <summary>
    ///  Attributes of an asset class.<br/>
    /// </summary>
    public ClassAttributes ClassAttributes(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8)
    {
        return new ClassAttributes(client, nonFungibleClassId, boundedVecU8);
    }

    /// <summary>
    ///  Storing the next asset id<br/>
    /// </summary>
    public NextAssetId NextAssetId()
    {
        return new NextAssetId(client);
    }

    /// <summary>
    ///  Storing the next class id<br/>
    /// </summary>
    public NextClassId NextClassId()
    {
        return new NextClassId(client);
    }

}

