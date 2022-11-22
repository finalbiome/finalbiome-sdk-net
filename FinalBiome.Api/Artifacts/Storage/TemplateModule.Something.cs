///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.TemplateModuleEntries;
public class Something : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    public Something(Client client) :
        base(client, "TemplateModule", "Something")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

