using Xunit;

namespace ThunderMain.SoundEx.Test
{
    /// <summary>
    /// Tests for the Oracle soundex variant.
    /// </summary>
    public class OracleTests
    {
        [Fact]
        public void TestOracle()
        {
            Assert.Equal("A500", SoundEx.Oracle.GenerateSoundEx("Ann"));
            Assert.Equal("A500", SoundEx.Oracle.GenerateSoundEx("Anne"));
            Assert.Equal("A520", SoundEx.Oracle.GenerateSoundEx("Ansie"));
        }

        [Fact]
        public void DuplicatedFirstCharacterIsEncoded()
        {
            Assert.Equal("L300", SoundEx.Oracle.GenerateSoundEx("Lloyd"));
        }

        [Fact]
        public void DuplicatedCharactersAreIgnored()
        {
            Assert.Equal("A130", SoundEx.Oracle.GenerateSoundEx("Abbot"));
        }

        [Fact]
        public void DuplicatedCharactersSeparatedByHOrWAreIncluded()
        {
            Assert.Equal("X440", SoundEx.Oracle.GenerateSoundEx("XLHL"));
            Assert.Equal("X440", SoundEx.Oracle.GenerateSoundEx("XLWL"));
            Assert.Equal("X440", SoundEx.Oracle.GenerateSoundEx("XLWWWWWHHHHL"));
            Assert.Equal("H440", SoundEx.Oracle.GenerateSoundEx("HLHL"));
        }

        [Fact]
        public void ShortSoundExIsPadded()
        {
            Assert.Equal("S000", SoundEx.Oracle.GenerateSoundEx("S"));
        }

        [Fact]
        public void NonLetterCharactersAreIgnored()
        {
            Assert.Equal("S130", SoundEx.Oracle.GenerateSoundEx("S=BT"));
            Assert.Equal("S320", SoundEx.Oracle.GenerateSoundEx("=STS"));
            Assert.Equal(string.Empty, SoundEx.Oracle.GenerateSoundEx("1234"));
            Assert.Equal("S000", SoundEx.Oracle.GenerateSoundEx("S1234"));
        }

        [Fact]
        public void EmptyInputReturnsZeroLengthSoundEx()
        {
            Assert.Equal(string.Empty, SoundEx.Oracle.GenerateSoundEx(string.Empty));
        }
    }
}