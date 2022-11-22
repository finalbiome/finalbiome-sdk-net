using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FinalBiome.Api.Codegen.Metadata
{
    public class ArrayUtils
    {
        public static byte[] SizePrefixedByteArray(IEnumerable<byte> list)
        {
            var result = new List<byte>();
            result.AddRange(CompactNum.CompactTo(list.Count()));
            result.AddRange(list);
            return result.ToArray();
        }
    }
}

