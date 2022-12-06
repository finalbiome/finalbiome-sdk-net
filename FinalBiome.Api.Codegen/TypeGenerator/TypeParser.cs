using System;
using FinalBiome.Api.Codegen.Metadata;
using System.Diagnostics;
using System.Globalization;

namespace FinalBiome.Api.Codegen
{
    public class TypeParser
    {
        static readonly string[] reservedPropertyNames =
        {
            "New",
        };

        /// <summary>
        /// Returns native type by name of the Primitive type
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static string NumberPrimitiveToNative(string val)
        {
            return val switch
            {
                "U8" => "byte",
                "U16" => "ushort",
                "U32" => "uint",
                "U64" => "ulong",
                "U128" => "BigInteger",
                "U256" => "BigInteger",
                "I8" => "sbyte",
                "I16" => "short",
                "I32" => "int",
                "I64" => "long",
                "I128" => "BigInteger",
                "I256" => "BigInteger",
                _ => throw new Exception($" For type {val} no native type"),
            };
        }

        /// <summary>
        /// Return primitive type for wrapped (new type) types.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        uint resolvePrimitive(uint typeId)
        {
            NodeType nt = (NodeType)Types[typeId];
            if (IsPrimitive(nt)) return typeId;

            if (nt is not NodeTypeComposite) throw new Exception($"Can't resolve. Type with id {typeId} is not composite");
            if (((NodeTypeComposite)nt).TypeFields.Length != 1) throw new Exception($"Can't resolve. Type with id {typeId} has not one field");
            var innerId = ((NodeTypeComposite)nt).TypeFields[0].TypeId;
            if (IsPrimitive(Types[innerId])) return innerId;
            else return resolvePrimitive(innerId);
        }

        /// <summary>
        /// Store parsed files
        /// </summary>
        public Dictionary<uint, ParsedType> parsedTypes;

        /// <summary>
        /// Store named variants types
        /// Where key is (typeId_of_Variant, variant_index)
        /// Name of specific variant type makes as TypevariantnameVariantname
        /// </summary>
        public Dictionary<(uint, int), ParsedType> parsedVariantsTypes;

        List<ParsedType> existedTypes = new();

        /// <summary>
        /// Storage for new types which don't present in the meta. For generic types
        /// </summary>
        public Dictionary<uint, ParsedType> newTypes;
        internal readonly Dictionary<uint, NodeType> Types;

        public TypeParser(Dictionary<uint, NodeType> types)
        {
            this.Types = types;
            this.parsedTypes = new Dictionary<uint, ParsedType>();
            this.newTypes = new Dictionary<uint, ParsedType>();
            this.parsedVariantsTypes = new Dictionary<(uint, int), ParsedType>();
        }

        public void AddExistedTypes(List<ParsedType> types)
        {
            existedTypes = types;
        }

        /// <summary>
        /// Save generated code to files
        /// </summary>
        /// <param name="outputDir">Root dir for the generated types</param>
        public void Save(string outputDir)
        {
            var types = parsedTypes.Values.ToArray().Concat(newTypes.Values.ToArray()).Concat(parsedVariantsTypes.Values.ToArray());
            foreach (var t in types)
            {
                if (!t.Parsed)
                {
                    Console.WriteLine($"Type {t.TypeName} doesn't parsed. Skip");
                    continue;
                }
                string path = $"{outputDir}/{t.FileNameDir}";
                string pathFileName = $"{path}/{t.FileName}";
                Directory.CreateDirectory(path);
                Console.WriteLine($"Write file {pathFileName}");
                File.WriteAllLines(pathFileName, TypeGenerator.banner.Concat(t.GeneratedCode));
            }
        }

        public void Parse()
        {
            foreach (var type in Types)
            {
                ParseType(type.Value);
            }
        }

        /// <summary>
        /// Parse given, specific type
        /// </summary>
        /// <param name="types"></param>
        /// <param name="value"></param>
        void ParseType(NodeType value)
        {
            if (parsedTypes.ContainsKey(value.Id)) return;
            //if (foundedTypes.ContainsKey(GetTypeNameFormMeta(value))) return;

            if (value is NodeTypePrimitive primitive) ParseTypePrimitive(primitive);
            else if (value is NodeTypeComposite composite) ParseTypeComposite(composite);
            else if (value is NodeTypeArray array) ParseTypeArray(array);
            else if (value is NodeTypeSequence sequence) ParseTypeSequence(sequence);
            else if (value is NodeTypeCompact compact) ParseTypeCompact(compact);
            else if (value is NodeTypeTuple tuple) ParseTypeTuple(tuple);
            else if (value is NodeTypeBitSequence sequence1) ParseTypeBitSequence(sequence1);
            else if (value is NodeTypeVariant variant) ParseTypeVariant(variant);
            else throw new Exception($"Found unhandled type by id {value.Id}");
        }

        void ParseTypePrimitive(NodeTypePrimitive val)
        {
            string typeName = GetTypeNameFormMeta(val);
            //Console.WriteLine($"Parsed ParseTypePrimitive({val.Id}): {typeName}");
            // try to find in predefined types
            foreach (ParsedType pt in existedTypes)
            {
                if (typeName == pt.TypeName)
                {
                    parsedTypes[val.Id] = pt;
                    break;
                }
            }
            if (parsedTypes.ContainsKey(val.Id)) return;
            Console.WriteLine($"WARNING: Found not implemented ParseTypePrimitive: {typeName}");
        }

