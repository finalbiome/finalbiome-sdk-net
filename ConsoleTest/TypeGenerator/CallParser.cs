
using Ajuna.NetApi.Model.Meta;
using Newtonsoft.Json.Linq;

namespace FinalBiome.TypeGenerator
{
    public class ParsedCallsParams
    {
        static string[] reservedKeywords =
        {
            "abstract",
            "as",
            "base",
            "bool",
            "break",
            "byte",
            "case",
            "catch",
            "char",
            "checked",
            "class",
            "const",
            "continue",
            "decimal",
            "default",
            "delegate",
            "do",
            "double",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "virtual",
            "void",
            "volatile",
            "while",
            "add",
            "and",
            "alias",
            "ascending",
            "args",
            "async",
            "await",
            "by",
            "descending",
            "dynamic",
            "equals",
            "file",
            "from",
            "get",
            "global",
            "group",
            "init",
            "into",
            "join",
            "let",
            "managed",
            "nameof",
            "nint",
            "not",
            "notnull",
            "nuint",
            "on",
            "or",
            "orderby",
            "partial",
            "record",
            "remove",
            "required",
            "scoped",
            "select",
            "set",
            "unmanaged",
            "value",
            "var",
            "when",
            "where",
            "with",
            "yield",
        };
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private string name;
        /// <summary>
        /// Fully qualified type name
        /// </summary>
        public string Type;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Name
        {
            get => name;
            set
            {
                name = TypeParser.SnakeCaseToCamel(value);
                if (reservedKeywords.Contains(name)) name = "_" + name;
            }
        }
    }

    public class ParsedCalls
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ModuleName;
        public string CallName;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public uint ModuleIndex;
        public int CallIndex;
        public List<ParsedCallsParams> CallTypes = new List<ParsedCallsParams>();
        public List<string>? Docs;
        public bool Parsed = false;
        public List<string> GeneratedCode = new List<string>();
        public string FileSuffix = "";

        public (string, string) CanonicalName
        {
            get { return ($"{TypeGenerator.RootNamespace}.{TypeGenerator.TransactionsNamespacePrefix}", ModuleName); }
        }

