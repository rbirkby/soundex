using Xunit;

namespace ThunderMain.SoundEx.Test
{
    public class SimplifiedTests
    {
        [Fact]
        public void TestSimplified()
        {
            // Validate the SoundEx agorithm
            // using Knuth TAOCP volume 3
            Assert.Equal("E460", SoundEx.Simplified.GenerateSoundEx("Euler"));
            Assert.Equal("E460", SoundEx.Simplified.GenerateSoundEx("Ellery"));
            Assert.Equal("G200", SoundEx.Simplified.GenerateSoundEx("Gauss"));
            Assert.Equal("G200", SoundEx.Simplified.GenerateSoundEx("Ghosh"));
            Assert.Equal("H416", SoundEx.Simplified.GenerateSoundEx("Hilbert"));
            Assert.Equal("H416", SoundEx.Simplified.GenerateSoundEx("Heilbronn"));
            Assert.Equal("K530", SoundEx.Simplified.GenerateSoundEx("Knuth"));
            Assert.Equal("K530", SoundEx.Simplified.GenerateSoundEx("Kant"));
            Assert.Equal("L300", SoundEx.Simplified.GenerateSoundEx("Lloyd"));
            Assert.Equal("L300", SoundEx.Simplified.GenerateSoundEx("Ladd"));
            Assert.Equal("L222", SoundEx.Simplified.GenerateSoundEx("Lukasiewicz"));
            Assert.Equal("L222", SoundEx.Simplified.GenerateSoundEx("Lissajous"));
        }

        [Fact]
        public void EmptyInputReturnsZeroLengthSoundEx()
        {
            Assert.Equal(string.Empty, SoundEx.Simplified.GenerateSoundEx(string.Empty));
        }
    }
}