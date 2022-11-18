using FinalBiome.Api.Rpc;
using FinalBiome.Api.Rpc.JsonConverters;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace FinalBiome.Api.Test.Rpc.Types;

public class DigestTests
{
    [Test]
    public void DigestTest()
    {
        var d2 = new Digest();

        var log0 = new DigestItem();

        var t = new Vec<U8>();
        List<U8> b0 = new List<U8>();
        for (byte i = 1; i < 4; i++)
        {
            var a = new U8();
            a.Init(i);
            b0.Add(a);
        }
        t.Init(b0.ToArray());
        log0.Init(innerDigestItem.Other, t);



        var log1 = new DigestItem();
        var t0 = new Vec<U8>();
        List<U8> b3 = new List<U8>();
        for (byte i = 1; i < 4; i++)
        {
            var a = new U8();
            a.Init(i);
            b3.Add(a);
        }
        t0.Init(b3.ToArray());

        var c = new ConsensusEngineId();
        List<U8> b1 = new List<U8>();
        foreach (var i in Encoding.UTF8.GetBytes("test"))
        {
            var a = new U8();
            a.Init(i);
            b1.Add(a);
        }
        c.Init(b1.ToArray());

        var sealData = new FinalBiome.Api.Types.Tuple<ConsensusEngineId, Vec<U8>>();
        sealData.Init(c, t0);
        log1.Init(innerDigestItem.Seal, sealData);

        d2.Init(new DigestItem[] { log0, log1 });

        Assert.That(d2.Logs.Encode().ToHex(), Is.EqualTo("0x08000C01020305746573740C010203"));

    }
}

