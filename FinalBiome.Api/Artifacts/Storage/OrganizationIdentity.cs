///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.OrganizationIdentityEntries;
public class OrganizationIdentity
{
    readonly Client client;
    public OrganizationIdentity(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  Details of an organization.<br/>
    /// </summary>
    public Organizations Organizations(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new Organizations(client, accountId32);
    }

    /// <summary>
    ///  Details of an members.<br/>
    ///  ATTENTION: The store also includes organizations.<br/>
    /// </summary>
    public Members Members(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new Members(client, accountId32);
    }

    /// <summary>
    ///  Members of organizations.<br/>
    /// </summary>
    public MembersOf MembersOf(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId320)
    {
        return new MembersOf(client, accountId32, accountId320);
    }

    /// <summary>
    ///  Users of organizations.<br/>
    /// <para></para>
    ///  Stores users who has been onboarded into the game<br/>
    /// </summary>
    public UsersOf UsersOf(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId320)
    {
        return new UsersOf(client, accountId32, accountId320);
    }

    /// <summary>
    ///  Counts of members in organization.<br/>
    /// </summary>
    public MemberCount MemberCount(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32)
    {
        return new MemberCount(client, accountId32);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
