#pragma warning disable IDE0028
#pragma warning disable IDE0042


using System;
using System.Linq;
using System.Xml.Linq;
using FinalBiome.Api.Codegen.Metadata;


namespace FinalBiome.Api.Codegen
{
    public class ParsedStorageV2
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Module;
        public string Storage;
        public string Type;
        /// <summary>
        /// Full canonical name of output type
        /// </summary>
        public string OutputType;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public List<string> Hashers = new();
        /// <summary>
        /// Full canonical names of types
        /// </summary>
        public List<string> InputTypes = new();
        public List<string>? Docs;

        public bool Parsed = false;
        public List<string> GeneratedCode = new();

        public string FileSuffix = "";

        public (string, string) CanonicalName
        {
            get { return ($"{TypeGenerator.RootNamespace}.{TypeGenerator.StorageNamespacePrefix}", Module); }
        }

        public string FullCanonicalName
        {
            get { return $"{CanonicalName.Item1}.{CanonicalName.Item2}";  }
        }

        public string FileName
        {
            get
            {
                return $"{CanonicalName.Item2}{FileSuffix}.cs";
            }
        }
        /// <summary>
        /// Filename dir generates as TypeGenerator.StorageNamespacePrefix
        /// </summary>
        public static string FileNameDir
        {
            get
            {
                return TypeGenerator.StorageNamespacePrefix.Replace(".", "/");
            }
        }
    }

    public class StorageParserV2
    {
        readonly Dictionary<uint, PalletModule> modules;
        internal List<ParsedStorageV2> parsedStorages;
        /// <summary>
        /// Holds code of module classes.
        /// Key - the module name
        /// </summary>
        internal Dictionary<string, ParsedStorageV2> parsedModules = new();
        List<string> queryClassSource = new();
        readonly TypeParser typeParser;

        public StorageParserV2(Dictionary<uint, PalletModule> modules, TypeParser typeParser)
        {
            this.modules = modules;
            parsedStorages = new List<ParsedStorageV2>();
            this.typeParser = typeParser;
        }

        public void Parse()
        {
            foreach (var module in modules)
            {
                ParseModule(module.Value);
            }
            GenerateStorageClasses();
            GenerateStorageClientPartialClass();
        }

        void ParseModule(PalletModule module)
        {
            TakeApartModules(module);
        }

        void TakeApartModules(PalletModule module)
        {
            foreach (var storage in module.Storage.Entries)
            {
                ParsedStorageV2 ps = new()
                {
                    Module = module.Name,
                    Storage = storage.Name,
                    Type = storage.StorageType.ToString()
                };
                switch (storage.StorageType)
                {
                    case FinalBiome.Api.Codegen.Metadata.Storage.Type.Plain:
                        ps.OutputType = typeParser.parsedTypes[storage.TypeMap.Item1].FullCanonicalName;
                        break;
                    case FinalBiome.Api.Codegen.Metadata.Storage.Type.Map:
                        ps.OutputType = typeParser.parsedTypes[storage.TypeMap.Item2!.Value].FullCanonicalName;
                        if (storage.TypeMap.Item2.Hashers.Length == 1)
                        {
                            ps.InputTypes = new List<string>() { typeParser.parsedTypes[storage.TypeMap.Item2.Key].FullCanonicalName };

                        } else
                        {
                            ps.InputTypes = typeParser.SplitTupleToInnerTypes(storage.TypeMap.Item2.Key);
                        }

                        foreach (var h in storage.TypeMap.Item2.Hashers)
                        {
                            ps.Hashers.Add(h.ToString());
                        }
                        break;
                    default:
                        throw new NotImplementedException("");
                }
                if (storage.Docs is not null)
                {
                    ps.Docs = new List<string>();
                    foreach (var s in storage.Docs)
                    {
                        ps.Docs.Add(Utils.CleanDocString(s));
                    }
                }

                parsedStorages.Add(ps);
            }
        }

        void GenerateStorageClasses()
        {
            foreach (var ps in parsedStorages)
            {
                GenerageModuleClass(ps);
                GenerateStorageEntry(ps);
            }
        }

        static void GenerateStorageEntry(ParsedStorageV2 ps)
        {
            static string getUniqueParamName(List<string> parameters, string newParameterName, int? suffix = null) {
                if (parameters.Contains(newParameterName + suffix))
                {
                    suffix = suffix is null ? 0 : suffix + 1;
                    return getUniqueParamName(parameters, newParameterName, suffix);
                }
                else return newParameterName + suffix;
            }

            List<string> inputParamNamesList = new();
            List<string> inputParamsList = new();
            foreach (var t in ps.InputTypes)
            {
                string paramName = t.Split(".").Last();
                paramName = System.Char.ToLowerInvariant(paramName[0]) + paramName[1..];
                paramName = getUniqueParamName(inputParamNamesList, paramName);

                inputParamNamesList.Add(paramName);
                inputParamsList.Add($"{t} {paramName}");
            }
            string inputParams = String.Join(", ", inputParamsList);
            if (inputParams.Length > 0) inputParams = ", " + inputParams;

            // stupid Compiler Error CS0542
            string className = (ps.Module != ps.Storage) ? ps.Storage : ps.Storage + "Get";

            List<string> file = new();

            file.Add($"using FinalBiome.Api.Storage;");
            file.Add($"namespace {ps.CanonicalName.Item1}.{ps.Module}Entries;");
            file.Add($"public class {className} : StorageEntry<{ps.OutputType}>");
            file.Add($"{{");
            if (ps.Docs is not null && ps.Docs.Count > 0)
            {
                file.Add($"    /// <summary>");
                foreach (var s in ps.Docs)
                {
                    file.Add($"    /// {s}");
                }
                file.Add($"    /// </summary>");
            }
            file.Add($"    public {className}(Client client{inputParams}) :");
            file.Add($"        base(client, \"{ps.Module}\", \"{ps.Storage}\")");
            file.Add($"    {{");
            file.Add($"        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();");
            foreach (var h in ps.Hashers.Zip(inputParamNamesList))
            {
                file.Add($"        storageEntryKeys.Add(new StorageMapKey({h.Second}, FinalBiome.Api.Storage.StorageHasher.{HasherConverter(h.First)}));");
            }
            file.Add($"");
            file.Add($"        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);");
            file.Add($"    }}");
            file.Add($"");
            file.Add($"}}");
            file.Add($"");

            ps.FileSuffix = $".{ps.Storage}";
            ps.GeneratedCode = file;
            ps.Parsed = true;
        }

        void GenerageModuleClass(ParsedStorageV2 ps)
        {
            if (parsedModules.ContainsKey(ps.Module)) return;

            static string getUniqueParamName(List<string> parameters, string newParameterName, int? suffix = null)
            {
                if (parameters.Contains(newParameterName + suffix))
                {
                    suffix = suffix is null ? 0 : suffix + 1;
                    return getUniqueParamName(parameters, newParameterName, suffix);
                }
                else return newParameterName + suffix;
            }

            /// all storages for given module
            List<ParsedStorageV2> storages = parsedStorages.FindAll(s => s.Module == ps.Module);

            ParsedStorageV2 psm = new()
            {
                Module = ps.Module,
                Storage = ps.Storage
            };


            List<string> file = new();

            file.Add($"namespace {ps.CanonicalName.Item1};");
            file.Add($"using {ps.CanonicalName.Item1}.{ps.Module}Entries;");
            file.Add($"public class {ps.Module}");
            file.Add($"{{");
            file.Add($"    readonly Client client;");
            file.Add($"    public {ps.Module}(Client client)");
            file.Add($"    {{");
            file.Add($"        this.client = client;");
            file.Add($"    }}");
            foreach(var storage in storages)
            {
                List<string> inputParamNamesList = new();
                List<string> inputParamsList = new();
                foreach (var t in storage.InputTypes)
                {
                    string paramName = t.Split(".").Last();
                    paramName = System.Char.ToLowerInvariant(paramName[0]) + paramName[1..];
                    paramName = getUniqueParamName(inputParamNamesList, paramName);

                    inputParamNamesList.Add(paramName);
                    inputParamsList.Add($"{t} {paramName}");
                }
                string inputParams = String.Join(", ", inputParamsList);
                string inputNames = String.Join(", ", inputParamNamesList);
                if (inputNames.Length > 0) inputNames = ", " + inputNames;
                // stupid Compiler Error CS0542
                string className = (storage.Module != storage.Storage) ? storage.Storage : storage.Storage + "Get";

                if (storage.Docs is not null && storage.Docs.Count > 0)
                {
                    file.Add($"    /// <summary>");
                    foreach (var s in storage.Docs)
                    {
                        file.Add($"    /// {s}");
                    }
                    file.Add($"    /// </summary>");
                }
                file.Add($"    public {className} {className}({inputParams})");
                file.Add($"    {{");
                file.Add($"        return new {className}(client{inputNames});");
                file.Add($"    }}");
                file.Add($"");
            }

            file.Add($"}}");
            file.Add($"");

            psm.GeneratedCode = file;
            psm.Parsed = true;

            parsedModules[psm.Module] = psm;
        }

        void GenerateStorageClientPartialClass()
        {
            List<string> file = new();

            file.Add($"namespace {TypeGenerator.RootNamespace}.{TypeGenerator.StorageNamespacePrefix};");
            file.Add($"public partial class StorageClient");
            file.Add($"{{");
            file.Add($"    readonly Client client;");
            file.Add($"");
            foreach (var m in parsedModules)
                file.Add($"    public {m.Key} {m.Key} {{ get; internal set; }}");
            file.Add($"");
            file.Add($"    public StorageClient(Client client)");
            file.Add($"    {{");
            file.Add($"        this.client = client;");
            foreach (var m in parsedModules)
                file.Add($"        {m.Key} = new {m.Key}(this.client);");
            file.Add($"    }}");
            file.Add($"}}");
            file.Add($"");

            queryClassSource = file;
        }

        public void Save(string outputDir)
        {
            foreach (var s in parsedStorages.Concat(parsedModules.Values.ToList()))
            {
                if (!s.Parsed)
                {
                    Console.WriteLine($"Type {s.Module}.{s.Storage} doesn't parsed. Skip");
                    continue;
                }
                string path = $"{outputDir}/{ParsedStorageV2.FileNameDir}";
                string pathFileName = $"{path}/{s.FileName}";
                Directory.CreateDirectory(path);
                Console.WriteLine($"Write file {pathFileName}");
                File.WriteAllLines(pathFileName, TypeGenerator.StringsWithBanner(s.GeneratedCode));
            }
            // save StorageClient class
            string pathQueryFileName = $"{outputDir}/{TypeGenerator.StorageNamespacePrefix}/StorageClient.cs";
            Console.WriteLine($"Write file {pathQueryFileName}");
            File.WriteAllLines(pathQueryFileName, TypeGenerator.StringsWithBanner(queryClassSource));
        }

        static StorageHasher HasherConverter(string ajHasher)
        {
            return ajHasher switch
            {
                "Twox64Concat" => StorageHasher.Twox64Concat,
                "Twox128" => StorageHasher.Twox128,
                "Twox256" => StorageHasher.Twox256,
                "BlakeTwo128" => StorageHasher.Blake2_128,
                "BlakeTwo128Concat" => StorageHasher.Blake2_128Concat,
                "BlakeTwo256" => StorageHasher.Blake2_256,
                "Identity" => StorageHasher.Identity,
                _ => throw new Exception($"Hasher {ajHasher} is not impemented"),
            };
        }
    }

    // from FinalBiome.Api.Storage
    public enum StorageHasher
    {
        /// <summary>
        /// 128-bit Blake2 hash.
        /// </summary>
        Blake2_128,
        /// <summary>
        /// 256-bit Blake2 hash.
        /// </summary>
        Blake2_256,
        /// <summary>
        /// Multiple 128-bit Blake2 hashes concatenated.
        /// </summary>
        Blake2_128Concat,
        /// <summary>
        /// 128-bit XX hash.
        /// </summary>
        Twox128,
        /// <summary>
        /// 256-bit XX hash.
        /// </summary>
        Twox256,
        /// <summary>
        /// Multiple 64-bit XX hashes concatenated.
        /// </summary>
        Twox64Concat,
        /// <summary>
        /// Identity hashing (no hashing).
        /// </summary>
        Identity,
    }
}

