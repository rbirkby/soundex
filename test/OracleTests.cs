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
        public void DuplicatedFirstCharactersAreEncoded()
        {
            Assert.Equal("L430", SoundEx.Oracle.GenerateSoundEx("Lloyd"));
        }

        [Fact]
        public void DuplicatedCharactersAreIgnored()
        {
            Assert.Equal("A130", SoundEx.Oracle.GenerateSoundEx("Abbot"));
        }

        [Fact]
        public void DuplicatedCharactersSeparatedByHOrWAreIgnored()
        {
            Assert.Equal("X400", SoundEx.Oracle.GenerateSoundEx("XLHL"));
            Assert.Equal("X400", SoundEx.Oracle.GenerateSoundEx("XLWL"));
            Assert.Equal("X400", SoundEx.Oracle.GenerateSoundEx("XLWWWWWHHHHL"));
            Assert.Equal("H400", SoundEx.Oracle.GenerateSoundEx("HLHL"));
        }

        [Fact]
        public void EmptyInputReturnsZeroLengthSoundEx()
        {
            Assert.Equal(string.Empty, SoundEx.SqlServer.GenerateSoundEx(string.Empty));
        }
    }
}