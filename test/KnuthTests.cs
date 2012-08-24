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
            Assert.Equal("E460", SoundEx.KnuthEd2.GenerateSoundEx("Euler"));
            Assert.Equal("E460", SoundEx.KnuthEd2.GenerateSoundEx("Ellery"));
            Assert.Equal("G200", SoundEx.KnuthEd2.GenerateSoundEx("Gauss"));
            Assert.Equal("G200", SoundEx.KnuthEd2.GenerateSoundEx("Ghosh"));
            Assert.Equal("H416", SoundEx.KnuthEd2.GenerateSoundEx("Hilbert"));
            Assert.Equal("H416", SoundEx.KnuthEd2.GenerateSoundEx("Heilbronn"));
            Assert.Equal("K530", SoundEx.KnuthEd2.GenerateSoundEx("Knuth"));
            Assert.Equal("K530", SoundEx.KnuthEd2.GenerateSoundEx("Kant"));
            Assert.Equal("L300", SoundEx.KnuthEd2.GenerateSoundEx("Lloyd"));
            Assert.Equal("L300", SoundEx.KnuthEd2.GenerateSoundEx("Ladd"));
            Assert.Equal("L222", SoundEx.KnuthEd2.GenerateSoundEx("Lukasiewicz"));
            Assert.Equal("L222", SoundEx.KnuthEd2.GenerateSoundEx("Lissajous"));
            // Added in second edition of TAOCP for the h-w grouping rule
            Assert.Equal("W200", SoundEx.KnuthEd2.GenerateSoundEx("Wachs"));
        }

        [Fact]
        public void EmptyInputReturnsZeroLengthSoundEx()
        {
            Assert.Equal(string.Empty, SoundEx.KnuthEd2.GenerateSoundEx(string.Empty));
        }
    }
}