        public string FullCanonicalName
        {
            get { return $"{CanonicalName.Item1}.{CanonicalName.Item2}"; }
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
                return TypeGenerator.TransactionsNamespacePrefix.Replace(".", "/");
            }
        }
    }

    public class CallParser
    {
        NodeMetadataV14 metadata;
        internal List<ParsedCalls> parsedCalls;
        /// <summary>
        /// Holds code of module classes.
        /// Key - the module name
        /// </summary>
        internal Dictionary<string, ParsedCalls> parsedModules = new Dictionary<string, ParsedCalls>();

        List<string> transactionsClassSource = new List<string>();
        TypeParser typeParser;

        public CallParser(NodeMetadataV14 metadata, TypeParser typeParser)
        {
            this.metadata = metadata;
            parsedCalls = new List<ParsedCalls>();
            this.typeParser = typeParser;
        }

        public void Parse()
        {
            foreach (var module in metadata.Modules)
            {
                ParseModule(module.Value);
            }
            GenerateTxClasses();
            GenerateTransactionsClass();
        }

        void ParseModule(PalletModule module)
        {
            TakeApartModules(module);
        }

        void TakeApartModules(PalletModule module)
        {
            if (module.Calls is not null)
                foreach (var call in ((NodeTypeVariant)metadata.Types[module.Calls.TypeId]).Variants)
                {
                    ParsedCalls pc = new ParsedCalls();
                    pc.ModuleName = module.Name;
                    pc.ModuleIndex = module.Index;
                    pc.CallName = TypeParser.SnakeCaseToTitle(call.Name);
                    // stupid Compiler Error CS0542
                    if (pc.CallName == module.Name) pc.CallName += "Call";

                    pc.CallIndex = call.Index;
                    if (call.TypeFields is not null)
                        foreach (var callType in call.TypeFields)
                        {
                            ParsedCallsParams pcp = new ParsedCallsParams();
                            pcp.Name = callType.Name;
                            pcp.Type = typeParser.parsedTypes[callType.TypeId].FullCanonicalName;
                            pc.CallTypes.Add(pcp);
                        }
                    if (call.Docs is not null)
                    {
                        pc.Docs = new List<string>();
                        foreach (var s in call.Docs)
                        {
                            pc.Docs.Add(Utils.CleanDocString(s));
                        }
                    }

                    parsedCalls.Add(pc);
                }
        }

        void GenerateTxClasses()
        {
            foreach (var pc in parsedCalls)
            {
                GenerageTxClassConstructor(pc);
                GenerateTxClass(pc);
            }
        }

        void GenerateTxClass(ParsedCalls pc)
        {

            List<string> callParamsList = new List<string>();
            List<string> callTypeList = new List<string>();
            List<string> callNameList = new List<string>();
            foreach (var t in pc.CallTypes)
            {
                callParamsList.Add($"{t.Type} {t.Name}");
                callTypeList.Add(t.Type);
                callNameList.Add(t.Name);
            }
            string callParam = String.Join(", ", callParamsList);
            if (callParam.Length > 0) callParam += ",";
            string callTypes = String.Join(", ", callTypeList);
            string callNames = String.Join(", ", callNameList);

            List<string> file = new List<string>();

            file.Add($"using Ajuna.NetApi.Model.Extrinsics;");
            file.Add($"using Ajuna.NetApi.Model.Rpc;");
            file.Add($"using Ajuna.NetApi.Model.Types.Base;");
            file.Add($"");
            file.Add($"namespace {pc.CanonicalName.Item1}");
            file.Add($"{{");
            file.Add($"    public partial class {pc.ModuleName}");
            file.Add($"    {{");
            if (pc.Docs is not null && pc.Docs.Count > 0)
            {
                file.Add($"        /// <summary>");
                foreach (var s in pc.Docs)
                {
                    file.Add($"        /// {s}");
                }
                file.Add($"        /// </summary>");
            }
            file.Add($"        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"VSTHRD200:Use \\\"Async\\\" suffix for async methods\", Justification = \"<Pending>\")]");
            file.Add($"        public async Task<string?> {pc.CallName}(Ajuna.NetApi.Model.Types.Account account, {callParam} Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)");
            file.Add($"        {{");
            if (pc.CallTypes.Count > 0)
            {
                file.Add($"            BaseTuple<{callTypes}> data = new BaseTuple<{callTypes}>();");
                file.Add($"            data.Create({callNames});");
                file.Add($"            byte[] parameters = data.Encode();");
            }
            else
            {
                file.Add($"            byte[] parameters = new byte[] {{ }};");
            }
            file.Add($"            Method method = new Method({pc.ModuleIndex}, {pc.CallIndex}, parameters);");
            file.Add($"            ChargeType charge = ChargeTransactionPayment.Default();");
            file.Add($"            uint lifeTime = 0;");
            file.Add($"            token = CancellationToken.None;");
            file.Add($"            ");
            file.Add($"            if (subscription is null)");
            file.Add($"            {{");
            file.Add($"                await _client.client.Author.SubmitExtrinsicAsync(method, account, charge, lifeTime, (CancellationToken)token);");
            file.Add($"                return null;");
            file.Add($"            }}");
            file.Add($"            else");
            file.Add($"            {{");
            file.Add($"                string subscriptionId = await _client.client.Author.SubmitAndWatchExtrinsicAsync(subscription, method, account, charge, lifeTime, (CancellationToken)token);");
            file.Add($"                return subscriptionId;");
            file.Add($"            }}");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            pc.FileSuffix = $".{pc.CallName}";
            pc.GeneratedCode = file;
            pc.Parsed = true;
        }

        void GenerageTxClassConstructor(ParsedCalls pc)
        {
            if (parsedModules.ContainsKey(pc.ModuleName)) return;

            ParsedCalls pcm = new ParsedCalls();
            pcm.ModuleName = pc.ModuleName;
            pcm.CallName = pc.CallName;

            List<string> file = new List<string>();

            file.Add($"namespace {pc.CanonicalName.Item1}");
            file.Add($"{{");
            file.Add($"    public partial class {pc.ModuleName}");
            file.Add($"    {{");
            file.Add($"        readonly Client _client;");
            file.Add($"        ");
            file.Add($"        public {pc.ModuleName}(Client client)");
            file.Add($"        {{");
            file.Add($"            _client = client;");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            pcm.GeneratedCode = file;
            pcm.Parsed = true;

            parsedModules[pcm.ModuleName] = pcm;
        }

        void GenerateTransactionsClass()
        {
            List<string> file = new List<string>();

            file.Add($"namespace FinalBiome.Sdk.Transactions");
            file.Add($"{{");
            file.Add($"    public class Transactions");
            file.Add($"    {{");
            file.Add($"        readonly Client _client;");
            file.Add($"");
            foreach (var m in parsedModules)
                file.Add($"        public {m.Key} {m.Key};");
            file.Add($"");
            file.Add($"        public Transactions(Client client)");
            file.Add($"        {{");
            file.Add($"            _client = client;");
            foreach (var m in parsedModules)
                file.Add($"            {m.Key} = new {m.Key}(this._client);");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            transactionsClassSource = file;
        }

        public void Save(string outputDir)
        {
            foreach (var s in parsedCalls.Concat(parsedModules.Values.ToList()))
            {
                if (!s.Parsed)
                {
                    Console.WriteLine($"Type {s.ModuleName}.{s.CallName} doesn't parsed. Skip");
                    continue;
                }
                string path = $"{outputDir}/{s.FileNameDir}";
                string pathFileName = $"{path}/{s.FileName}";
                Directory.CreateDirectory(path);
                Console.WriteLine($"Write file {pathFileName}");
                File.WriteAllLines(pathFileName, TypeGenerator.banner.Concat(s.GeneratedCode));
            }
            // save Query class
            string pathTxFileName = $"{outputDir}/{TypeGenerator.TransactionsNamespacePrefix}/Transactions.cs";
            Console.WriteLine($"Write file {pathTxFileName}");
            File.WriteAllLines(pathTxFileName, TypeGenerator.banner.Concat(transactionsClassSource));
        }
    }
}

