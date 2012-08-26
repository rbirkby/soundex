using Xunit;

namespace ThunderMain.SoundEx.Test
{
    /// <summary>
    /// Tests for the SQL Server soundex variant.
    /// </summary>
    public class SqlServerTests
    {
        [Fact]
        public void TestSqlServer()
        {
            Assert.Equal("W252", SoundEx.SqlServer.GenerateSoundEx("Washington"));
            Assert.Equal("S530", SoundEx.SqlServer.GenerateSoundEx("Smith"));
            Assert.Equal("S530", SoundEx.SqlServer.GenerateSoundEx("Smythe"));
            Assert.Equal("T522", SoundEx.SqlServer.GenerateSoundEx("Tymczak"));
            Assert.Equal("A226", SoundEx.SqlServer.GenerateSoundEx("Ashcraft"));
            Assert.Equal("P123", SoundEx.SqlServer.GenerateSoundEx("Pfister"));
            Assert.Equal("J250", SoundEx.SqlServer.GenerateSoundEx("Jackson"));
            Assert.Equal("G362", SoundEx.SqlServer.GenerateSoundEx("Gutierrez"));
            Assert.Equal("V532", SoundEx.SqlServer.GenerateSoundEx("VanDeusen"));
            Assert.Equal("D250", SoundEx.SqlServer.GenerateSoundEx("Deusen"));
        }

        [Fact]
        public void EmptyInputReturnsAllZeroSoundEx()
        {
            Assert.Equal("0000", SoundEx.SqlServer.GenerateSoundEx(string.Empty));
        }

        [Fact]
        public void StopsProcessingAtNonLetterCharacter()
        {
            Assert.Equal("A000", SoundEx.SqlServer.GenerateSoundEx("A1bbot"));
            Assert.Equal("0000", SoundEx.SqlServer.GenerateSoundEx("1bbot"));
            Assert.Equal("A130", SoundEx.SqlServer.GenerateSoundEx("Abbøt"));
            Assert.Equal("A000", SoundEx.SqlServer.GenerateSoundEx("A bbot"));
            Assert.Equal("A000", SoundEx.SqlServer.GenerateSoundEx("A=bbot"));
        }

        [Fact]
        public void DuplicatedCharactersAreIgnored()
        {
            Assert.Equal("A130", SoundEx.SqlServer.GenerateSoundEx("Abbot"));
        }

        [Fact]
        public void DuplicatedCharactersSeparatedByHOrWAreIncluded()
        {
            Assert.Equal("X440", SoundEx.SqlServer.GenerateSoundEx("XLHL"));
            Assert.Equal("X440", SoundEx.SqlServer.GenerateSoundEx("XLWL"));
            Assert.Equal("X440", SoundEx.SqlServer.GenerateSoundEx("XLWWWWWHHHHL"));
            Assert.Equal("H440", SoundEx.SqlServer.GenerateSoundEx("HLHL"));
        }
    }
}