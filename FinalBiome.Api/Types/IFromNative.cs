using System;
namespace FinalBiome.Api.Types
{
    public interface IFromNative<T, V>
    {
        static abstract T From(V value);
    }
}

