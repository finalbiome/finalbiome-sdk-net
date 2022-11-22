using System;
using System.Collections;

namespace FinalBiome.Api.Codegen.Metadata
{
    public class RuntimeMetadata : Codec
    {
        public MetaDataInfo MetaDataInfo { get; private set; }
        public RuntimeMetadataV14 RuntimeMetadataData { get; private set; }

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

