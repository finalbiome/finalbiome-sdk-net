namespace FinalBiome.Api.Types;

public enum InnerResult : byte
{
    Ok = 0,
    Err = 1
}

public class Result<T, E> : Enum<InnerResult, T, E>
                                    where T : Codec, new()
                                    where E : Codec, new()
{
    public override string TypeName() => $"Result<{new T().TypeName}, {new E().TypeName}>";

}