        void ParseTypeComposite(NodeTypeComposite val)
        {
            // create type name
            string typeName = GetTypeNameFormMeta(val);
            // parse each type field into type
            if (val.TypeFields is not null)
                foreach (NodeTypeField fieldType in val.TypeFields)
                {
                    // create inner type
                    ParseFieldType(fieldType);
                }

            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;

            if (IsBoundedVec(val) || IsWeakBoundedVec(val))
            {
                GenerateBoundedVec(val.Id);
                return;
            }

            if (IsNewType(val))
            {
                GenerateNewType(val.Id);
                return;
            }

            GenerateClassType(val.Id);
        }

        void ParseTypeArray(NodeTypeArray val)
        {
            ParseType(Types[val.TypeId]);

            string typeName = GetTypeNameFormMeta(val);
            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;

            GerenateArrayType(val.Id);
        }

        void ParseTypeSequence(NodeTypeSequence val)
        {
            // Vec
            string typeName = GetTypeNameFormMeta(val);
            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;

            NodeType type = Types[val.TypeId];
            ParseType(type);

            GenerateVecType(val.Id);
        }

        void ParseTypeCompact(NodeTypeCompact val)
        {
            // Compact
            ParseType(Types[val.TypeId]);
            string typeName = GetTypeNameFormMeta(val);
            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;

            GenerateCompactType(val.Id);
        }

        void ParseTypeTuple(NodeTypeTuple val)
        {
            foreach (var f in val.TypeIds)
            {
                ParseType(Types[f]);
            }
            string typeName = GetTypeNameFormMeta(val);
            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;
            GenerateTupleType(val.Id);
        }

        void ParseTypeBitSequence(NodeTypeBitSequence val)
        {
            string typeName = GetTypeNameFormMeta(val);
            Console.WriteLine($"Parsed NodeTypeBitSequence({val.Id}): {typeName}");
            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;

            // TODO Generate BitSequence ?

        }

        void ParseTypeVariant(NodeTypeVariant val)
        {
            // Option or Enum
            string typeName = GetTypeNameFormMeta(val);

            ParsedType pt = new(typeName);
            parsedTypes[val.Id] = pt;

            if (val.Variants is not null)
                foreach (var v in val.Variants)
                {
                    if (v.TypeFields is not null)
                    {
                        foreach (var t in v.TypeFields)
                        {
                            ParseType(Types[t.TypeId]);
                        }
                    }
                }

            // Option
            if (IsOption(val))
            {
                GenerateOptionType(val.Id);
                return;
            }
            // Void
            if (IsVoidType(val))
            {
                GenerateVoidType(val.Id);
                return;
            }

            // create generic base enum if enum with given number of vsriants doesn't exist
            //if (val.Variants is not null && val.Variants.Length > 101)
            //{
            //    GenerateBaseEnumExt((uint)val.Variants.Length);
            //}

            // if specific variant has named type fields, then generates a class for it
            if (val.Variants is not null)
                foreach (var v in val.Variants)
                {
                    // If the first field has a name, we assume that the rest do too (it'll either
                    // be a class or a tuple type). If no fields, assume unnamed.
                    if (v.TypeFields is not null && v.TypeFields.Length > 0 && v.TypeFields[0].Name is not null)
                    {
                        ParseVariantFieldClass(val, v.Index);
                    }
                }


            GenerateEnumType(val.Id);
        }

        static bool IsPrimitive(NodeType value)
        {
            return (value is NodeTypePrimitive);
        }

