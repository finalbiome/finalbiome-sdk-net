using System;
using System.Net;
using FinalBiome.Api.Types;

namespace FinalBiome.Api.Storage
{
    /// <summary>
    /// This represents a sorage entry at a given address.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class StorageEntry<TResult> where TResult : Codec, new()
    {
        readonly Client client;
        protected readonly string palletName;
        protected readonly string entryName;
        /// <summary>
        /// This represents a statically generated storage lookup address.
        /// </summary>
        public StaticStorageAddress Address { get; protected set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StorageEntry(Client client, string palletName, string entryName)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.client = client;
            this.palletName = palletName;
            this.entryName = entryName;
        }

        /// <summary>
        /// Fetch a decoded value from storage at a given address and optional block hash.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public async Task<TResult?> Fetch(IEnumerable<byte>? hash = null)
        {
            return await client.Storage.Fetch<TResult>(Address, hash);
        }
        /// <summary>
        /// Subscribe to the changes at a given addres.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<TResult?> Subscribe(CancellationToken? cancellationToken = null)
        {
            try
            {
                var sub = client.Storage.SubscribeStorage<TResult>(Address, cancellationToken);
                await foreach (var item in sub)
                {
                    yield return item;
                }
            }
            finally {}
        }
    }
}

