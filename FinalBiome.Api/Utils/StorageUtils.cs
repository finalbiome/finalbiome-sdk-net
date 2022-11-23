using System;
using System.Linq;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Extensions;

namespace FinalBiome.Api.Utils
{
    public class StorageUtils
    {
        public StorageUtils()
        {
        }

        /// <summary>
        /// Outputs a vector containing the bytes written by [`WriteStorageAddressRootBytes`]
        /// </summary>
        /// <param name="staticStorageAddress"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static List<byte> StorageAddressRootBytes(StorageAddress addr)
        {
            List<byte> bytes = new();
            WriteStorageAddressRootBytes(addr, ref bytes);
            return bytes;
        }

        /// <summary>
        /// Return the root of a given [`StorageAddress`]: hash the pallet name and entry name
        /// </summary>
        /// <param name="staticStorageAddress"></param>
        /// <returns></returns>
        internal static void WriteStorageAddressRootBytes(StorageAddress addr, ref List<byte> bytes)
        {
            bytes.AddRange(Hasher.Twox128(addr.PalletName.AsBytes()));
            bytes.AddRange(Hasher.Twox128(addr.EntryName.AsBytes()));
        }

        /// <summary>
        /// Outputs the [`StorageAddressRootBytes`] as well as any additional bytes that represent
        /// a lookup in a storage map at that location.
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        internal static List<byte> StorageAddressBytes(StorageAddress addr)
        {
            List<byte> bytes = new List<byte>();
            WriteStorageAddressRootBytes(addr, ref bytes);
            addr.AppendEntryBytes(ref bytes);
            return bytes;
        }
    }
}

