using Xunit;

namespace ThunderMain.SoundEx.Test
{
    public class MiracodeTests
    {
        [Fact]
        public void TestMiracode()
        {
            // Validate the SoundEx agorithm
            // using http://www.nara.gov/genealogy/soundex/soundex.html
            Assert.Equal("T522", SoundEx.Miracode.GenerateSoundEx("Tymczak"));
            Assert.Equal("A261", SoundEx.Miracode.GenerateSoundEx("Ashcraft"));
            Assert.Equal("P236", SoundEx.Miracode.GenerateSoundEx("Pfister"));
            Assert.Equal("J250", SoundEx.Miracode.GenerateSoundEx("Jackson"));
            Assert.Equal("G362", SoundEx.Miracode.GenerateSoundEx("Gutierrez"));
            Assert.Equal("V532", SoundEx.Miracode.GenerateSoundEx("VanDeusen"));
            Assert.Equal("D250", SoundEx.Miracode.GenerateSoundEx("Deusen"));
        }
    }
}