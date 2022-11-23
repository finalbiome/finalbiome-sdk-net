using System;
namespace FinalBiome.Api.Utils
{
    public class HexUtils
    {
        public static byte[] HexToBytes(string hexString, bool evenCheck = true)
        {
            if (hexString.Equals("0x0")) return new byte[] { 0x00 };

            if (evenCheck && hexString.Length % 2 == 1)
                throw new Exception("The string must contain an even number of digits");

            if (hexString.StartsWith("0x")) hexString = hexString[2..];

            if (!evenCheck && hexString.Length % 2 != 0) hexString = hexString.PadLeft(hexString.Length + 1, '0');

            var arr = new byte[hexString.Length >> 1];

            for (var i = 0; i < hexString.Length >> 1; ++i)
                arr[i] = (byte)((GetHexVal(hexString[i << 1]) << 4) + GetHexVal(hexString[(i << 1) + 1]));

            return arr;
        }

        public static int GetHexVal(char hexChar)
        {
            int val = hexChar;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : val < 97 ? 55 : 87);
        }

        public enum HexStringFormat
        {
            Pure,
            Dash,
            Prefixed
        }

        public static string Bytes2HexString(byte[] bytes, HexStringFormat format = HexStringFormat.Prefixed)
        {
            return format switch
            {
                HexStringFormat.Pure => Convert.ToHexString(bytes),
                HexStringFormat.Dash => BitConverter.ToString(bytes),
                HexStringFormat.Prefixed => $"0x{Convert.ToHexString(bytes)}",
                _ => throw new Exception($"Unimplemented hex string format '{format}'"),
            };
        }
    }
}