        string GetTypeNameFormMeta(NodeType type)
        {
            if (parsedTypes.TryGetValue(type.Id, out ParsedType? value)) return value.TypeName;

            if (type is NodeTypePrimitive primitive) return primitive.Primitive.ToString();
            else if (type is NodeTypeComposite)
            {
                string name = PathToCamelCase(type.Path);

                // special case for BoudedVecs
                if (IsBoundedVec(type) || IsWeakBoundedVec(type))
                {
                    // replace given namespace to namespace of the inner type
                    name = TypeNameToParts(name).Item2;
                    // move via first typeparam, as final type
                    Debug.Assert(type.TypeParams.Length == 2);
#pragma warning disable CS8629 // Nullable value type may be null.
                    string innerTypeName = GetTypeNameFormMeta(Types[(uint)type.TypeParams[0].TypeId]);
#pragma warning restore CS8629 // Nullable value type may be null.
                    var innerTypeParts = TypeNameToParts(innerTypeName);
                    if (innerTypeParts.Item1 != "") innerTypeParts.Item1 += ".";
                    // ignore namespaces for parameters names
                    return $"{innerTypeParts.Item1}{name}{innerTypeParts.Item2}";
                }

                if (type.TypeParams is not null)
                {
                    // set type params as names of the types
                    // 
                    List<string> pr = new();
                    foreach (var p in type.TypeParams)
                    {
                        if (p.TypeId is not null)
                        {
                            pr.Add(GetTypeNameFormMeta(Types[(uint)p.TypeId]));
                        }
                        else
                        {
                            pr.Add(p.Name);
                        }
                    }
                }

                return name;
            }
            else if (type is NodeTypeArray array)
            {
                string name = "Array";
                string innerTypeName = GetTypeNameFormMeta(Types[array.TypeId]);
                var innerTypeParts = TypeNameToParts(innerTypeName);
                if (innerTypeParts.Item1 != "") innerTypeParts.Item1 += ".";
                string size = array.Length.ToString();
                // like Array32U8
                return $"{name}{size}{innerTypeParts.Item2}";
            }
            else if (type is NodeTypeSequence sequence)
            {
                string innerTypeName = GetTypeNameFormMeta(Types[sequence.TypeId]);
                var innerTypeParts = TypeNameToParts(innerTypeName);
                if (innerTypeParts.Item1 != "") innerTypeParts.Item1 += ".";
                // like VecU32
                return $"{innerTypeParts.Item1}Vec{innerTypeParts.Item2}";
            }
            else if (type is NodeTypeCompact compact)
            {
                string refTypeName = GetTypeNameFormMeta(Types[compact.TypeId]);
                // move up the namespace of the inner type
                var innerTypeParts = TypeNameToParts(refTypeName);
                if (innerTypeParts.Item1 != "") innerTypeParts.Item1 += ".";

                return $"{innerTypeParts.Item1}Compact{innerTypeParts.Item2}";
            }
            else if (type is NodeTypeTuple tuple)
            {
                string name = "Tuple";
                List<string> refTypeNames = new();
                foreach (uint typeId in tuple.TypeIds)
                {
                    // ignore namespaces for parameters names
                    refTypeNames.Add(TypeNameToParts(GetTypeNameFormMeta(Types[typeId])).Item2);
                }
                // like Tuple_U36_Error
                if (refTypeNames.Count == 0) return $"{name}_Empty";
                return $"{name}_{String.Join("_", refTypeNames)}";
            }
            else if (type is NodeTypeBitSequence)
            {
                throw new NotImplementedException("Parsing of NodeTypeBitSequence is not implemented");
            }
            else if (type is NodeTypeVariant variant) // enum or option
            {
                string name = PathToCamelCase(variant.Path);
                if (IsOption(type))
                {
                    NodeTypeParam[] pr = variant.TypeParams;
                    if (pr.Length != 1 || pr[0].TypeId is null) throw new NotImplementedException($"Option type params doesnt equal 1: {variant.Id}");
                    // like OptionU64
                    // namespace gets from the inner type
#pragma warning disable CS8629 // Nullable value type may be null.
                    string innerTypeName = GetTypeNameFormMeta(Types[(uint)pr[0].TypeId]);
#pragma warning restore CS8629 // Nullable value type may be null.
                    var innerTypeParts = TypeNameToParts(innerTypeName);

                    return $"{name}{innerTypeParts.Item2}";
                }
                else if (IsResult(type))
                {
                    NodeTypeParam[] pr = variant.TypeParams;
                    if (pr.Length != 2 || pr[0].TypeId is null || pr[1].TypeId is null) throw new NotImplementedException($"Option type params doesnt equal 1: {variant.Id}");
                    // like ResultU32_Error
                    // ignore namespace
#pragma warning disable CS8629 // Nullable value type may be null.
                    string fullname1 = GetTypeNameFormMeta(Types[(uint)pr[0].TypeId]);
                    string fullname2 = GetTypeNameFormMeta(Types[(uint)pr[1].TypeId]);
#pragma warning restore CS8629 // Nullable value type may be null.
                    string parameters = $"{TypeNameToParts(fullname1).Item2}_{TypeNameToParts(fullname2).Item2}";

                    return $"{name}{parameters}";
                }

                return name;
            }
            else
            {
                throw new NotImplementedException("Found unimplemented Node type");
            }
        }

        /// <summary>
        /// Split full type name to parts
        /// </summary>
        /// <param name="name"></param>
        /// <returns>(namespaceName, typeName)</returns>
        static (string, string) TypeNameToParts(string name)
        {
            string[] p = name.Split(".");
            if (p.Length == 1) return ("", p[0]);
            string typeName = p.Last();
            string namespaceName = String.Join(".", p.Take(p.Length - 1));
            return (namespaceName, typeName);

        }

        static string PathToCamelCase(string[]? path)
        {
            if (path is null || path.Length == 0) return "";
            List<string> steps = new();
            foreach (string p in path)
            {
                TextInfo ti = new CultureInfo("en-US", false).TextInfo;
                if (p[0].ToString() == p[0].ToString().ToUpper())
                {
                    // add as is
                    steps.Add(p);
                }
                else
                    steps.Add((ti.ToTitleCase(p.Replace("_", " "))).Replace(" ", ""));
            }
            return String.Join(".", steps);
        }

        void ParseFieldType(NodeTypeField fieldType)
        {
            NodeType innerType = Types[fieldType.TypeId];

            if (parsedTypes.ContainsKey(innerType.Id)) return;

            ParseType(innerType);

            // create wrapper type by 
            //createInheritedType(typeName, innerName, innerName); // TODO: change innerType
            //ParsedType pt = new ParsedType(typeName);
            //foundedTypes[fieldType.TypeId] = pt;
        }

        void ParseVariantFieldClass(NodeTypeVariant val, int variandId)
        {
            // Get name of the parent Variant
            string typeName = GetTypeNameFormMeta(val);

            TypeVariant specVariant = val.Variants[variandId];

            // Name of the type set as Variant + SpecificVariantName
            typeName += SnakeCaseToTitle(specVariant.Name);

            // parse each type field into type
            foreach (NodeTypeField fieldType in specVariant.TypeFields)
            {
                // create inner type
                ParseFieldType(fieldType);
            }

            ParsedType pt = new(typeName);
            parsedVariantsTypes[(val.Id, variandId)] = pt;

            GenerateVariantFieldClass(val.Id, variandId);
        }

        /// <summary>
        /// Generates wrapper type classes
        /// </summary>
        /// <param name="typeId"></param>
        void GenerateWrappedType(uint typeId, uint inheritedTypeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;

            ParsedType inheritedPt = parsedTypes[inheritedTypeId];
            var inheritedFullCanonicalName = inheritedPt.FullCanonicalName;

            string? implicitConvTypeName = null;
            try
            {
                // if inheritedPt can be convert to the native type, generate impicit conversion methods
                // implicitConvTypeName = NumberPrimitiveToNative(inheritedPt.CanonicalName.Item2);
                uint primitiveTypeId = resolvePrimitive(inheritedTypeId);
                ParsedType primitiveType = parsedTypes[primitiveTypeId];
                implicitConvTypeName = NumberPrimitiveToNative(primitiveType.CanonicalName.Item2);
            }
            catch (Exception) {}

            GenerateWrappedType(typeId, inheritedFullCanonicalName, implicitConvTypeName);
        }

