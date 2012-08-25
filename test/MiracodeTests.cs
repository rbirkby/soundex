using Xunit;

namespace ThunderMain.SoundEx.Test
{
    /// <summary>
    /// Validate the SoundEx agorithm
    /// using http://www.nara.gov/genealogy/soundex/soundex.html
    /// </summary>
    public class MiracodeTests
    {
        [Fact]
        public void TestMiracode()
        {
            Assert.Equal("T522", SoundEx.Miracode.GenerateSoundEx("Tymczak"));
            Assert.Equal("A261", SoundEx.Miracode.GenerateSoundEx("Ashcraft"));
            Assert.Equal("P236", SoundEx.Miracode.GenerateSoundEx("Pfister"));
            Assert.Equal("J250", SoundEx.Miracode.GenerateSoundEx("Jackson"));
            Assert.Equal("G362", SoundEx.Miracode.GenerateSoundEx("Gutierrez"));
            Assert.Equal("V532", SoundEx.Miracode.GenerateSoundEx("VanDeusen"));
            Assert.Equal("D250", SoundEx.Miracode.GenerateSoundEx("Deusen"));
        }

        [Fact]
        public void EmptyInputReturnsZeroLengthSoundEx()
        {
            Assert.Equal(string.Empty, SoundEx.Miracode.GenerateSoundEx(string.Empty));
        }
    }
}