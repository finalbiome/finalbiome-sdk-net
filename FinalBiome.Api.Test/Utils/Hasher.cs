using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test.Utils;

public class HasherTests
{

    [Test]
    public void Hasher()
    {
      //  List<byte[]> data = new List<byte[]>
      //  {
      //      new[] { (byte)'a', (byte)'b', (byte)'c' },
      //      new byte[3268].RandomFill(), // size of Windows 10 srgb.icm
		    //new byte[1024 * 1024 * 3].RandomFill()
      //  };

      //  foreach (var item in data)
      //  {
      //      var cfg = new Blake2Core.Blake2BConfig()
      //      {
      //          OutputSizeInBytes = 32
      //      };
      //      var core = Blake2Core.Blake2B.ComputeHash(item, cfg);
      //      var fast = Blake2Fast.Blake2b.ComputeHash(32, item);
      //      Assert.That(fast, Is.EqualTo(core));

      //  }
    }
}

public static class Exts
{
    public static byte[] RandomFill(this byte[] a)
    {
        new Random(42).NextBytes(a);
        return a;
    }
}