        void GenerateWrappedType(uint typeId, string inheritedFullCanonicalName, string? implicitConvTypeName = null)
        {
            // implicitConvTypeName used only for the `new types`. I.e. where only one data field (Value).
            // implicitConvTypeName must NOT be the base class
            if (inheritedFullCanonicalName == implicitConvTypeName)
                throw new Exception("implicitConvTypeName must NOT be the base class; for both inheritedFullCanonicalName and implicitConvTypeName gives \"{inheritedFullCanonicalName}\"");

            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            var canonical_name = pt.CanonicalName;


            List<string> file = new();
            file.Add("using System.Numerics;");
            file.Add("using FinalBiome.Api.Types.Primitive;");
            file.Add("using FinalBiome.Api.Types;");
            //file.Add("using FinalBiome.Sdk.Model.Types.Base;");
            file.Add($"namespace {canonical_name.Item1}");
            file.Add("{");
            file.AddRange(DocumentationForType(typeId));
            file.Add($"    public class {canonical_name.Item2} : {inheritedFullCanonicalName}");
            file.Add("    {");
            file.Add($"        public override string TypeName() => \"{canonical_name.Item2}\";");
            if (implicitConvTypeName is not null)
            {
                file.Add($"        public static implicit operator {implicitConvTypeName}({canonical_name.Item2} v) => v.Value;");
                file.Add($"        public static implicit operator {canonical_name.Item2}({implicitConvTypeName} v) {{");
                file.Add($"            {canonical_name.Item2} res = new();");
                file.Add($"            res.Init(v);");
                file.Add($"            return res;");
                file.Add($"        }}");

            }
            file.Add("    }");
            file.Add("}");

            pt.GeneratedCode = file;
            pt.Parsed = true;
        }

        void GenerateEnumType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            var canonical_name = pt.CanonicalName;

            // create enums
            NodeTypeVariant val = (NodeTypeVariant)Types[typeId];
            // set size of variants not as Variants.Length but as max index in Variants
            int size = val.Variants.Select(v => v.Index).Max() + 1;

            // enum element names
            string[] elements = new string[size];
            // enum element types
            string[] types = new string[size];
            // doc string
            string[][] docs = new string[size][];

            foreach (var v in val.Variants)
            {
                int idx = v.Index;
                elements[idx] = v.Name;
                if (v.Docs is not null) docs[idx] = v.Docs;
                if (v.TypeFields is null)
                {
                    types[idx] = "BaseVoid";
                }
                else if (v.TypeFields.Length == 1 && v.TypeFields[0].Name is null)
                {
                    string wrappedType = parsedTypes[v.TypeFields[0].TypeId].CanonicalName.Item1 + "." + parsedTypes[v.TypeFields[0].TypeId].CanonicalName.Item2;
                    types[idx] = wrappedType;
                }
                else
                {
                    string wrappedType;
                    if (v.TypeFields[0].Name is not null)
                    {
                        // assume that all fields are named
                        wrappedType = parsedVariantsTypes[(val.Id, v.Index)].FullCanonicalName;
                    }
                    else
                    {
                        List<string> innerTypes = new();

                        foreach (var t in v.TypeFields)
                        {
                            innerTypes.Add(parsedTypes[t.TypeId].FullCanonicalName);
                        }
                        wrappedType = $"Tuple<{String.Join(", ", innerTypes)}>";
                    }
                    types[idx] = wrappedType;
                }
            }
            // Fill gaps in arrays. These elements is not used.
            // Just adaptation for BaseEnumExt idexed enums
            for (int i = 0; i < size; i++)
            {
                if (elements[i] is null)
                {
                    elements[i] = $"Unsupported_{i}";
                    types[i] = "BaseVoid";
                }
            }

            List<string> file = new();

            file.Add("using System.Numerics;");
            file.Add("using FinalBiome.Api.Types.Primitive;");
            file.Add("using FinalBiome.Api.Types;");
            file.Add($"namespace {canonical_name.Item1}");
            file.Add("{");
            // generate inner enum type
            file.AddRange(DocumentationForType(typeId));
            file.Add($"    public enum Inner{canonical_name.Item2} : byte");
            file.Add("    {");
            for (int idx = 0; idx < size; idx++)
            {
                if (docs[idx] is not null) file.AddRange(DocumentationForField(docs[idx]));
                file.Add($"        {elements[idx]} = {idx},");
            }
            file.Add("    }");
            // generate wrapper class
            string extTypes = $"{String.Join(", ", types)}";
            file.AddRange(DocumentationForType(typeId));
            file.Add($"    public class {canonical_name.Item2} : Enum<Inner{canonical_name.Item2}, {extTypes}>");
            file.Add("    {");
            file.Add($"        public override string TypeName() => \"{canonical_name.Item2}\";");
            file.Add("    }");

            file.Add("}");



            pt.GeneratedCode = file;
            pt.Parsed = true;
        }

        /// <summary>
        /// Wrap Option<_> to OptionU64 or any
        /// </summary>
        /// <param name="typeId"></param>
        void GenerateOptionType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeVariant nt = (NodeTypeVariant)Types[typeId];
            if (nt.Path.Length != 1 || nt.Path[0] != "Option") throw new Exception($"Expected Option, found {String.Join(",", nt.Path)}. Id: {typeId}");
            if (nt.TypeParams.Length != 1 || nt.TypeParams[0].TypeId is null) throw new Exception($"Expected one type for Option, found {nt.TypeParams.Length}. Id: {typeId}");

#pragma warning disable CS8629 // Nullable value type may be null.
            uint innerTypeId = (uint)nt.TypeParams[0].TypeId;
#pragma warning restore CS8629 // Nullable value type may be null.
            ParsedType innerType = parsedTypes[innerTypeId];
            string inheritedFullCanonicalName = innerType.FullCanonicalName;

