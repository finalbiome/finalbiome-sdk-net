
using FinalBiome.Api.Blocks;
using FinalBiome.Api.Tx;
using FinalBiome.Sdk;

internal class MxSubmitter
{
    readonly Client client;
    private ulong? nextAccountNonce;

    public MxSubmitter(Client client)
    {
        this.client = client;
    }

    public async Task<ulong> GetAccountNonce() {
        // If null, get actual next nonce from the network
        nextAccountNonce ??= await client.api.Rpc.SystemAccountNextIndex(client.Auth.UserAddress).ConfigureAwait(false);
        return (ulong)nextAccountNonce;
    }

    /// <summary>
    /// Returns next account nonce from cashe or the network and increment it
    /// </summary>
    /// <returns></returns>
    private async Task<ulong> GetNextAccountNonce()
    {
        ulong current = await GetAccountNonce();
        nextAccountNonce++;
        return current;
    }

    /// <summary>
    /// Reset local copy of nonce value for explicitly requesting it from the network next time
    /// </summary>
    internal void Reset()
    {
        nextAccountNonce = null;
    }

    /// <summary>
    /// Submit transaction with respect to nonce and return success events.
    /// If nonce was wrong, nonce updates from the network and this call repeats.
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="retries"></param>
    /// <returns></returns>
    internal async Task<ExtrinsicEvents> Submit(TxPayload payload, uint retries = 1)
    {
        try
        {
            return await SubmitTx(payload);
        }
        catch (StreamJsonRpc.RemoteInvocationException e)
        {
            var failureReason = NetworkFailureParser.GetFailureReason(e);
            switch (failureReason)
            {
                case NetworkErrorReason.TransactionIsOutdated:
                    {
                        // suppose this happens if the local account's nonce is stale
                        // refresh nonce from the network and repeat request 
                        if (retries > 2) throw NetworkFailureParser.WrapError(e); // prevent infinite loop
                        Reset();
                        retries++;
                        return await Submit(payload, retries);
                    }
                default:
                    throw NetworkFailureParser.WrapError(e);
            }
        }
    }

    /// <summary>
    /// Submit Tx with respect to current account nonce
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<ExtrinsicEvents> SubmitTx(TxPayload payload)
    {
        BaseExtrinsicParamsBuilder<PlainTip> otherParams = BaseExtrinsicParamsBuilder<PlainTip>.Default();
        var accountNonce = await GetNextAccountNonce().ConfigureAwait(false);
        var subExt = client.api.Tx.CreateSignedWithNonce(payload, client.Auth.Signer, accountNonce, otherParams);
        var txProgress = await subExt.SubmitAndWatch().ConfigureAwait(false);
        var txInBlock = await txProgress.WaitForInBlock().ConfigureAwait(false);
        // the next WaitForSuccess method can throw an ExtrinsicFailedException
        // TODO: wrap into more convenient MechanicFailedException
        ExtrinsicEvents? events = await txInBlock.WaitForSuccess().ConfigureAwait(false);
        return events;
    }
}
