
namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// Base class for all FinalBiome Jimmy exceptions.
/// </summary>
public class JimmyException : Exception
{
    public JimmyException(string message, JimmyErrorReason reason)
        : base(message)
    {
        this.Reason = reason;
    }

    public JimmyException(string message, Exception innerException, JimmyErrorReason reason)
        : base(message, innerException)
    {
        this.Reason = reason;
    }

    public JimmyException(Exception innerException, JimmyErrorReason reason)
        : this($"FinalBiome Jimmy exception occured: {reason}", innerException, reason)
    {
    }

    /// <summary>
    /// Indicates why a login failed. If not resolved, defaults to <see cref="JimmyErrorReason.Unknown"/>.
    /// </summary>
    public JimmyErrorReason Reason
    {
        get;
    }
}

/// <summary>
/// Exception thrown during invocation of an HTTP request.
/// </summary>
public class JimmyHttpException : JimmyException
{
    public JimmyHttpException(Exception innerException, string requestUrl, string requestData, string responseData, JimmyErrorReason reason = JimmyErrorReason.Unknown)
        : base(GenerateExceptionMessage(requestUrl, requestData, responseData, reason), innerException, reason)
    {
        this.RequestUrl = requestUrl;
        this.RequestData = requestData;
        this.ResponseData = responseData;
    }

    /// <summary>
    /// Json data passed to the authentication service.
    /// </summary>
    public string RequestData
    {
        get;
    }

    /// <summary>
    /// Url for which the request failed.
    /// </summary>
    public string RequestUrl
    {
        get;
    }

    /// <summary>
    /// Response from the authentication service.
    /// </summary>
    public string ResponseData
    {
        get;
    }

    private static string GenerateExceptionMessage(string requestUrl, string requestData, string responseData, JimmyErrorReason errorReason)
    {
        return $"Exception occured during Firebase Http request.\nUrl: {requestUrl}\nRequest Data: {requestData}\nResponse: {responseData}\nReason: {errorReason}";
    }
}
