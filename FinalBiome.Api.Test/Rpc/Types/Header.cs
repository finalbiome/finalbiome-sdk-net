
using System.Diagnostics;
using System.Text;
using FinalBiome.Api.Rpc;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test.Rpc.Types;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class HeaderTests
{
    [Test]
    public void HeaderTest()
    {
        /// checking encoding of the digest
        Header h = new Header();
        var p = new Hash();
        p.Init(Hasher.BlakeTwo256(Encoding.UTF8.GetBytes("1000")));
        h.ParentHash = p;
        var n = CompactU32.From(2000);
        h.Number = n;
        var s = new Hash();
        s.Init(Hasher.BlakeTwo256(Encoding.UTF8.GetBytes("3000")));
        h.StateRoot = s;

        var e1 = new Hash();
        e1.Init(Hasher.BlakeTwo256(Encoding.UTF8.GetBytes("4000")));
        h.ExtrinsicsRoot = e1;

        var d = new Digest();

        var log0 = new DigestItem();

        var t = new Vec<U8>();
        List<U8> b0 = new List<U8>();
        foreach (var b01 in Encoding.UTF8.GetBytes("5000"))
        {
            var a = new U8();
            a.Init(b01);
            b0.Add(a);
        }
        t.Init(b0.ToArray());
        log0.Init(innerDigestItem.Other, t);

        d.Init(new DigestItem[] { log0 });
        h.Digest = d;

        //Console.WriteLine("[{0}]", string.Join(", ", h.Encode()));

        var checkDecode = new byte[]
        {
            197, 243, 254, 225, 31, 117, 21, 218, 179, 213, 92, 6, 247, 164, 230, 25, 47, 166,
            140, 117, 142, 159, 195, 202, 67, 196, 238, 26, 44, 18, 33, 92, 65, 31, 219, 225,
            47, 12, 107, 88, 153, 146, 55, 21, 226, 186, 110, 48, 167, 187, 67, 183, 228, 232,
            118, 136, 30, 254, 11, 87, 48, 112, 7, 97, 31, 82, 146, 110, 96, 87, 152, 68, 98,
            162, 227, 222, 78, 14, 244, 194, 120, 154, 112, 97, 222, 144, 174, 101, 220, 44,
            111, 126, 54, 34, 155, 220, 253, 124, 4, 0, 16, 53, 48, 48, 48
        };

        Assert.That(h.Encode(), Is.EqualTo(checkDecode));

    }
}

