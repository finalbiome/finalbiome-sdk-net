
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FinalBiome.Sdk.Jimmy;

public class DeviceIdRequest
{
    public string? DeviceId { get; set; }
}

public class PhraseResponse
{
#pragma warning disable CS8618
    public string Phrase { get; set; }
    public string Seed { get; set; }
#pragma warning restore CS8618
}

/// <summary>
/// Base class for issuing http requests against Jimmy <see cref="Endpoints"/>.
/// </summary>
/// <typeparam name="TRequest">Specifies the type of request payload</typeparam>
/// <typeparam name="TResponse">Specifies the type of response payload</typeparam>
public abstract class JimmyRequestBase<TRequest, TResponse>
{
    readonly HttpClient HttpClient = new();
    readonly JsonSerializerSettings JsonSettings;

    protected JimmyRequestBase()
    {
        this.HttpClient = new();
        this.JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
        this.JsonSettings.Converters.Add(new StringEnumConverter {
            NamingStrategy = new CamelCaseNamingStrategy()
            });
    }

    protected abstract string UrlFormat { get; }
    protected virtual HttpMethod Method => HttpMethod.Get;
    protected virtual JsonSerializerSettings? JsonSettingsOverride => null;

    public virtual async Task<TResponse> ExecuteAsync(TRequest request, string? token, string? deviceId = null)
        {
            var responseData = string.Empty;
            var requestData = request != null ? JsonConvert.SerializeObject(request, this.JsonSettingsOverride ?? this.JsonSettings) : "";
            var url = this.GetFormattedUrl(deviceId);

            try
            {
                var content = request != null ? new StringContent(requestData, Encoding.UTF8, "application/json") : null;
                var message = new HttpRequestMessage(this.Method, url)
                {
                    Content = content
                };
                if (token is not null)
                {
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                var httpResponse = await this.HttpClient.SendAsync(message).ConfigureAwait(false);
                responseData = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                
                var response = JsonConvert.DeserializeObject<TResponse>(responseData, this.JsonSettingsOverride ?? this.JsonSettings);

                httpResponse.EnsureSuccessStatusCode();

                return response!;
            }
            catch (Exception e)
            {
                var errorReason = JimmyFailureParser.GetFailureReason(responseData);
                throw new JimmyHttpException(e, url, requestData, responseData, errorReason);
            }
        }

        private string GetFormattedUrl(string? deviceId)
        {
            return deviceId is null ? this.UrlFormat : string.Format(this.UrlFormat, deviceId);
        }
}
