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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 189
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.
    /// </summary>
        StorageOverflow,
        NoAvailableAssetId,
        NoAvailableClassId,
    /// <summary>
    /// Class name is too long.
    /// </summary>
        ClassNameTooLong,
    /// <summary>
    /// The signing account has no permission to do the operation.
    /// </summary>
        NoPermission,
    /// <summary>
    /// The given class Id is unknown.
    /// </summary>
        UnknownClass,
    /// <summary>
    /// The given asset Id is unknown.
    /// </summary>
        UnknownAsset,
    /// <summary>
    /// The bettor characteristic is wrong.
    /// </summary>
        WrongBettor,
    /// <summary>
    /// The purchased characteristic is wrong.
    /// </summary>
        WrongPurchased,
    /// <summary>
    /// Attribute value not supported
    /// </summary>
        AttributeConversionError,
    /// <summary>
    /// Attribute numeric value exceeds maximum value
    /// </summary>
        NumberAttributeValueExceedsMaximum,
    /// <summary>
    /// String attribute length limit exceeded
    /// </summary>
        StringAttributeLengthLimitExceeded,
    /// <summary>
    /// An attribute with the specified name already exists
    /// </summary>
        AttributeAlreadyExists,
    /// <summary>
    /// General error if any parameter is invalid
    /// </summary>
        WrongParameter,
    /// <summary>
    /// This characteristic is not supported by this asset
    /// </summary>
        UnsupportedCharacteristic,
    /// <summary>
    /// Characteristic is invalid
    /// </summary>
        WrongCharacteristic,
    /// <summary>
    /// The asset instance is locked
    /// </summary>
        Locked,
    /// <summary>
    /// The common error
    /// </summary>
        CommonError,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 189
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Sdk.PalletSupport.Errors.CommonError>
    {
        public override string TypeName() => "Error";
    }
}
