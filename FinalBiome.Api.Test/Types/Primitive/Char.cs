
namespace FinalBiome.Api.Test;

public class CharTests
{
    [Test]
    public void CharTest()
    {
        var oneChar = 'b';
        var primChar = new Types.Primitive.Char();
        primChar.Init(oneChar);
        Assert.That(primChar.Value, Is.EqualTo(oneChar));
    }
}

