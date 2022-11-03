using System;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;

namespace Ajuna.NetApi.Model.Types.Base
{
    public class BoundedVec<T, S> : BaseVec<T> where T : IType, new()
    {
        public override string TypeName() => $"BoundedVec<{new T().TypeName()}, u32>";

    }
}

