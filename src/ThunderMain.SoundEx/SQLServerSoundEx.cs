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
    public class SqlServerSoundEx : SoundExBase
    {
        public override string GenerateSoundEx(string s)
        {
            var output = new StringBuilder();

            if (s.Length > 0)
            {
                output.Append(char.ToUpperInvariant(s[0]));

                // Stop at a maximum of 4 characters
                for (int i = 1; i < s.Length && output.Length < 4; i++)
                {
                    string c = EncodeChar(s[i]);

                    // Ignore duplicated chars, except a duplication with the first char
                    if (i == 1)
                    {
                        output.Append(c);
                    }
                    else if (c != EncodeChar(s[i - 1]))
                    {
                        output.Append(c);
                    }
                }

                // Pad with zeros
                output.Append(new string('0', 4 - output.Length));
            }

            return output.ToString();
        }
    }
}