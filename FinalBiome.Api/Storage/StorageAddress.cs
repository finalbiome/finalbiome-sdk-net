using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Storage
{
    public interface StorageAddress
    {
        /// <summary>
        /// The name of the pallet that the entry lives under.
        /// </summary>
        string PalletName { get; }
        /// <summary>
        /// The name of the entry in a given pallet that the item is at.
        /// </summary>
        string EntryName { get; }

        /// <summary>
        /// Output the non-prefix bytes; that is, any additional bytes that need
        /// to be appended to the key to dig into maps.
        /// </summary>
        void AppendEntryBytes(ref List<byte> bytes);

        /// <summary>
        /// An optional hash which, if present, will be checked against
        /// the node metadata to confirm that the return type matches what
        /// we are expecting.
        /// </summary>
        Array<U8>? validation_hash => null;
    }

    /// <summary>
    /// This represents a statically generated storage lookup address.
    /// </summary>
    public class StaticStorageAddress : StorageAddress
    {
        string palletName;
        string entryName;
        /// <summary>
        /// How to access the specific value at that storage address.
        /// </summary>
        List<StorageMapKey> storageEntryKeys;
        /// <summary>
        /// Hash provided from static code for validation.
        /// </summary>
        List<byte>? ValidationHash;

        public StaticStorageAddress(
            string palletName,
            string entryName,
            List<StorageMapKey> storageEntryKeys
            )
        {
            this.palletName = palletName;
            this.entryName = entryName;
            this.storageEntryKeys = storageEntryKeys;
        }

        public string PalletName => palletName;

        public string EntryName => entryName;

        public void AppendEntryBytes(ref List<byte> bytes)
        {
            foreach (var entry in storageEntryKeys)
            {
                entry.ToBytes(ref bytes);
            }
        }

        /// <summary>
        /// Return bytes representing this storage entry.
        /// </summary>
        /// <returns></returns>
        public List<byte> ToBytes()
        {
            var bytes = new List<byte>();
            StorageUtils.WriteStorageAddressRootBytes(this, ref bytes);
            foreach (var entry in storageEntryKeys)
            {
                entry.ToBytes(ref bytes);
            }
            return bytes;
        }

        /// <summary>
        /// Return bytes representing the root of this storage entry (ie a hash of
        /// the pallet and entry name).
        /// </summary>
        /// <returns></returns>
        public List<byte> ToRootBytes()
        {
            return StorageUtils.StorageAddressRootBytes(this);
        }
    }
}

