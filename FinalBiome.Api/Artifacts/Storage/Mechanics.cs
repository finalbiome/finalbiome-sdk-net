///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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

