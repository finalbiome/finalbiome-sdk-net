using System;
using System.Globalization;
using System.Xml.Linq;
using Ajuna.NetApi.Model.Meta;
using static Ajuna.NetApi.Model.Meta.Storage;
using System.Diagnostics;
using Org.BouncyCastle.Utilities;
using System.Drawing;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalBiome.TypeGenerator
{
    public class TypeGenerator
    {
        public static string RootNamespace = "FinalBiome.Sdk";
        public static string StorageNamespacePrefix = "Query";
        public static string[] banner =
        {
            "///",
            "/// This file is generated automatically",
            "/// DO NOT CHANGE THE CONTENT OF THE FILE!",
            "///",
        };
        MetaData metaData;

        List<ParsedType> existedTypes = new List<ParsedType>();

        /// <summary>
        /// Regex for replacing whitespaces
        /// </summary>
        public static readonly Regex rCleanDocs = new Regex(@"[\r\n\t\f\v]+");

        TypeParser typeParser;
        StateParser stateParser;

        public TypeGenerator(MetaData metaData)
        {
            this.metaData = metaData;

            typeParser = new TypeParser(metaData.NodeMetadata.Types);
            stateParser = new StateParser(metaData.NodeMetadata.Modules, typeParser);
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
            typeParser.Save(outputDir + "/Types/Generated");
            stateParser.Save(outputDir);
        }

        /// <summary>
        /// Parse given metadata
        /// </summary>
        public void Parse()
        {
            typeParser.Parse();
            stateParser.Parse();
        }

        public Dictionary<uint, ParsedType> ParsedTypes
        {
            get { return typeParser.parsedTypes; }
        }


    }
}

