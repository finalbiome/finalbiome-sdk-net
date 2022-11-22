﻿using System;
using System.Linq;
using System.Xml.Linq;
using Ajuna.NetApi.Model.Meta;

namespace FinalBiome.Api.Codegen
{
    public class ParsedStorage
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
        public List<string> Hashers = new List<string>();
        /// <summary>
        /// Full canonical names of types
        /// </summary>
        public List<string> InputTypes = new List<string>();
        public List<string>? Docs;

        public bool Parsed = false;
        public List<string> GeneratedCode = new List<string>();

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
        public string FileNameDir
        {
            get
            {
                return TypeGenerator.StorageNamespacePrefix.Replace(".", "/");
            }
        }
    }

    public class StorageParser
    {
        Dictionary<uint, PalletModule> modules;
        internal List<ParsedStorage> parsedStorages;
        /// <summary>
        /// Holds code of module classes.
        /// Key - the module name
        /// </summary>
        internal Dictionary<string, ParsedStorage> parsedModules = new Dictionary<string, ParsedStorage>();
        List<string> queryClassSource = new List<string>();
        TypeParser typeParser;

        public StorageParser(Dictionary<uint, PalletModule> modules, TypeParser typeParser)
        {
            this.modules = modules;
            parsedStorages = new List<ParsedStorage>();
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
                ParsedStorage ps = new ParsedStorage();
                ps.Module = module.Name;
                ps.Storage = storage.Name;
                ps.Type = storage.StorageType.ToString();
                switch (storage.StorageType)
                {
                    case Ajuna.NetApi.Model.Meta.Storage.Type.Plain:
                        ps.OutputType = typeParser.parsedTypes[storage.TypeMap.Item1].FullCanonicalName;
                        break;
                    case Ajuna.NetApi.Model.Meta.Storage.Type.Map:
                        ps.OutputType = typeParser.parsedTypes[storage.TypeMap.Item2.Value].FullCanonicalName;
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
                GenerageStorageClassConstructor(ps);
                GenerateStorageClass(ps);
            }
        }

        void GenerateStorageClass(ParsedStorage ps)
        {
            string getUniqueParamName(List<string> parameters, string newParameterName, int? suffix = null) {
                if (parameters.Contains(newParameterName + suffix))
                {
                    suffix = suffix is null ? 0 : suffix + 1;
                    return getUniqueParamName(parameters, newParameterName, suffix);
                }
                else return newParameterName + suffix;
            }

            List<string> inputParamNamesList = new List<string>();
            List<string> inputParamsList = new List<string>();
            foreach (var t in ps.InputTypes)
            {
                string paramName = t.Split(".").Last();
                paramName = Char.ToLowerInvariant(paramName[0]) + paramName.Substring(1);
                paramName = getUniqueParamName(inputParamNamesList, paramName);

                inputParamNamesList.Add(paramName);
                inputParamsList.Add($"{t} {paramName}");
            }
            string inputParams = String.Join(", ", inputParamsList);
            if (inputParams.Length > 0) inputParams += ", ";

            // stupid Compiler Error CS0542
            string methodName = (ps.Module != ps.Storage) ? ps.Storage : ps.Storage + "Get";

            List<string> file = new List<string>();

            file.Add($"namespace {ps.CanonicalName.Item1};");
            file.Add($"public partial class {ps.Module}");
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
            file.Add($"    public async Task<{ps.OutputType}?> {methodName}({inputParams}IEnumerable<byte>? hash = null)");
            file.Add($"    {{");
            file.Add($"        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();");
            foreach (var h in ps.Hashers.Zip(inputParamNamesList))
            {
                file.Add($"        storageEntryKeys.Add(new StorageMapKey({h.Second}, FinalBiome.Api.Storage.StorageHasher.{HasherConverter(h.First).ToString()}));");
            }
            file.Add($"");
            file.Add($"        StaticStorageAddress address = new StaticStorageAddress(\"{ps.Module}\", \"{ps.Storage}\", storageEntryKeys);");
            file.Add($"");
            file.Add($"        return await client.Storage.Fetch<{ps.OutputType}>(address, hash);");
            file.Add($"    }}");
            file.Add($"");
            if (ps.Docs is not null && ps.Docs.Count > 0)
            {
                file.Add($"    /// <summary>");
                file.Add($"    /// Subscribe to the changes of");
                foreach (var s in ps.Docs)
                {
                    file.Add($"    /// {s}");
                }
                file.Add($"    /// </summary>");
            }
            file.Add($"    public async IAsyncEnumerable<{ps.OutputType}?> {methodName}Subscribe({inputParams}CancellationToken? cancellationToken = null)");
            file.Add($"    {{");
            file.Add($"        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();");
            foreach (var h in ps.Hashers.Zip(inputParamNamesList))
            {
                file.Add($"        storageEntryKeys.Add(new StorageMapKey({h.Second}, FinalBiome.Api.Storage.StorageHasher.{HasherConverter(h.First).ToString()}));");
            }
            file.Add($"");
            file.Add($"        StaticStorageAddress address = new StaticStorageAddress(\"{ps.Module}\", \"{ps.Storage}\", storageEntryKeys);");
            file.Add($"");
            file.Add($"        var sub = client.Storage.SubscribeStorage<{ps.OutputType}>(address, cancellationToken);");
            file.Add($"        await foreach (var item in sub)");
            file.Add($"        {{");
            file.Add($"            yield return item;");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");
            file.Add($"");

            ps.FileSuffix = $".{ps.Storage}";
            ps.GeneratedCode = file;
            ps.Parsed = true;
        }

        void GenerageStorageClassConstructor(ParsedStorage ps)
        {
            if (parsedModules.ContainsKey(ps.Module)) return;

            ParsedStorage psm = new ParsedStorage();
            psm.Module = ps.Module;
            psm.Storage = ps.Storage;


            List<string> file = new List<string>();

            file.Add($"namespace {ps.CanonicalName.Item1};");
            file.Add($"public partial class {ps.Module}");
            file.Add($"{{");
            file.Add($"    readonly Client client;");
            file.Add($"    public {ps.Module}(Client client)");
            file.Add($"    {{");
            file.Add($"        this.client = client;");
            file.Add($"    }}");
            file.Add($"}}");
            file.Add($"");

            psm.GeneratedCode = file;
            psm.Parsed = true;

            parsedModules[psm.Module] = psm;
        }

        void GenerateStorageClientPartialClass()
        {
            List<string> file = new List<string>();

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
                string path = $"{outputDir}/{s.FileNameDir}";
                string pathFileName = $"{path}/{s.FileName}";
                Directory.CreateDirectory(path);
                Console.WriteLine($"Write file {pathFileName}");
                File.WriteAllLines(pathFileName, TypeGenerator.banner.Concat(s.GeneratedCode));
            }
            // save StorageClient class
            string pathQueryFileName = $"{outputDir}/{TypeGenerator.StorageNamespacePrefix}/StorageClient.cs";
            Console.WriteLine($"Write file {pathQueryFileName}");
            File.WriteAllLines(pathQueryFileName, TypeGenerator.banner.Concat(queryClassSource));
        }

        FinalBiome.Api.Storage.StorageHasher HasherConverter(string ajHasher)
        {
            switch (ajHasher)
            {
                case "Twox64Concat":
                    return FinalBiome.Api.Storage.StorageHasher.Twox64Concat;
                case "Twox128":
                    return FinalBiome.Api.Storage.StorageHasher.Twox128;
                case "Twox256":
                    return FinalBiome.Api.Storage.StorageHasher.Twox256;
                case "BlakeTwo128":
                    return FinalBiome.Api.Storage.StorageHasher.Blake2_128;
                case "BlakeTwo128Concat":
                    return FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat;
                case "BlakeTwo256":
                    return FinalBiome.Api.Storage.StorageHasher.Blake2_256;
                case "Identity":
                    return FinalBiome.Api.Storage.StorageHasher.Identity;

                default:
                    throw new Exception($"Hasher {ajHasher} is not impemented");
            }
        }
    }
}

