using System.Text;

namespace ThunderMain.SoundEx
{
    /// <summary>
    /// Oracle soundex implementation.
    /// http://docs.oracle.com/cd/B19306_01/server.102/b14200/functions148.htm
    /// </summary>
    /// <remarks>
    /// Oracle doesn't actually implement the 'h' and 'w' rule, despite what the
    /// documentation says.
    /// </remarks>
    internal class OracleSoundEx : SoundEx
    {
        public override string GenerateSoundEx(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            int startIndex;

            // Advanced to the first letter character.
            for (startIndex = 0; startIndex < s.Length && !char.IsLetter(s[startIndex]); startIndex++) {}

            if (startIndex >= s.Length) return string.Empty;

            var output = new StringBuilder();

            output.Append(char.ToUpperInvariant(s[startIndex]));

            // Stop at a maximum of 4 characters.
            for (int i = startIndex + 1; i < s.Length && output.Length < 4; i++)
            {
                string c = EncodeChar(s[i]);

                // Ignore duplicated chars.
                if (c != EncodeChar(s[i-1]))
                {
                    output.Append(c);
                }
            }

            // Pad with zeros.
            output.Append(new string('0', 4 - output.Length));

            return output.ToString();
        }
    }
}