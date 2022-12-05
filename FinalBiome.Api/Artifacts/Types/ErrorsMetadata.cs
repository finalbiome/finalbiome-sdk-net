///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Types;
public class ErrorsMetadata
{
    private ErrorsMetadata() { }
    private static readonly Dictionary<(byte module, byte error), DecodedModuleError> errors = new()
    {
        { (0, 0), new("System", "InvalidSpecName", "The name of specification does not match between the current runtime and the new runtime.") },
        { (0, 1), new("System", "SpecVersionNeedsToIncrease", "The specification version is not allowed to decrease between the current runtime and the new runtime.") },
        { (0, 2), new("System", "FailedToExtractRuntimeVersion", "Failed to extract the runtime version from the new runtime.  Either calling `Core_version` or decoding `RuntimeVersion` failed.") },
        { (0, 3), new("System", "NonDefaultComposite", "Suicide called when the account has non-default composite data.") },
        { (0, 4), new("System", "NonZeroRefCount", "There is a non-zero reference count preventing the account from being purged.") },
        { (0, 5), new("System", "CallFiltered", "The origin filter prevent the call to be dispatched.") },
        { (4, 0), new("Grandpa", "PauseFailed", "Attempt to signal GRANDPA pause when the authority set isn't live (either paused or already pending pause).") },
        { (4, 1), new("Grandpa", "ResumeFailed", "Attempt to signal GRANDPA resume when the authority set isn't paused (either live or already pending resume).") },
        { (4, 2), new("Grandpa", "ChangePending", "Attempt to signal GRANDPA change with one already pending.") },
        { (4, 3), new("Grandpa", "TooSoon", "Cannot signal forced change so soon after last.") },
        { (4, 4), new("Grandpa", "InvalidKeyOwnershipProof", "A key ownership proof provided as part of an equivocation report is invalid.") },
        { (4, 5), new("Grandpa", "InvalidEquivocationProof", "An equivocation proof provided as part of an equivocation report is invalid.") },
        { (4, 6), new("Grandpa", "DuplicateOffenceReport", "A given equivocation report is valid but already previously reported.") },
        { (5, 0), new("Balances", "VestingBalance", "Vesting balance too high to send value") },
        { (5, 1), new("Balances", "LiquidityRestrictions", "Account liquidity restrictions prevent withdrawal") },
        { (5, 2), new("Balances", "InsufficientBalance", "Balance too low to send value") },
        { (5, 3), new("Balances", "ExistentialDeposit", "Value too low to create account due to existential deposit") },
        { (5, 4), new("Balances", "KeepAlive", "Transfer/payment would kill account") },
        { (5, 5), new("Balances", "ExistingVestingSchedule", "A vesting schedule already exists for this account") },
        { (5, 6), new("Balances", "DeadAccount", "Beneficiary account must pre-exist") },
        { (5, 7), new("Balances", "TooManyReserves", "Number of named reserves exceed MaxReserves") },
        { (7, 0), new("Sudo", "RequireSudo", "Sender must be the Sudo account") },
        { (8, 0), new("TemplateModule", "NoneValue", "Error names should be descriptive.") },
        { (8, 1), new("TemplateModule", "StorageOverflow", "Errors should have helpful documentation associated with them.") },
        { (9, 0), new("OrganizationIdentity", "NoneValue", "Error names should be descriptive.") },
        { (9, 1), new("OrganizationIdentity", "StorageOverflow", "Errors should have helpful documentation associated with them.") },
        { (9, 2), new("OrganizationIdentity", "OrganizationExists", "Cannot create the organization because it already exists.") },
        { (9, 3), new("OrganizationIdentity", "OrganizationNameTooLong", "Organization name is too long.") },
        { (9, 4), new("OrganizationIdentity", "NotOrganization", "Account is not an organization") },
        { (9, 5), new("OrganizationIdentity", "AlreadyMember", "Cannot add a user to an organization to which they already belong.") },
        { (9, 6), new("OrganizationIdentity", "MembershipLimitReached", "Cannot add another member because the limit is already reached.") },
        { (9, 7), new("OrganizationIdentity", "InvalidMember", "Cannot add organization as an organization's member.") },
        { (9, 8), new("OrganizationIdentity", "NotMember", "Member not exits.") },
        { (9, 9), new("OrganizationIdentity", "AlreadyOnboarded", "Account has already been onboarded.") },
        { (10, 0), new("FungibleAssets", "NoneValue", "Error names should be descriptive.") },
        { (10, 1), new("FungibleAssets", "StorageOverflow", "Errors should have helpful documentation associated with them.") },
        { (10, 2), new("FungibleAssets", "InUse", "The asset ID is already taken.") },
        { (10, 3), new("FungibleAssets", "NoAvailableAssetId", "") },
        { (10, 4), new("FungibleAssets", "NoPermission", "The signing account has no permission to do the operation.") },
        { (10, 5), new("FungibleAssets", "AssetNameTooLong", "Asset name is too long.") },
        { (10, 6), new("FungibleAssets", "MaxTopUppedAssetsReached", "Limit of tipupped assets is reached.") },
        { (10, 7), new("FungibleAssets", "ZeroGlobalCup", "Global Cup must be above zero.") },
        { (10, 8), new("FungibleAssets", "ZeroLocalCup", "Local Cup must be above zero.") },
        { (10, 9), new("FungibleAssets", "ZeroTopUpped", "Top upped speed must be above zero.") },
        { (10, 10), new("FungibleAssets", "TopUppedWithNoCup", "Top upped speed can't be set without a local cup.") },
        { (10, 11), new("FungibleAssets", "NoAccount", "The account to alter does not exist.") },
        { (11, 0), new("NonFungibleAssets", "NoneValue", "Error names should be descriptive.") },
        { (11, 1), new("NonFungibleAssets", "StorageOverflow", "Errors should have helpful documentation associated with them.") },
        { (11, 2), new("NonFungibleAssets", "NoAvailableAssetId", "") },
        { (11, 3), new("NonFungibleAssets", "NoAvailableClassId", "") },
        { (11, 4), new("NonFungibleAssets", "ClassNameTooLong", "Class name is too long.") },
        { (11, 5), new("NonFungibleAssets", "NoPermission", "The signing account has no permission to do the operation.") },
        { (11, 6), new("NonFungibleAssets", "UnknownClass", "The given class Id is unknown.") },
        { (11, 7), new("NonFungibleAssets", "UnknownAsset", "The given asset Id is unknown.") },
        { (11, 8), new("NonFungibleAssets", "WrongBettor", "The bettor characteristic is wrong.") },
        { (11, 9), new("NonFungibleAssets", "WrongPurchased", "The purchased characteristic is wrong.") },
        { (11, 10), new("NonFungibleAssets", "AttributeConversionError", "Attribute value not supported") },
        { (11, 11), new("NonFungibleAssets", "NumberAttributeValueExceedsMaximum", "Attribute numeric value exceeds maximum value") },
        { (11, 12), new("NonFungibleAssets", "StringAttributeLengthLimitExceeded", "String attribute length limit exceeded") },
        { (11, 13), new("NonFungibleAssets", "AttributeAlreadyExists", "An attribute with the specified name already exists") },
        { (11, 14), new("NonFungibleAssets", "WrongParameter", "General error if any parameter is invalid") },
        { (11, 15), new("NonFungibleAssets", "UnsupportedCharacteristic", "This characteristic is not supported by this asset") },
        { (11, 16), new("NonFungibleAssets", "WrongCharacteristic", "Characteristic is invalid") },
        { (11, 17), new("NonFungibleAssets", "Locked", "The asset instance is locked") },
        { (11, 18), new("NonFungibleAssets", "CommonError", "The common error") },
        { (12, 0), new("Mechanics", "MechanicsNotAvailable", "Mechanics are not available for this asset or this origin") },
        { (12, 1), new("Mechanics", "Internal", "Internal error") },
        { (12, 2), new("Mechanics", "AssetsExceedsAllowable", "The number of assets exceeds the allowable") },
        { (12, 3), new("Mechanics", "IncompatibleAsset", "Asset is incompatible with mechanic") },
        { (12, 4), new("Mechanics", "IncompatibleData", "Given data is incompatible with mechanic") },
        { (12, 5), new("Mechanics", "NoPermission", "The signing account has no permission to do the operation.") },
    };
    public static DecodedModuleError FindMetaError(byte module, byte error)
    {
        if (errors.TryGetValue((module, error), out var value))
        {
            return value;
        }
        throw new Exception($"FindMetaError: Unable to find Error with index [{module}, {error}]");
    }
}

public class DecodedModuleError {
    public string Module { get; }
    public string Error { get; }
    public string Description { get; }

    internal DecodedModuleError(string module, string error, string description)
    {
        Module = module;
        Error = error;
        Description = description;
    }
}
