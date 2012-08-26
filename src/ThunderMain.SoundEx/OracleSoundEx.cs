using System.Text;

namespace ThunderMain.SoundEx
{
    /// <summary>
    /// Oracle soundex implementation.
    /// </summary>
    internal class OracleSoundEx : SoundEx
    {
        public override string GenerateSoundEx(string s)
        {
            if (s.Length == 0)
            {
                return string.Empty;
            }

            var output = new StringBuilder();

            output.Append(char.ToUpperInvariant(s[0]));

            // Stop at a maximum of 4 characters.
            for (int i = 1; i < s.Length && output.Length < 4; i++)
            {
                string c = EncodeChar(s[i]);

                // Find the preceding character (ignoring h and w).
                char precedingChar = default(char);

                for (int j = i - 1; j > 0; j--)
                {
                    if (char.ToLowerInvariant(s[j]) != 'h' && 
                        char.ToLowerInvariant(s[j]) != 'w')
                    {
                        precedingChar = s[j];
                        break;
                    }
                }

                // Ignore duplicated chars, except a duplication with the first char.
                if (i == 1 || c != EncodeChar(precedingChar))
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