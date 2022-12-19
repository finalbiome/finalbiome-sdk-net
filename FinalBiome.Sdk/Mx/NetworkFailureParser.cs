
namespace FinalBiome.Sdk;

/// <summary>
/// Parser of network response errors into <see cref="NetworkErrorReason"/> enum.
/// </summary>
internal static class NetworkFailureParser
{
    /// <summary>
    /// Parser of network response errors into <see cref="NetworkErrorReason"/> enum.
    /// </summary>
    public static NetworkErrorReason GetFailureReason(StreamJsonRpc.RemoteInvocationException error)
    {
        if (error.ErrorData is null) throw error;
        var response = (string?)(Newtonsoft.Json.Linq.JToken)error.ErrorData;
        return response switch
        {
            "Transaction is outdated" => NetworkErrorReason.TransactionIsOutdated,
            "Inability to pay some fees (e.g. account balance too low)" => NetworkErrorReason.AccountBalanceTooLow,
            _ => throw error,
        };
    }
    /// <summary>
    /// Try to wrap convert JsonRpc exception to NetworkException with readable message
    /// </summary>
    /// <param name="error"></param>
    public static NetworkException WrapError(StreamJsonRpc.RemoteInvocationException error)
    {
        if (error.ErrorData is null) throw error;
        var response = (string?)(Newtonsoft.Json.Linq.JToken)error.ErrorData;
        return new NetworkException(response, error);
    }
}
