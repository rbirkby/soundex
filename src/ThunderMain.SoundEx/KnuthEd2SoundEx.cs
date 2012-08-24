using System.Text;

namespace ThunderMain.SoundEx
{
    /// <summary>
    /// This SoundEx is described in Knuth TAOCP Vol3 Edition 2, pg 394-395
    /// </summary>
    internal class KnuthEd2SoundEx : SoundEx
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

                    // We either append or ignore, determined by the preceding char
                    switch (char.ToLowerInvariant(s[i - 1]))
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            // Chars separated by a vowel - OK to encode
                            output.Append(c);
                            break;
                        case 'h':
                        case 'w':
                        default:
                            // Ignore duplicated phonetic sounds
                            if (output.Length == 1)
                            {
                                // We only have the first character, which is never
                                // encoded. However, we need to check whether it is
                                // the same phonetically as the next char
                                if (EncodeChar(output[output.Length - 1]) != c)
                                    output.Append(c);
                            }
                            else
                            {
                                if (output[output.Length - 1].ToString() != c)
                                    output.Append(c);
                            }

                            break;
                    }
                }

                // Pad with zeros
                output.Append(new string('0', 4 - output.Length));
            }

            return output.ToString();
        }
    }
}