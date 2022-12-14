
using Newtonsoft.Json;

namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// Parser of HTTP response errors into <see cref="JimmyErrorReason"/> enum.
/// </summary>
internal static class JimmyFailureParser
{
    public static JimmyErrorReason GetFailureReason(string responseData)
    {
        if (string.IsNullOrEmpty(responseData) || responseData == "N/A")
        {
            return JimmyErrorReason.Unknown;
        }

        try
        {
            //create error data template and try to parse JSON
            var errorData = new { error = new { code = 0, message = "errorid" } };
            errorData = JsonConvert.DeserializeAnonymousType(responseData, errorData);
            //errorData is just null if different JSON was received
            switch (errorData?.error?.message)
            {
                case "Device Id not found in request":
                    return JimmyErrorReason.DeviceIdNotFound;
                case "Account has been transferred":
                    return JimmyErrorReason.AccountTransferred;
                case "Already created":
                    return JimmyErrorReason.AlreadyCreated;
                case "Unauthorized":
                    return JimmyErrorReason.Unauthorized;
                case "Not found":
                    return JimmyErrorReason.NotFound;
                case "Request error":
                    return JimmyErrorReason.RequestError;
                case "Already migrated":
                    return JimmyErrorReason.AlreadyMigrated;
            }
        }
        catch (JsonReaderException)
        {
            //the response wasn't JSON - no data to be parsed
        }
        return JimmyErrorReason.Unknown;
    }
}
