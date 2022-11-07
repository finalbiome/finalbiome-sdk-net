﻿using System;
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
        public static string TransactionsNamespacePrefix = "Transactions";
        public static string[] banner =
        {
            "///",
            "/// This file is generated automatically",
            "/// DO NOT CHANGE THE CONTENT OF THE FILE!",
            "///",
        };
        MetaData metaData;

        List<ParsedType> existedTypes = new List<ParsedType>();

        TypeParser typeParser;
        StateParser stateParser;
        CallParser callParser;

        public TypeGenerator(MetaData metaData)
        {
            this.metaData = metaData;

            typeParser = new TypeParser(metaData.NodeMetadata.Types);
            stateParser = new StateParser(metaData.NodeMetadata.Modules, typeParser);
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
            typeParser.Save(outputDir + "/Types/Generated");
            stateParser.Save(outputDir);
            callParser.Save(outputDir);
        }

        /// <summary>
        /// Parse given metadata
        /// </summary>
        public void Parse()
        {
            typeParser.Parse();
            stateParser.Parse();
            callParser.Parse();
        }

        public int CountParsedTypes()
        {
            return typeParser.parsedTypes.Where((t) => t.Value.Parsed).Count() + typeParser.parsedVariantsTypes.Where((t) => t.Value.Parsed).Count();
        }
        public int CountParsedStorages()
        {
            return stateParser.parsedStorages.Where((t) => t.Parsed).Count() + stateParser.parsedModules.Where((t) => t.Value.Parsed).Count() + 1;
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
            if (value.Length == 0 || value == " ") return "<para></para>";
            value += "<br/>";
            return value;
        }
    }
}

