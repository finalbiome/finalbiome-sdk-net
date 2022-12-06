///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.GrandpaEntries;
public class SetIdSession : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  A mapping from grandpa set ID to the index of the *most recent* session for which its<br/>
    ///  members were responsible.<br/>
    /// <para></para>
    ///  TWOX-NOTE: `SetId` is not under user control.<br/>
    /// </summary>
    public SetIdSession(Client client, FinalBiome.Api.Types.Primitive.U64 u64) :
        base(client, "Grandpa", "SetIdSession")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u64, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
