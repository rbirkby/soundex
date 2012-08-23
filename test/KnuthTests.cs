using Xunit;

namespace ThunderMain.SoundEx.Test
{
    public class KnuthTests
    {
        [Fact]
        public void TestKnuth()
        {
            // Validate the SoundEx agorithm
            // using Knuth TAOCP volume 3
            var soundex = new KnuthEd2SoundEx();

            Assert.Equal("E460", soundex.GenerateSoundEx("Euler"));
            Assert.Equal("E460", soundex.GenerateSoundEx("Ellery"));
            Assert.Equal("G200", soundex.GenerateSoundEx("Gauss"));
            Assert.Equal("G200", soundex.GenerateSoundEx("Ghosh"));
            Assert.Equal("H416", soundex.GenerateSoundEx("Hilbert"));
            Assert.Equal("H416", soundex.GenerateSoundEx("Heilbronn"));
            Assert.Equal("K530", soundex.GenerateSoundEx("Knuth"));
            Assert.Equal("K530", soundex.GenerateSoundEx("Kant"));
            Assert.Equal("L300", soundex.GenerateSoundEx("Lloyd"));
            Assert.Equal("L300", soundex.GenerateSoundEx("Ladd"));
            Assert.Equal("L222", soundex.GenerateSoundEx("Lukasiewicz"));
            Assert.Equal("L222", soundex.GenerateSoundEx("Lissajous"));
            // Added in second edition of TAOCP for the h-w grouping rule
            Assert.Equal("W200", soundex.GenerateSoundEx("Wachs"));
        }
    }
}