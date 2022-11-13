using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FinalBiome.Api.Utils
{
    public class ArrayUtils
    {
        public static byte[] SizePrefixedByteArray(byte[] list)
        {
            var result = new List<byte>();
            result.AddRange(CompactNum.CompactTo(list.Length));
            result.AddRange(list);
            return result.ToArray();
        }
    }
}

