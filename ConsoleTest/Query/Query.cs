///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Sdk.Query
{
    public class Query
    {
        readonly Client _client;

        public System System;
        public RandomnessCollectiveFlip RandomnessCollectiveFlip;
        public Timestamp Timestamp;
        public Aura Aura;
        public Grandpa Grandpa;
        public Balances Balances;
        public TransactionPayment TransactionPayment;
        public Sudo Sudo;
        public TemplateModule TemplateModule;
        public OrganizationIdentity OrganizationIdentity;
        public FungibleAssets FungibleAssets;
        public NonFungibleAssets NonFungibleAssets;
        public Mechanics Mechanics;

        public Query(Client client)
        {
            _client = client;
            System = new System(this._client);
            RandomnessCollectiveFlip = new RandomnessCollectiveFlip(this._client);
            Timestamp = new Timestamp(this._client);
            Aura = new Aura(this._client);
            Grandpa = new Grandpa(this._client);
            Balances = new Balances(this._client);
            TransactionPayment = new TransactionPayment(this._client);
            Sudo = new Sudo(this._client);
            TemplateModule = new TemplateModule(this._client);
            OrganizationIdentity = new OrganizationIdentity(this._client);
            FungibleAssets = new FungibleAssets(this._client);
            NonFungibleAssets = new NonFungibleAssets(this._client);
            Mechanics = new Mechanics(this._client);
        }
    }
}
