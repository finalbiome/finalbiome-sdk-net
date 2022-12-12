using System.Collections;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
using StorageKey = Vec<U8>;
using StorageData = Vec<U8>;

/// <summary>
/// Storage change set
/// </summary>
public class StorageChangeSet
{
    /// <summary>
    /// Block hash
    /// </summary>
    public Hash Block { get; set; }

    /// <summary>
    /// A list of changes
    /// </summary>
    public List<StorageChange> Changes { get; internal set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public StorageChangeSet()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Changes = new List<StorageChange>();
    }

    public void AddStorageChange(StorageChange storageChange)
    {
        Changes.Add(storageChange);
    }
}

public class StorageChange
{
    /// <summary>
    /// The storage key
    /// </summary>
    public List<byte> StorageKey { get; internal set; }
    /// <summary>
    /// The new storage value
    /// </summary>
    public string? StorageValue { get; internal set; }

    public StorageChange(List<byte> storageKey, string? storageValue)
    {
        StorageKey = storageKey;
        StorageValue = storageValue;
    }
}

