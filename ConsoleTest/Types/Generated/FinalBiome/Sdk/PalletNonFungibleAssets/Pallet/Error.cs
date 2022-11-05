///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 189
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow,
        NoAvailableAssetId,
        NoAvailableClassId,
    /// <summary>
    /// Class name is too long.<br/>
    /// </summary>
        ClassNameTooLong,
    /// <summary>
    /// The signing account has no permission to do the operation.<br/>
    /// </summary>
        NoPermission,
    /// <summary>
    /// The given class Id is unknown.<br/>
    /// </summary>
        UnknownClass,
    /// <summary>
    /// The given asset Id is unknown.<br/>
    /// </summary>
        UnknownAsset,
    /// <summary>
    /// The bettor characteristic is wrong.<br/>
    /// </summary>
        WrongBettor,
    /// <summary>
    /// The purchased characteristic is wrong.<br/>
    /// </summary>
        WrongPurchased,
    /// <summary>
    /// Attribute value not supported<br/>
    /// </summary>
        AttributeConversionError,
    /// <summary>
    /// Attribute numeric value exceeds maximum value<br/>
    /// </summary>
        NumberAttributeValueExceedsMaximum,
    /// <summary>
    /// String attribute length limit exceeded<br/>
    /// </summary>
        StringAttributeLengthLimitExceeded,
    /// <summary>
    /// An attribute with the specified name already exists<br/>
    /// </summary>
        AttributeAlreadyExists,
    /// <summary>
    /// General error if any parameter is invalid<br/>
    /// </summary>
        WrongParameter,
    /// <summary>
    /// This characteristic is not supported by this asset<br/>
    /// </summary>
        UnsupportedCharacteristic,
    /// <summary>
    /// Characteristic is invalid<br/>
    /// </summary>
        WrongCharacteristic,
    /// <summary>
    /// The asset instance is locked<br/>
    /// </summary>
        Locked,
    /// <summary>
    /// The common error<br/>
    /// </summary>
        CommonError,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 189
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Sdk.PalletSupport.Errors.CommonError>
    {
        public override string TypeName() => "Error";
    }
}
