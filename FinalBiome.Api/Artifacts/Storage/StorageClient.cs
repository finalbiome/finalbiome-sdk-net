///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class StorageClient
{
    readonly Client client;

    public System System { get; internal set; }
    public RandomnessCollectiveFlip RandomnessCollectiveFlip { get; internal set; }
    public Timestamp Timestamp { get; internal set; }
    public Aura Aura { get; internal set; }
    public Grandpa Grandpa { get; internal set; }
    public Balances Balances { get; internal set; }
    public TransactionPayment TransactionPayment { get; internal set; }
    public Sudo Sudo { get; internal set; }
    public TemplateModule TemplateModule { get; internal set; }
    public OrganizationIdentity OrganizationIdentity { get; internal set; }
    public FungibleAssets FungibleAssets { get; internal set; }
    public NonFungibleAssets NonFungibleAssets { get; internal set; }
    public Mechanics Mechanics { get; internal set; }

    public StorageClient(Client client)
    {
        this.client = client;
        System = new System(this.client);
        RandomnessCollectiveFlip = new RandomnessCollectiveFlip(this.client);
        Timestamp = new Timestamp(this.client);
        Aura = new Aura(this.client);
        Grandpa = new Grandpa(this.client);
        Balances = new Balances(this.client);
        TransactionPayment = new TransactionPayment(this.client);
        Sudo = new Sudo(this.client);
        TemplateModule = new TemplateModule(this.client);
        OrganizationIdentity = new OrganizationIdentity(this.client);
        FungibleAssets = new FungibleAssets(this.client);
        NonFungibleAssets = new NonFungibleAssets(this.client);
        Mechanics = new Mechanics(this.client);
    }
}