            GenerateWrappedType(typeId, $"Option<{inheritedFullCanonicalName}>");
        }

        /// <summary>
        /// Wrap BoundedVec<_> to BoundedVec_ like BoundedVecU64 or any
        /// </summary>
        /// <param name="typeId"></param>
        void GenerateBoundedVec(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeComposite nt = (NodeTypeComposite)Types[typeId];
            if (!(IsBoundedVec(nt) || IsWeakBoundedVec(nt))) throw new Exception($"Expected BoundedVec, found {String.Join(",", nt.Path)}. Id: {typeId}");
            if (nt.TypeParams.Length != 2 || nt.TypeParams[0].TypeId is null) throw new Exception($"Expected an inner type for BoundedVec, found {nt.TypeParams.Length}. Id: {typeId}");

#pragma warning disable CS8629 // Nullable value type may be null.
            uint innerTypeId = (uint)nt.TypeParams[0].TypeId;
#pragma warning restore CS8629 // Nullable value type may be null.

            ParsedType innerType = parsedTypes[innerTypeId];
            string innerFullCanonicalName = innerType.FullCanonicalName;

            string typeVec = "BoundedVec";
            if (IsWeakBoundedVec(nt)) typeVec = "WeakBoundedVec";

            GenerateWrappedType(typeId, $"{typeVec}<{innerFullCanonicalName}>");
        }

        void GenerateClassType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeComposite nt = (NodeTypeComposite)Types[typeId];
            if (IsBoundedVec(nt) || IsWeakBoundedVec(nt)) throw new Exception($"Expected NOT BoundedVec, found {String.Join(",", nt.Path)}. Id: {typeId}");

            var canonicalName = pt.CanonicalName;
            var fields = nt.TypeFields;

            List<string> file = new();


            file.Add($"using System;");
            file.Add($"using FinalBiome.Api.Types;");
            file.Add($"using FinalBiome.Api.Types.Primitive;");
            file.Add($"namespace {canonicalName.Item1}");
            file.Add($"{{");
            file.AddRange(DocumentationForType(typeId));
            //file.Add($"    public class {canonicalName.Item2} : BaseComposite");
            file.Add($"    public class {canonicalName.Item2} : Codec");
            file.Add($"    {{");
            file.Add($"        public override string TypeName() => \"{canonicalName.Item2}\";");
            file.Add($"");
            file.Add($"        private int _size;");
            file.Add($"        public override int TypeSize => _size;");
            // properties
            file.Add($"#pragma warning disable CS8618");
            foreach (var field in fields)
            {
                string type = parsedTypes[field.TypeId].FullCanonicalName;
                Debug.Assert(field.Name is not null);
                string methodName = SnakeCaseToTitle(field.Name);
                if (reservedPropertyNames.Contains(methodName)) methodName = "_" + methodName;
                file.Add($"        public {type} {methodName} {{ get; private set; }}");
            }
            file.Add($"#pragma warning restore CS8618");
            // methods
            file.Add($"");
            file.Add($"        public override byte[] Encode()");
            file.Add($"        {{");
            file.Add($"            var bytes = new List<byte>();");
            foreach (var field in fields)
            {
                Debug.Assert(field.Name is not null);
                string methodName = SnakeCaseToTitle(field.Name);
                if (reservedPropertyNames.Contains(methodName)) methodName = "_" + methodName;

                file.Add($"            bytes.AddRange({methodName}.Encode());");
            }
            file.Add($"            return bytes.ToArray();");
            file.Add($"        }}");
            file.Add($"");
            file.Add($"        public override void Decode(byte[] byteArray, ref int p)");
            file.Add($"        {{");
            file.Add($"            var start = p;");
            file.Add($"");
            // decode each field
            foreach (var field in fields)
            {
                string type = parsedTypes[field.TypeId].FullCanonicalName;
                Debug.Assert(field.Name is not null);
                string methodName = SnakeCaseToTitle(field.Name);
                if (reservedPropertyNames.Contains(methodName)) methodName = "_" + methodName;

                file.Add($"            {methodName} = new {type}();");
                file.Add($"            {methodName}.Decode(byteArray, ref p);");
                file.Add($"");
            }
            file.Add($"            _size = p - start;");
            file.Add($"            Bytes = new byte[TypeSize];");
            file.Add($"            Array.Copy(byteArray, start, Bytes, 0, TypeSize);");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            pt.GeneratedCode = file;
            pt.Parsed = true;
        }

        /// <summary>
        /// Generate class for named variants fields
        /// </summary>
        /// <param name="typeId">Id of Variant Type</param>
        /// <param name="variandId">Id of the concrete variant</param>
        void GenerateVariantFieldClass(uint typeId, int variandId)
        {
            ParsedType pt = parsedVariantsTypes[(typeId, variandId)];
            if (pt.Parsed) return;

            NodeTypeVariant vt = (NodeTypeVariant)Types[typeId];

            if (IsBoundedVec(vt) || IsWeakBoundedVec(vt)) throw new Exception($"Expected NOT BoundedVec, found {String.Join(",", vt.Path)}. Id: {typeId}");

            var canonicalName = pt.CanonicalName;
            var fields = vt.Variants[variandId].TypeFields;

            List<string> file = new();


            file.Add($"using System;");
            file.Add($"using FinalBiome.Api.Types;");
            file.Add($"using FinalBiome.Api.Types.Primitive;");
            //file.Add($"using FinalBiome.Sdk.Model.Types.Base;");
            file.Add($"namespace {canonicalName.Item1}");
            file.Add($"{{");
            file.AddRange(DocumentationForType(typeId, variandId));
            file.Add($"    public class {canonicalName.Item2} : Codec");
            file.Add($"    {{");
            file.Add($"        public override string TypeName() => \"{canonicalName.Item2}\";");
            file.Add($"");
            file.Add($"        private int _size;");
            file.Add($"        public override int TypeSize => _size;");
            // properties
            file.Add($"#pragma warning disable CS8618");
            foreach (var field in fields)
            {
                string type = parsedTypes[field.TypeId].FullCanonicalName;
                Debug.Assert(field.Name is not null);
                string methodName = SnakeCaseToTitle(field.Name);
                if (reservedPropertyNames.Contains(methodName)) methodName = "_" + methodName;
                file.Add($"        public {type} {methodName} {{ get; private set; }}");
            }
            file.Add($"#pragma warning restore CS8618");
            // methods
            file.Add($"");
            file.Add($"        public override byte[] Encode()");
            file.Add($"        {{");
            file.Add($"            throw new NotImplementedException();");
            file.Add($"        }}");
            file.Add($"");
            file.Add($"        public override void Decode(byte[] byteArray, ref int p)");
            file.Add($"        {{");
            file.Add($"            var start = p;");
            file.Add($"");
            // decode each field
            foreach (var field in fields)
            {
                string type = parsedTypes[field.TypeId].FullCanonicalName;
                Debug.Assert(field.Name is not null);
                string methodName = SnakeCaseToTitle(field.Name);
                if (reservedPropertyNames.Contains(methodName)) methodName = "_" + methodName;

                file.Add($"            {methodName} = new {type}();");
                file.Add($"            {methodName}.Decode(byteArray, ref p);");
                file.Add($"");
            }
            file.Add($"            _size = p - start;");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            pt.GeneratedCode = file;
            pt.Parsed = true;
        }

        void GenerateNewType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeComposite nt = (NodeTypeComposite)Types[typeId];
            if (!IsNewType(nt)) throw new Exception($"Expected NewType, found {String.Join(",", nt.Path)}. Id: {typeId}");

            if (nt.TypeFields is null)
            {
                GenerateWrappedType(typeId, "BaseVoid");
            }
            else
            {
                uint innerTypeId = nt.TypeFields[0].TypeId;
                GenerateWrappedType(typeId, innerTypeId);
            }
        }

        void GenerateTupleType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeTuple nt = (NodeTypeTuple)Types[typeId];

            List<string> innerTypes = new();

            foreach (uint tId in nt.TypeIds)
            {
                ParsedType t = parsedTypes[tId];
                innerTypes.Add(t.FullCanonicalName);
            }

            if (innerTypes.Count == 0)
            {
                GenerateWrappedType(typeId, "FinalBiome.Api.Types.Tuple");
            }
            else
            {
                string parameters = String.Join(", ", innerTypes);
                GenerateWrappedType(typeId, $"FinalBiome.Api.Types.Tuple<{parameters}>");
            }
        }

        void GerenateArrayType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;

            var canonicalName = pt.CanonicalName;

            NodeTypeArray nt = (NodeTypeArray)Types[typeId];
            uint innerTypeId = (uint)nt.TypeId;
            ParsedType innerType = parsedTypes[innerTypeId];
            var innerFullCanonicalName = innerType.FullCanonicalName;

            uint size = nt.Length;

            List<string> file = new();

            file.Add($"using System;");
            file.Add($"using FinalBiome.Api.Types;");
            file.Add($"using FinalBiome.Api.Types.Primitive;");
            //file.Add($"using FinalBiome.Sdk.Model.Types.Base;");
            file.Add($"namespace {canonicalName.Item1}");
            file.Add($"{{");
            file.AddRange(DocumentationForType(typeId));
            file.Add($"    public class {canonicalName.Item2} : Codec");
            file.Add($"    {{");
            file.Add($"        public override int TypeSize => {size};");
            file.Add($"#pragma warning disable CS8618");
            file.Add($"        public {innerFullCanonicalName}[] Value  {{ get; internal set; }}");
            file.Add($"#pragma warning restore CS8618");
            file.Add($"        public override string TypeName() => $\"[{{new {innerFullCanonicalName}().TypeName()}}; {{this.TypeSize}}]\";");
            file.Add($"");
            file.Add($"        public override byte[] Encode()");
            file.Add($"        {{");
            file.Add($"            var result = new List<byte>();");
            file.Add($"            foreach (var v in Value) {{ result.AddRange(v.Encode()); }};");
            file.Add($"            return result.ToArray();");
            file.Add($"        }}");
            file.Add($"");
            file.Add($"        public override void Decode(byte[] byteArray, ref int pos)");
            file.Add($"        {{");
            file.Add($"            var start = pos;");
            file.Add($"            var array = new {innerFullCanonicalName}[TypeSize];");
            file.Add($"            for (var i = 0; i < array.Length; i++) {{ var t = new {innerFullCanonicalName}(); t.Decode(byteArray, ref pos); array[i] = t; }};");
            file.Add($"            var bytesLength = pos - start;");
            file.Add($"            Bytes = new byte[bytesLength];");
            file.Add($"            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);");
            file.Add($"            Value = array;");
            file.Add($"        }}");
            file.Add($"");
            file.Add($"        public void Init({innerFullCanonicalName}[] array)");
            file.Add($"        {{");
            file.Add($"            Value = array;");
            file.Add($"            Bytes = Encode();");
            file.Add($"        }}");
            file.Add($"    }}");
            file.Add($"}}");

            pt.GeneratedCode = file;
            pt.Parsed = true;
        }

        void GenerateVecType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeSequence nt = (NodeTypeSequence)Types[typeId];

            uint innerTypeId = nt.TypeId;
            ParsedType innerType = parsedTypes[innerTypeId];
            string innerFullCanonicalName = innerType.FullCanonicalName;

            string baseType = "Vec";

            GenerateWrappedType(typeId, $"{baseType}<{innerFullCanonicalName}>");
        }

        void GenerateCompactType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            var canonicalName = pt.CanonicalName;

            NodeTypeCompact nt = (NodeTypeCompact)Types[typeId];
            uint innerTypeId = nt.TypeId;

            ParsedType innerType = parsedTypes[innerTypeId];
            var innerCanonicalName = innerType.CanonicalName;
            var innerFullCanonicalName = innerType.FullCanonicalName;

            // special case aka Compact<Tuple_Empty>
            if (innerCanonicalName.Item2 == "Tuple_Empty")
            {
                GenerateWrappedType(typeId, $"BaseVoid");
                return;
            }

            var alreadyBI = new string[] { "U128", "I128", "U256", "I256" };

            uint primitiveTypeId = resolvePrimitive(innerTypeId);
            ParsedType primitiveType = parsedTypes[primitiveTypeId];
            string nativeType = NumberPrimitiveToNative(primitiveType.CanonicalName.Item2);

            List<string> file = new();
            file.Add($"using System;");
            file.Add($"using System.Numerics;");
            file.Add($"using FinalBiome.Api.Types;");
            file.Add($"using FinalBiome.Api.Types.Primitive;");
            file.Add($"namespace {canonicalName.Item1};");
            file.AddRange(DocumentationForType(typeId));
            file.Add($"public class Compact{innerCanonicalName.Item2} : Compact<{innerFullCanonicalName}>");
            file.Add($"{{");
            file.Add($"    public override void Decode(byte[] bytes, ref int pos)");
            file.Add($"    {{");
            file.Add($"        base.Decode(bytes, ref pos);");
            file.Add($"        Value = ({innerFullCanonicalName}){innerFullCanonicalName}.From(({nativeType})_value);");
            file.Add($"    }}");
            file.Add($"");
            file.Add($"    public void Init({innerFullCanonicalName} value)");
            file.Add($"    {{");
            file.Add($"        Value = value;");
            if (alreadyBI.Contains(innerCanonicalName.Item2))
            {
                file.Add($"        _value = value.Value;");
            }
            else
            {
                file.Add($"        _value = new BigInteger(value.Value);");
            }
            file.Add($"    }}");
            file.Add($"    public static Compact{innerCanonicalName.Item2} From({nativeType} value)");
            file.Add($"    {{");
            file.Add($"        var val = new Compact{innerCanonicalName.Item2}();");
            file.Add($"        {innerFullCanonicalName} i = ({innerFullCanonicalName}){innerFullCanonicalName}.From(value);");
            file.Add($"        val.Init(i);");
            file.Add($"        return val;");
            file.Add($"    }}");
            file.Add($"}}");

            pt.GeneratedCode = file;
            pt.Parsed = true;
        }

        void GenerateVoidType(uint typeId)
        {
            ParsedType pt = parsedTypes[typeId];
            if (pt.Parsed) return;
            NodeTypeVariant nt = (NodeTypeVariant)Types[typeId];
            if (!IsVoidType(nt)) throw new Exception($"Expected Void, found {String.Join(",", nt.Path)}. Id: {typeId}");

            string baseType = "BaseVoid";
            GenerateWrappedType(typeId, $"{baseType}");
        }

        static bool IsOption(NodeType val)
        {
            return val.Path is not null &&
                val.Path.Length == 1 &&
                val.Path[0] == "Option";
        }

        static bool IsResult(NodeType val)
        {
            return val.Path is not null &&
                val.Path.Length == 1 &&
                val.Path[0] == "Result";
        }

        static bool IsBoundedVec(NodeType val)
        {
            return val.Path is not null &&
                val.Path.Last() == "BoundedVec";
        }

        static bool IsWeakBoundedVec(NodeType val)
        {
            return val.Path is not null &&
                val.Path.Last() == "WeakBoundedVec";
        }

        static bool IsNewType(NodeTypeComposite val)
        {
            return val.TypeFields is null || (val.TypeFields.Length == 1 &&
                val.TypeFields[0].Name is null);
        }

        static bool IsVoidType(NodeTypeVariant val)
        {
            return val.Variants is null || val.Variants.Length == 0;
        }

        /// <summary>
        /// Transform string from `snake_case` to `TitleCase`
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SnakeCaseToTitle(string value)
        {
            if (value.Contains('_'))
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return textInfo.ToTitleCase(value.Replace("_", " ")).Replace(" ", "");
            } else
            {
                return System.Char.ToUpperInvariant(value[0]) + value[1..];
            }
        }
        /// <summary>
        /// Transform string from `snake_case` to `camelCase`
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SnakeCaseToCamel(string value)
        {
            value = SnakeCaseToTitle(value);
            return System.Char.ToLowerInvariant(value[0]) + value[1..];
        }

        /// <summary>
        /// Create XML documentation for types
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        List<string> DocumentationForType(uint typeId, int? variandId = null)
        {
            List<string> docs = new();
            docs.Add("    /// <summary>");

            string[] typeDocs = variandId is null ? Types[typeId].Docs : ((NodeTypeVariant)Types[typeId]).Variants[(int)variandId].Docs;
            if (typeDocs is not null)
            {
                foreach (var item in typeDocs)
                {
                    docs.Add($"    /// {Utils.CleanDocString(item)}");
                }

                docs.Add("    ///");
                docs.Add("    ///");
            }
            docs.Add($"    /// Generated from meta with Type Id {typeId}" + (variandId is null ? "" : $", Variant Id {variandId}"));
            docs.Add("    /// </summary>");

            return docs;
        }

        /// <summary>
        /// Create XML docs for field
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        static List<string> DocumentationForField(string[] str)
        {
            List<string> docs = new();
            docs.Add("    /// <summary>");
            foreach (var item in str)
            {
                docs.Add($"    /// {Utils.CleanDocString(item)}");
            }
            docs.Add("    /// </summary>");

            return docs;
        }
        /// <summary>
        /// Generate Generic type BaseEnumExt for given number of types
        /// </summary>
        /// <param name="paramsNumber"></param>
        //void GenerateBaseEnumExt(uint paramsNumber)
        //{
        //    if (paramsNumber < 101) throw new Exception($"BaseEnumExt with {paramsNumber} parameters already exist");
        //    if (paramsNumber > 256) throw new Exception($"BaseEnumExt with {paramsNumber} parameters can not be created"); // not sure
        //    List<string> file = new List<string>();

        //    string[] types = new string[paramsNumber];
        //    for (int i = 0; i < paramsNumber; i++)
        //    {
        //        types[i] = $"T{i + 1}";
        //    }


        //    file.Add($"using System;");
        //    file.Add($"using System.Collections.Generic;");
        //    file.Add($"using Newtonsoft.Json;");
        //    file.Add($"using Newtonsoft.Json.Converters;");
        //    file.Add($"");
        //    file.Add($"namespace FinalBiome.Api.Types");
        //    file.Add($"{{");
        //    file.Add($"    public class BaseEnumExt<T0, {String.Join(", ", types)}> : BaseEnumType");
        //    file.Add($"        where T0 : Enum");
        //    foreach (var type in types)
        //    {
        //        file.Add($"        where {type} : IType, new()");
        //    }
        //    file.Add($"");
        //    file.Add($"    {{");
        //    file.Add($"        ");
        //    file.Add($"        public override string TypeName() => typeof(T0).Name;");
        //    file.Add($"        public override byte[] Encode()");
        //    file.Add($"        {{");
        //    file.Add($"            return Bytes;");
        //    file.Add($"        }}");
        //    file.Add($"");
        //    file.Add($"        public override void Decode(byte[] byteArray, ref int p)");
        //    file.Add($"        {{");
        //    file.Add($"            var start = p;");
        //    file.Add($"            var enumByte = byteArray[p];");
        //    file.Add($"");
        //    file.Add($"            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);");
        //    file.Add($"            p += 1;");
        //    file.Add($"");
        //    file.Add($"            Value2 = DecodeOneOf(enumByte, byteArray, ref p);");
        //    file.Add($"");
        //    file.Add($"            TypeSize = p - start;");
        //    file.Add($"");
        //    file.Add($"            Bytes = new byte[TypeSize];");
        //    file.Add($"            Array.Copy(byteArray, start, Bytes, 0, TypeSize);");
        //    file.Add($"        }}");
        //    file.Add($"");
        //    file.Add($"        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)");
        //    file.Add($"        {{");
        //    file.Add($"            IType result;");
        //    file.Add($"            switch (value)");
        //    file.Add($"            {{");
        //    for (var i = 0; i < paramsNumber; i++)
        //    {
        //        file.Add($"                case 0x{i.ToString("X2")}: result = new T{i + 1}(); break;");
        //    }
        //    file.Add($"                default:");
        //    file.Add($"                    return null;");
        //    file.Add($"            }}");
        //    file.Add($"");
        //    file.Add($"            if (result.GetType().Name == \"Void\") return null;");
        //    file.Add($"            result.Decode(byteArray, ref p);");
        //    file.Add($"            return result;");
        //    file.Add($"        }}");
        //    file.Add($"");
        //    file.Add($"        public void Create(T0 t, IType value2)");
        //    file.Add($"        {{");
        //    file.Add($"            List<byte> bytes = new List<byte>();");
        //    file.Add($"            bytes.Add(Convert.ToByte(t));");
        //    file.Add($"            bytes.AddRange(value2.Encode());");
        //    file.Add($"            Bytes = bytes.ToArray();");
        //    file.Add($"            Value = t;");
        //    file.Add($"            Value2 = value2;");
        //    file.Add($"        }}");
        //    file.Add($"");
        //    file.Add($"        [JsonConverter(typeof(StringEnumConverter))]");
        //    file.Add($"        public T0 Value {{ get; set; }}");
        //    file.Add($"");
        //    file.Add($"        public IType Value2 {{ get; set; }}");
        //    file.Add($"    }}");
        //    file.Add($"}}");

        //    // just for right file path for saving
        //    string typeName = "Model.Types.Base." + $"BaseEnumExt_T{paramsNumber}";
        //    ParsedType pt = new ParsedType(typeName);
        //    pt.GeneratedCode = file;
        //    pt.Parsed = true;
        //    newTypes[(uint)newTypes.Count] = pt;
        //}

        /// <summary>
        /// Splits the given tuple into internal types and returns their canonical names
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns>canonical names of internal types</returns>
        public List<string> SplitTupleToInnerTypes(uint typeId)
        {
            if (Types[typeId] is not NodeTypeTuple) throw new Exception($"Expected Tuple, found {String.Join(",", Types[typeId].Path)}. Id: {typeId}");

            List<string> innerTypes = new();

            foreach(var f in ((NodeTypeTuple)Types[typeId]).TypeIds)
            {
                innerTypes.Add(parsedTypes[f].FullCanonicalName);
            }

            return innerTypes;
        }
    }
}

