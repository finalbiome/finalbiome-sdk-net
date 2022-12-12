#pragma warning disable IDE0028
using FinalBiome.Api.Codegen.Metadata;

namespace FinalBiome.Api.Codegen;

internal class ErrorsMetaParser
{
    readonly Dictionary<uint, PalletModule> modules;
    readonly TypeParser typeParser;

    readonly List<(byte moduleIdx, byte errorIdx, string moduleName, string errorName, string desc)> errors = new();

    public ErrorsMetaParser(Dictionary<uint, PalletModule> modules, TypeParser typeParser)
    {
        this.modules = modules;
        this.typeParser = typeParser;
    }

    public void Parse()
    {
        foreach (KeyValuePair<uint, PalletModule> module in modules)
        {
            if (module.Value.Errors is null) continue;

            var moduleIdx = module.Key;
            var moduleName = module.Value.Name;

            var errTypeId = module.Value.Errors.TypeId;

            NodeTypeVariant errType = (NodeTypeVariant)typeParser.Types[errTypeId];
            if (errType.Variants is null || errType.Variants.Length == 0) continue;

            foreach (var variant in errType.Variants)
            {
                var errorIdx = variant.Index;
                var errorName = variant.Name;
                var desc = variant.Docs is null ? "" : string.Join(" ", variant.Docs);
                
                errors.Add(((byte)moduleIdx, (byte)errorIdx, moduleName, errorName, desc));
            }
        }
    }

    public List<string> GenerageErrorsMetadataClass()
    {
        List<string> file = new();
        file.Add($"namespace FinalBiome.Api.Types;");
        file.Add($"");
        file.Add($"public class ErrorsMetadata");
        file.Add($"{{");
        file.Add($"    private ErrorsMetadata() {{ }}");
        file.Add($"    private static readonly Dictionary<(byte module, byte error), DecodedModuleError> errors = new()");
        file.Add($"    {{");
        foreach ((byte moduleIdx, byte errorIdx, string moduleName, string errorName, string desc) in errors)
        {
            file.Add($"        {{ ({moduleIdx}, {errorIdx}), new(\"{moduleName}\", \"{errorName}\", \"{desc}\") }},");
        }
        file.Add($"    }};");
        file.Add($"    public static DecodedModuleError FindMetaError(byte module, byte error)");
        file.Add($"    {{");
        file.Add($"        if (errors.TryGetValue((module, error), out var value))");
        file.Add($"        {{");
        file.Add($"            return value;");
        file.Add($"        }}");
        file.Add($"        throw new Exception($\"FindMetaError: Unable to find Error with index [{{module}}, {{error}}]\");");
        file.Add($"    }}");
        file.Add($"}}");
        file.Add($"");
        file.Add($"public class DecodedModuleError {{");
        file.Add($"    public string Module {{ get; }}");
        file.Add($"    public string Error {{ get; }}");
        file.Add($"    public string Description {{ get; }}");
        file.Add($"");
        file.Add($"    internal DecodedModuleError(string module, string error, string description)");
        file.Add($"    {{");
        file.Add($"        Module = module;");
        file.Add($"        Error = error;");
        file.Add($"        Description = description;");
        file.Add($"    }}");
        file.Add($"}}");

        return file;
    }

    public void Save(string outputDir)
    {
        string pathErrorsMetadataFileName = $"{outputDir}/{TypeGenerator.TypesNamespacePrefix}/ErrorsMetadata.cs";
        Console.WriteLine($"Write file {pathErrorsMetadataFileName}");
        File.WriteAllLines(pathErrorsMetadataFileName, TypeGenerator.StringsWithBanner(GenerageErrorsMetadataClass()));
    }
}
