using System;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Model.Types.Base
{
    public class WeakBoundedVec<T> : BaseVec<T> where T : IType, new()
    {
        public override string TypeName() => $"WeakBoundedVec<{new T().TypeName()}, u32>";

    }
}
