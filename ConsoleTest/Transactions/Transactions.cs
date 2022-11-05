///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Sdk.Transactions
{
    public class Transactions
    {
        readonly Client _client;

        public System System;
        public Timestamp Timestamp;
        public Grandpa Grandpa;
        public Balances Balances;
        public Sudo Sudo;
        public TemplateModule TemplateModule;
        public OrganizationIdentity OrganizationIdentity;
        public FungibleAssets FungibleAssets;
        public NonFungibleAssets NonFungibleAssets;
        public Mechanics Mechanics;

        public Transactions(Client client)
        {
            _client = client;
            System = new System(this._client);
            Timestamp = new Timestamp(this._client);
            Grandpa = new Grandpa(this._client);
            Balances = new Balances(this._client);
            Sudo = new Sudo(this._client);
            TemplateModule = new TemplateModule(this._client);
            OrganizationIdentity = new OrganizationIdentity(this._client);
            FungibleAssets = new FungibleAssets(this._client);
            NonFungibleAssets = new NonFungibleAssets(this._client);
            Mechanics = new Mechanics(this._client);
        }
    }
}
