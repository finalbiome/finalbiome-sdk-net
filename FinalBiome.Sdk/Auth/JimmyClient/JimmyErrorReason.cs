
namespace FinalBiome.Sdk.Jimmy;

public enum JimmyErrorReason
{
    /// <summary>
    /// Device Id not found in the request.
    /// </summary>
    DeviceIdNotFound,
    /// <summary>
    /// Account has been transferred.
    /// </summary>
    AccountTransferred,
    /// <summary>
    /// Account already created.
    /// </summary>
    AlreadyCreated,
    /// <summary>
    /// Not Found.
    /// </summary>
    NotFound,
    /// <summary>
    /// Account already migrated.
    /// </summary>
    AlreadyMigrated,
    /// <summary>
    /// Unknown reason of error.
    /// </summary>
    Unknown,
    /// <summary>
    /// Unauthorized request.
    /// </summary>
    Unauthorized,
    /// <summary>
    /// Request error.
    /// </summary>
    RequestError,
}
