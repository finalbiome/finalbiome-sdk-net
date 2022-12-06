///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Storage;
using FinalBiome.Api.Storage.MechanicsEntries;
public class Mechanics
{
    readonly Client client;
    public Mechanics(Client client)
    {
        this.client = client;
    }
    /// <summary>
    ///  Store of the Mechanics.<br/>
    /// </summary>
    public MechanicsGet MechanicsGet(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.Primitive.U32 u32)
    {
        return new MechanicsGet(client, accountId32, u32);
    }

    /// <summary>
    ///  Schedule when mechanics time out<br/>
    /// </summary>
    public Timeouts Timeouts(FinalBiome.Api.Types.Primitive.U32 u32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.Primitive.U32 u320)
    {
        return new Timeouts(client, u32, accountId32, u320);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
