using System.Text.RegularExpressions;
using FinalBiome.Api.Codegen.Metadata;

namespace FinalBiome.Api.Codegen
{
    public class TypeGenerator
    {
        // TODO: implement checks for existing all primitive types which present in the metadata.
        public static string RootNamespace = "FinalBiome.Api";
        public static string TypesNamespacePrefix = "Types";
        public static string StorageNamespacePrefix = "Storage";
        public static string TransactionsNamespacePrefix = "Tx";
        public static string[] banner =
        {
            "///",
            "/// This file is generated automatically",
            "/// DO NOT CHANGE THE CONTENT OF THE FILE!",
            "///",
        };
        MetaDataV14 metaData;

        List<ParsedType> existedTypes = new List<ParsedType>();

        TypeParser typeParser;
        StorageParserV2 storageParser;
        CallParser callParser;

        public TypeGenerator(MetaDataV14 metaData)
        {
            this.metaData = metaData;

            typeParser = new TypeParser(metaData.NodeMetadata.Types);
            storageParser = new StorageParserV2(metaData.NodeMetadata.Modules, typeParser);
            callParser = new CallParser(metaData.NodeMetadata, typeParser);
        }

        /// <summary>
        /// Adds types which existed and implemented. Primarily primitives
        /// </summary>
        /// <param name="types"></param>
        public void AddExistedTypes(List<ParsedType> types)
        {
            typeParser.AddExistedTypes(types);
        }

        /// <summary>
        /// Save generated code to files
        /// </summary>
        /// <param name="outputDir"></param>
        public void Save(string outputDir)
        {
            typeParser.Save(outputDir + "/Types");
            storageParser.Save(outputDir);
            callParser.Save(outputDir);
        }

        /// <summary>
        /// Parse given metadata
        /// </summary>
        public void Parse()
        {
            typeParser.Parse();
            storageParser.Parse();
            callParser.Parse();
        }

        public int CountParsedTypes()
        {
            return typeParser.parsedTypes.Where((t) => t.Value.Parsed).Count() + typeParser.parsedVariantsTypes.Where((t) => t.Value.Parsed).Count();
        }
        public int CountParsedStorages()
        {
            return storageParser.parsedStorages.Where((t) => t.Parsed).Count() + storageParser.parsedModules.Where((t) => t.Value.Parsed).Count() + 1;
        }
        public int CountParsedTransactionTypes()
        {
            return callParser.parsedCalls.Where((t) => t.Parsed).Count() + callParser.parsedModules.Where((t) => t.Value.Parsed).Count() + 1;
        }
    }

    public class Utils
    {
        /// <summary>
        /// Regex for replacing whitespaces
        /// </summary>
        public static readonly Regex rCleanDocs = new Regex(@"[\r\n\t\f\v]+");

        public static string CleanDocString(string value)
        {
            value = rCleanDocs.Replace(value, " ");
            value = value.Replace("<", "&lt;");
            value = value.Replace(">", "&gt;");
            if (value.Length == 0 || value == " ") return "<para></para>";
            value += "<br/>";
            return value;
        }
    }
}

