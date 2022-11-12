using System;
namespace FinalBiome.Api.Types
{
    public class WeakBoundedVec<T> : Vec<T> where T : Codec, new()
    {
        public override string TypeName() => $"WeakBoundedVec<{new T().TypeName()}, u32>";
    }
}

