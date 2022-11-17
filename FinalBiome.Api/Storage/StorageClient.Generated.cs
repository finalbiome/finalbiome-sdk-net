using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Storage;

public partial class StorageClient
{
    Client client;

    public FungibleAssets2 FungibleAssets { get; internal set; }

    public StorageClient(Client client)
    {
        this.client = client;
        FungibleAssets = new FungibleAssets2(this.client);
    }
}

