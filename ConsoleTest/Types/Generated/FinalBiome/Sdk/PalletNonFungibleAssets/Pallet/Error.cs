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
    public enum InnerError : byte
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue = 0,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow = 1,
        NoAvailableAssetId = 2,
        NoAvailableClassId = 3,
    /// <summary>
    /// Class name is too long.<br/>
    /// </summary>
        ClassNameTooLong = 4,
    /// <summary>
    /// The signing account has no permission to do the operation.<br/>
    /// </summary>
        NoPermission = 5,
    /// <summary>
    /// The given class Id is unknown.<br/>
    /// </summary>
        UnknownClass = 6,
    /// <summary>
    /// The given asset Id is unknown.<br/>
    /// </summary>
        UnknownAsset = 7,
    /// <summary>
    /// The bettor characteristic is wrong.<br/>
    /// </summary>
        WrongBettor = 8,
    /// <summary>
    /// The purchased characteristic is wrong.<br/>
    /// </summary>
        WrongPurchased = 9,
    /// <summary>
    /// Attribute value not supported<br/>
    /// </summary>
        AttributeConversionError = 10,
    /// <summary>
    /// Attribute numeric value exceeds maximum value<br/>
    /// </summary>
        NumberAttributeValueExceedsMaximum = 11,
    /// <summary>
    /// String attribute length limit exceeded<br/>
    /// </summary>
        StringAttributeLengthLimitExceeded = 12,
    /// <summary>
    /// An attribute with the specified name already exists<br/>
    /// </summary>
        AttributeAlreadyExists = 13,
    /// <summary>
    /// General error if any parameter is invalid<br/>
    /// </summary>
        WrongParameter = 14,
    /// <summary>
    /// This characteristic is not supported by this asset<br/>
    /// </summary>
        UnsupportedCharacteristic = 15,
    /// <summary>
    /// Characteristic is invalid<br/>
    /// </summary>
        WrongCharacteristic = 16,
    /// <summary>
    /// The asset instance is locked<br/>
    /// </summary>
        Locked = 17,
    /// <summary>
    /// The common error<br/>
    /// </summary>
        CommonError = 18,
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
