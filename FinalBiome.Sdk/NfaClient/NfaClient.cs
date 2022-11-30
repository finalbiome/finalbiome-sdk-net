using System.Collections.Concurrent;

namespace FinalBiome.Sdk;

using StorageKey = List<byte>;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using NfaAssetDetails = Api.Types.PalletSupport.TypesNfa.AssetDetails;
using NfaClassDetails = Api.Types.PalletSupport.TypesNfa.ClassDetails;
/// <summary>
/// Client for access to fungible assets on network for the given game.<br/>
/// This client contains all information about Nfa - classes, instances and their attributes.<br/>
/// If the status of any Nfa is changed, this client will update information about it and trigger the appropriate events.
/// </summary>
/// 
/// For performance reasons, the clietn doesn't hold information about all existing in the game assets.
/// It fetches information only about NFAs which holds by user.
/// When any changes with assets are happends, NfaClient notified about it.<br/>
/// After client initialization, it fetches all nfa id, owned by games, all asset ids, owned by user and
/// starts listening the network events about any changes with nfa assets
/// (note: someday we will need to refactor this via custom rpc subscription).
/// 
/// The gameplay includes not only the creation and deletion of assets, but also the manipulation 
/// of their attributes.
/// And these manipulations will eventually be the most frequent operation on the network.
/// Therefore, we need to keep subscriptions to change each attribute of each asset we own.
/// (note: will need to re-engineer this with my own rpc subscription someday).
public class NfaClient : IDisposable
{
    readonly Client client;

    /// <summary>
    /// Cancellation token for all subscriber tasks
    /// </summary>
    /// <returns></returns>
    readonly CancellationTokenSource subscriberCancellationTokenSource = new();


    /// <summary>
    /// Tasks which listen a subscription on FA changes and updates asset states.
    /// </summary>
    readonly ConcurrentBag<Task> subscriberTasks = new();
    /// <summary>
    /// Collection of storage keys what we have subscriptions to.
    /// </summary>
    /// <returns></returns>
    readonly ConcurrentBag<StorageKey> subsriptionStarageKeys = new();

    /// <summary>
    /// Collection of all users owned Nfa assets and details about them.<br/>
    /// Value is null if data wasn't fetched from the network.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId)>"></param>
    /// <returns></returns>
    readonly ConcurrentDictionary<(NfaClassId classId, NfaInstanceId instanceId), NfaAssetDetails?> nfaAssets = new();
    /// <summary>
    /// Collection of classes of all users owned Nfa assets and details about them.<br/>
    /// Value is null if data wasn't fetched from the network.
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    readonly ConcurrentDictionary<NfaClassId, NfaClassDetails?> nfaClasses = new();
    public NfaClient(Client client)
    {
        this.client = client;
    }

    public static async Task<NfaClient> Create(Client client)
    {
        NfaClient nfaClient = new(client);

        return await Task.FromResult(nfaClient);
    }

    public void Dispose()
    {
        //
        GC.SuppressFinalize(this);
    }


    /// <summary>
    /// Fetch from the network all existing NFA Ids for the given game and store them in the nfaClasses.
    /// </summary>
    /// <returns></returns>
    async Task FetchAllExistingNfaClassIds()
    {
        
    }
}
