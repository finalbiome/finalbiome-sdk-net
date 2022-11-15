using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc;

/// <summary>
/// Runtime version.
/// 
/// Implementation of this rpc response <see cref="https://github.com/w3f/PSPs/blob/master/PSPs/drafts/psp-6.md#11110-state_getruntimeversion"/>
/// </summary>
/// 
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class RuntimeVersion
{
    /// <summary>
    /// Version of the runtime specification. A full-node will not attempt to use its native
    /// runtime in substitute for the on-chain Wasm runtime unless all of `spec_name`,
    /// `spec_version` and `authoring_version` are the same between Wasm and native.
    /// </summary>
    public uint SpecVersion { get; set; }

    /// <summary>
    /// All existing dispatches are fully compatible when this number doesn't change. If this
    /// number changes, then `spec_version` must change, also.
    ///
    /// This number must change when an existing dispatchable (module ID, dispatch ID) is changed,
    /// either through an alteration in its user-level semantics, a parameter
    /// added/removed/changed, a dispatchable being removed, a module being removed, or a
    /// dispatchable/module changing its index.
    ///
    /// It need *not* change when a new module is added or when a dispatchable is added.
    /// </summary>
    public uint TransactionVersion { get; set; }

    /// <summary>
    /// Name of the runtime.
    /// </summary>
    public string SpecName { get; set; }
    /// <summary>
    /// Name of the implementation of the specification.
    /// </summary>
    public string ImplName { get; set; }
    /// <summary>
    /// Version of the authorship interface.
    /// </summary>
    public uint AuthoringVersion { get; set; }
    /// <summary>
    /// Version of the implementation of the specification.
    /// </summary>
    public uint ImplVersion { get; set; }

    /// <summary>
    /// List of supported API features along with their version.<br/>
    /// (OPTIONAL)
    /// <code lang="json">
    ///     [
    ///         HEX,  // The feature name
    ///         uint // Version of the feature
    ///     ]
    /// </code>
    /// </summary>
    public object[][] Apis { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

