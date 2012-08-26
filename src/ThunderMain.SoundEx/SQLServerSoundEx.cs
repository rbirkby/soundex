using System.Text;

namespace ThunderMain.SoundEx
{
    /// <summary>
    /// SQL Server only ignores adjacent duplicated phonetic sounds
    /// Plus, it doesn't ignore a character if it is duplicated with the leading char
    /// 
    /// For example, SQL Server will encode "PPPP" as "P100", whereas Miracode will
    /// encode it as "P000".
    /// </summary>
    /// <remarks>
    /// This algorithm implements SQL Server 2010 and below. SQL Server 2012
    /// has a slightly different algorithm:
    /// http://msdn.microsoft.com/en-us/library/ms187384.aspx
    /// </remarks>
    internal class SqlServerSoundEx : SoundEx
    {
        public override string GenerateSoundEx(string s)
        {
            if (s == null) return null;
            if (s.Length == 0 || !char.IsLetter(s[0])) return "0000";

            var output = new StringBuilder();

            output.Append(char.ToUpperInvariant(s[0]));

            // Stop at a maximum of 4 characters
            for (int i = 1; i < s.Length && output.Length < 4 && char.IsLetter(s[i]); i++)
            {
                string c = EncodeChar(s[i]);

                // Ignore duplicated chars, except a duplication with the first char
                if (i == 1 || c != EncodeChar(s[i - 1]))
                {
                    output.Append(c);
                }
            }

            // Pad with zeros
            output.Append(new string('0', 4 - output.Length));

            return output.ToString();
        }
    }
}