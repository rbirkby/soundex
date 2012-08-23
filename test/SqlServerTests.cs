using Xunit;

namespace ThunderMain.SoundEx.Test
{
    public class SqlServerTests
    {
        [Fact]
        public void TestSqlServer()
        {
            // Validate the SoundEx agorithm
            var soundex = new SqlServerSoundEx();

            Assert.Equal("T522", soundex.GenerateSoundEx("Tymczak"));
            Assert.Equal("A226", soundex.GenerateSoundEx("Ashcraft"));
            Assert.Equal("P123", soundex.GenerateSoundEx("Pfister"));
            Assert.Equal("J250", soundex.GenerateSoundEx("Jackson"));
            Assert.Equal("G362", soundex.GenerateSoundEx("Gutierrez"));
            Assert.Equal("V532", soundex.GenerateSoundEx("VanDeusen"));
            Assert.Equal("D250", soundex.GenerateSoundEx("Deusen"));
        }
    }
}