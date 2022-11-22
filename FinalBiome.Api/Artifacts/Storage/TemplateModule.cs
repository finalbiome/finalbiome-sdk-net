///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.TemplateModuleEntries;
public class TemplateModule
{
    readonly Client client;
    public TemplateModule(Client client)
    {
        this.client = client;
    }
    public Something Something()
    {
        return new Something(client);
    }

}

