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
            var soundex = new MiracodeSoundEx();

            Assert.Equal("T522", soundex.GenerateSoundEx("Tymczak"));
            Assert.Equal("A261", soundex.GenerateSoundEx("Ashcraft"));
            Assert.Equal("P236", soundex.GenerateSoundEx("Pfister"));
            Assert.Equal("J250", soundex.GenerateSoundEx("Jackson"));
            Assert.Equal("G362", soundex.GenerateSoundEx("Gutierrez"));
            Assert.Equal("V532", soundex.GenerateSoundEx("VanDeusen"));
            Assert.Equal("D250", soundex.GenerateSoundEx("Deusen"));
        }
    }
}