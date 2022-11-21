using System;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ConsoleApi.Examples;

/// <summary>
/// <example>
/// How to create new dev accounts
/// <code>subkey inspect //Ferdie</code>
/// </example>
/// </summary>
public static class AccountKeyring
{
    public static Account Ferdie()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0x42438b7883391c05512a938e36c2df0131e088b3756d6aa7a755fbff19d2f842"));
    }
    public static Account Alice()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"));
    }
    public static Account Bob()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"));
    }
    public static Account Charlie()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0xbc1ede780f784bb6991a585e4f6e61522c14e1cae6ad0895fb57b9a205a8f938"));
    }
    public static Account Dave()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0x868020ae0687dda7d57565093a69090211449845a7e11453612800b663307246"));
    }
    public static Account Eve()
    {
        return Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                                HexUtils.HexToBytes("0x786ad0e2df456fe43dd1f91ebca22e235bc162e0bb8d53c633e8c85b2af68b7a"));
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
