using System;
using System.Collections;

namespace FinalBiome.Api.Codegen.Metadata
{
    public class RuntimeMetadata : Codec
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MetaDataInfo MetaDataInfo { get; private set; }
        public RuntimeMetadataV14 RuntimeMetadataData { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            MetaDataInfo = new MetaDataInfo();
            MetaDataInfo.Decode(bytes, ref pos);

            RuntimeMetadataData = new RuntimeMetadataV14();
            RuntimeMetadataData.Decode(bytes, ref pos);

            TypeSize = pos - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override string TypeName() => "RuntimeMetadata";
    }
}

