using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Tx;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

/// <summary>
/// This represents an extrinsic that has been signed and is ready to submit.
/// </summary>
public class SubmittableExtrinsic
{
    Client client;
    List<byte> encoded;

    SubmittableExtrinsic(Client client, List<byte> txBytes)
    {
        this.client = client;
        this.encoded = txBytes;
    }

    /// <summary>
    /// Create a [`SubmittableExtrinsic`] from some already-signed and prepared
    /// extrinsic bytes, and some client (anything implementing [`OfflineClientT`]
    /// or [`OnlineClientT`]).
    ///
    /// Prefer to use [`TxClient`] to create and sign extrinsics. This is simply
    /// exposed in case you want to skip this process and submit something you've
    /// already created.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="txBytes"></param>
    /// <returns></returns>
    public static SubmittableExtrinsic FromBytes(Client client, List<byte> txBytes)
    {
        return new SubmittableExtrinsic(client, txBytes);
    }

    /// <summary>
    /// Returns the SCALE encoded extrinsic bytes.
    /// </summary>
    /// <returns></returns>
    public List<byte> Encoded()
    {
        return this.encoded;
    }

    /// <summary>
    /// Consumes [`SubmittableExtrinsic`] and returns the SCALE encoded
    /// extrinsic bytes.
    /// </summary>
    /// <returns></returns>
    public List<byte> IntoEncoded()
    {
        return this.encoded;
    }

    /// Submits the extrinsic to the chain.
    ///
    /// Returns a [`TxProgress`], which can be used to track the status of the transaction
    /// and obtain details about it, once it has made it into a block.
    public async Task<TxProgress> SubmitAndWatch()
    {
        // Get a hash of the extrinsic (we'll need this later).
        var extHash = Hasher.BlakeTwo128(encoded.ToArray());
        // Submit and watch for transaction progress.
        var sub = await client.Rpc.WatchExtrinsic(encoded);

        return new TxProgress(sub, client, extHash);
    }

    /// <summary>
    /// Submits the extrinsic to the chain for block inclusion.
    ///
    /// Returns `Ok` with the extrinsic hash if it is valid extrinsic.
    ///
    /// # Note
    ///
    /// Success does not mean the extrinsic has been included in the block, just that it is valid
    /// and has been included in the transaction pool.
    /// </summary>
    /// <returns></returns>
    public async Task<Hash> Submit()
    {
        return await client.Rpc.SubmitExtrinsic(encoded);
    }

    public async Task<FinalBiome.Api.Rpc.Types.ApplyExtrinsicResult> DryRun(Hash at)
    {
        return await client.Rpc.DryRun(Encoded(), at);
    }
}

