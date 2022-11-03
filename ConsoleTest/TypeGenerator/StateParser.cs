using System;
using System.Linq;
using System.Xml.Linq;
using Ajuna.NetApi.Model.Meta;

namespace FinalBiome.TypeGenerator
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

    public class StateParser
    {
        Dictionary<uint, PalletModule> modules;
        List<ParsedStorage> parsedStorages;
        /// <summary>
        /// Holds code of module classes.
        /// Key - the module name
        /// </summary>
        Dictionary<string, ParsedStorage> parsedModules = new Dictionary<string, ParsedStorage>();
        List<string> queryClassSource;
        TypeParser typeParser;

        public StateParser(Dictionary<uint, PalletModule> modules, TypeParser typeParser)
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
            GenerateStateClasses();
            GenerateQueryClass();
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
                // stupid Compiler Error CS0542
                if (storage.Name == module.Name) ps.Storage = storage.Name + "Get";
                else ps.Storage = storage.Name;
                ps.Type = storage.StorageType.ToString();
                switch (storage.StorageType)
                {
                    case Storage.Type.Plain:
                        ps.OutputType = typeParser.parsedTypes[storage.TypeMap.Item1].FullCanonicalName;
                        break;
                    case Storage.Type.Map:
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
                        ps.Docs.Add(TypeGenerator.rCleanDocs.Replace(s, " "));
                    }
                }

                parsedStorages.Add(ps);
            }
        }

        void GenerateStateClasses()
        {
            foreach (var ps in parsedStorages)
            {
                GenerageStateClassConstructor(ps);
                GenerateStateClass(ps);
            }
        }

        void GenerateStateClass(ParsedStorage ps)
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

            List<string> file = new List<string>();

            file.Add($"using Ajuna.NetApi;");
            file.Add($"using Ajuna.NetApi.Model.Meta;");
            file.Add($"using Ajuna.NetApi.Model.Types;");
            file.Add($"using Newtonsoft.Json.Linq;");
            file.Add($"");
            file.Add($"namespace {ps.CanonicalName.Item1}");
            file.Add($"{{");
            file.Add($"    public partial class {ps.Module}");
            file.Add($"    {{");
            if (ps.Docs is not null && ps.Docs.Count > 0)
            {
                file.Add($"        /// <summary>");
                foreach (var s in ps.Docs)
                {
                    file.Add($"        /// {s}");
                }
                file.Add($"        /// </summary>");
            }
            file.Add($"        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"VSTHRD200:Use \\\"Async\\\" suffix for async methods\", Justification = \"<Pending>\")]");
            file.Add($"        public async Task<{ps.OutputType}> {ps.Storage}({inputParams}CancellationToken token)");
            file.Add($"        {{");
            file.Add($"            Storage.Hasher[] hashers = new Storage.Hasher[] {{");
            foreach (var h in ps.Hashers)
            {
                file.Add($"                Storage.Hasher.{h},");
            }
            file.Add($"            }};");
            file.Add($"            IType[] keys = new IType[] {{");
            foreach (var i in inputParamNamesList)
            {
                file.Add($"                {i},");
            }
            file.Add($"            }};");
            file.Add($"");
            file.Add($"            string req = RequestGenerator.GetStorage(\"{ps.Module}\", \"{ps.Storage}\", Storage.Type.{ps.Type}, hashers, keys);");
            file.Add($"");
            file.Add($"            return await _client.client.GetStorageAsync<{ps.OutputType}>(req, token);");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            ps.FileSuffix = $".{ps.Storage}";
            ps.GeneratedCode = file;
            ps.Parsed = true;
        }

        void GenerageStateClassConstructor(ParsedStorage ps)
        {
            if (parsedModules.ContainsKey(ps.Module)) return;

            ParsedStorage psm = new ParsedStorage();
            psm.Module = ps.Module;
            psm.Storage = ps.Storage;


            List<string> file = new List<string>();

            file.Add($"using Ajuna.NetApi;");
            file.Add($"using Ajuna.NetApi.Model.Meta;");
            file.Add($"using Ajuna.NetApi.Model.Types;");
            file.Add($"using Newtonsoft.Json.Linq;");
            file.Add($"");
            file.Add($"namespace {ps.CanonicalName.Item1}");
            file.Add($"{{");
            file.Add($"    public partial class {ps.Module}");
            file.Add($"    {{");
            file.Add($"        readonly Client _client;");
            file.Add($"        public {ps.Module}(Client client)");
            file.Add($"        {{");
            file.Add($"            _client = client;");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            psm.GeneratedCode = file;
            psm.Parsed = true;

            parsedModules[psm.Module] = psm;
        }

        void GenerateQueryClass()
        {
            List<string> file = new List<string>();

            file.Add($"namespace FinalBiome.Sdk.Query");
            file.Add($"{{");
            file.Add($"    public class Query");
            file.Add($"    {{");
            file.Add($"        readonly Client _client;");
            file.Add($"");
            foreach (var m in parsedModules)
                file.Add($"        public {m.Key} {m.Key};");
            file.Add($"");
            file.Add($"        public Query(Client client)");
            file.Add($"        {{");
            file.Add($"            _client = client;");
            foreach (var m in parsedModules)
                file.Add($"            {m.Key} = new {m.Key}(this._client);");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

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
            // save Query class
            string pathQueryFileName = $"{outputDir}/{TypeGenerator.StorageNamespacePrefix}/Query.cs";
            Console.WriteLine($"Write file {pathQueryFileName}");
            File.WriteAllLines(pathQueryFileName, TypeGenerator.banner.Concat(queryClassSource));
        }
    }
}

