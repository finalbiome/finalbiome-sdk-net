using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test.Utils
{
    public class ExtensionsTests
    {
        [Test]
        public void AsBytesTest()
        {
            var sparkleHeart = "💖".AsBytes();
            var sparkleHeartBytes = new byte[] { 240, 159, 146, 150 };
            Assert.That(sparkleHeart, Is.EqualTo(sparkleHeartBytes));
        }

        [Test]
        public void FromUtf8Test()
        {
            var sparkleHeartBytes = new byte[] { 240, 159, 146, 150 };
            var sparkleHeart = sparkleHeartBytes.FromUtf8();
            Assert.That(sparkleHeart, Is.EqualTo("💖"));
        }
    }
}

