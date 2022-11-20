using System;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ConsoleApi.Examples;

public static class AccountKeyring
{
    public static Account Ferdie()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842"));
    }
}

public static class StringifyExtension
{
    /// <summary>
    /// Serialize Codec value to readable format.
    /// </summary>
    /// <param name="that"></param>
    /// <param name="formatting"></param>
    /// <returns></returns>
    public static string ToHuman(this Codec that, Formatting formatting = Formatting.Indented)
    {
        if (that is null) return "null";
        var sOpt = new JsonSerializerSettings
        {
            //NullValueHandling = NullValueHandling.Ignore,
            Converters = {
                    new ApiTypesJsonConverter(),
                new StringEnumConverter(),
                }
        };

        return JsonConvert.SerializeObject(that, formatting, sOpt);
    }
}