using System;
namespace FinalBiome.Api.Codegen
{
    public class ParsedType
    {
        public string TypeName;
        public string? RustTypeName;
        public bool Parsed = false;
        public string? Namespace;
        public List<string> GeneratedCode = new List<string>();

        public ParsedType(string TypeName)
        {
            this.TypeName = TypeName;
        }

        public ParsedType(string TypeName, string? RustTypeName, bool Parsed, string Namespace)
        {
            this.TypeName = TypeName;
            this.RustTypeName = RustTypeName;
            this.Parsed = Parsed;
            this.Namespace = Namespace;
        }

        /// <summary>
        /// Returns (namespace, type_name)
        /// </summary>
        public (string, string) CanonicalName
        {
            get
            {
                string[] typeAsPath = TypeName.Split(".");
                // if Namespace defined, do not change it
                if (Namespace is not null) return (Namespace, typeAsPath.Last());

                if (typeAsPath.Length == 1) return ($"{TypeGenerator.RootNamespace}.{TypeGenerator.TypesNamespacePrefix}", typeAsPath[0]);
                else
                {
                    string Namespace = $"{TypeGenerator.RootNamespace}.{TypeGenerator.TypesNamespacePrefix}." + String.Join(".", typeAsPath.Take(typeAsPath.Length - 1));
                    return (Namespace, typeAsPath.Last());
                }
            }
        }

        public string FullCanonicalName
        {
            get
            {
                return $"{CanonicalName.Item1}.{CanonicalName.Item2}";
            }
        }

        public string FileName
        {
            get
            {
                return $"{CanonicalName.Item2}.cs";
            }
        }
        public string FileNameDir
        {
            get
            {
                //return CanonicalName.Item1.Substring(RootNamespace.Length + 1).Replace(".", "/");
                return CanonicalName.Item1.Replace(".", "/");
            }
        }
    }
}

