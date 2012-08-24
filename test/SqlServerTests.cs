using Xunit;

namespace ThunderMain.SoundEx.Test
{
    public class SqlServerTests
    {
        [Fact]
        public void TestSqlServer()
        {
            // Validate the SoundEx agorithm
            Assert.Equal("T522", SoundEx.SqlServer.GenerateSoundEx("Tymczak"));
            Assert.Equal("A226", SoundEx.SqlServer.GenerateSoundEx("Ashcraft"));
            Assert.Equal("P123", SoundEx.SqlServer.GenerateSoundEx("Pfister"));
            Assert.Equal("J250", SoundEx.SqlServer.GenerateSoundEx("Jackson"));
            Assert.Equal("G362", SoundEx.SqlServer.GenerateSoundEx("Gutierrez"));
            Assert.Equal("V532", SoundEx.SqlServer.GenerateSoundEx("VanDeusen"));
            Assert.Equal("D250", SoundEx.SqlServer.GenerateSoundEx("Deusen"));
        }

        [Fact]
        public void EmptyInputReturnsZeroLengthSoundEx()
        {
            Assert.Equal(string.Empty, SoundEx.SqlServer.GenerateSoundEx(string.Empty));
        }
    }
}