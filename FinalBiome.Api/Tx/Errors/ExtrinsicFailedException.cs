using System;
using FinalBiome.Api.Extensions;

namespace FinalBiome.Api.Tx.Errors;

using DispatchError = FinalBiome.Api.Types.SpRuntime.DispatchError;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

/// <summary>
/// Extrinsic failed with some error
/// </summary>
public class ExtrinsicFailedException : Exception
{
    public DispatchError DispatchError { get; internal set; }
    public Hash ExtHash { get; internal set; }

    public ExtrinsicFailedException(Hash extHash, DispatchError dispatchError) : base(MessageFactory(extHash, dispatchError))
    {
        this.DispatchError = dispatchError;
        this.ExtHash = extHash;
    }

    static string MessageFactory(Hash extHash, DispatchError dispatchError)
    {
        string errorDesc = "";
        switch (dispatchError.Value)
        {
            case Types.SpRuntime.InnerDispatchError.Module:
                {
                    var err = (FinalBiome.Api.Types.SpRuntime.ModuleError)dispatchError.Value2;
                    errorDesc = $"Index: {err.Index.Value}, Error: {err.Error.Value}";
                }
                break;
            case Types.SpRuntime.InnerDispatchError.Token:
                {
                    var err = (FinalBiome.Api.Types.SpRuntime.TokenError)dispatchError.Value2;
                    errorDesc = err.Value.ToString();
                }
                break;
            case Types.SpRuntime.InnerDispatchError.Arithmetic:
                {
                    var err = (FinalBiome.Api.Types.SpRuntime.ArithmeticError)dispatchError.Value2;
                    errorDesc = err.Value.ToString();
                }
                break;
            case Types.SpRuntime.InnerDispatchError.Transactional:
                {
                    var err = (FinalBiome.Api.Types.SpRuntime.TransactionalError)dispatchError.Value2;
                    errorDesc = err.Value.ToString();
                }
                break;
            default:
                errorDesc = dispatchError.Value.ToString();
                break;
        }
        return $"Extrinsic {extHash.ToHex()} failed: " +
               $"{errorDesc}";
    }
}

