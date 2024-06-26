///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Tx
{
    public partial class TxClient
    {
        readonly Client client;

        public System System;
        public Timestamp Timestamp;
        public Grandpa Grandpa;
        public Balances Balances;
        public Sudo Sudo;
        public TemplateModule TemplateModule;
        public Users Users;
        public OrganizationIdentity OrganizationIdentity;
        public FungibleAssets FungibleAssets;
        public NonFungibleAssets NonFungibleAssets;
        public Mechanics Mechanics;

        public TxClient(Client client)
        {
            this.client = client;
            System = new System(this.client);
            Timestamp = new Timestamp(this.client);
            Grandpa = new Grandpa(this.client);
            Balances = new Balances(this.client);
            Sudo = new Sudo(this.client);
            TemplateModule = new TemplateModule(this.client);
            Users = new Users(this.client);
            OrganizationIdentity = new OrganizationIdentity(this.client);
            FungibleAssets = new FungibleAssets(this.client);
            NonFungibleAssets = new NonFungibleAssets(this.client);
            Mechanics = new Mechanics(this.client);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
