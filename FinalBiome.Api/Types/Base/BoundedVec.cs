using System;
namespace FinalBiome.Api.Types
{
    public class BoundedVec<T> : Vec<T> where T : Codec, new()
    {
        public override string TypeName() => $"BoundedVec<{new T().TypeName()}, u32>";
    }
}

