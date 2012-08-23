using System.Text;

namespace ThunderMain.SoundEx
{
    /// <summary>
    /// Simplified SoundEx is described in Knuth vol3 Edition 1
    /// This is different to the algorithm described in Knuth vol3 Edition 2
    /// 
    /// It was used for the 1880 and 1900 census
    /// </summary>
    public class SimplifiedSoundEx : SoundExBase
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

                    // Ignore duplicated chars
                    if (c != EncodeChar(s[i - 1]))
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