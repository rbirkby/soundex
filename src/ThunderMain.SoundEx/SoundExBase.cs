using System;

namespace ThunderMain.SoundEx
{
    /// <summary>
    /// Abstract base class for all SoundEx implementations
    /// Could also be used for other phonetic matching algorithms
    /// such as "Metaphone"/"Metaphon".
    /// </summary>
    public abstract class SoundExBase
    {
        public abstract string GenerateSoundEx(string s);

        /// <summary>
        /// Implements the Difference algorithm, as found in SQL Server
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>0-4 depending on the similarity of the two words</returns>
        public virtual int Difference(string s1, string s2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Marked as virtual so that concrete SoundExBase implementations can
        /// replace this and add extra characters for encoding.
        /// For example, the Online Dictionary of Computings specifies
        /// several extra characters in the lookup table.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual string EncodeChar(char c)
        {
            // C# will re-order this list and produce a look-up list from it
            // C# will do all the work we would otherwise do by building arrays of values
            switch (char.ToLowerInvariant(c))
            {
                case 'b':
                case 'f':
                case 'p':
                case 'v':
                    return "1";
                case 'c':
                case 'g':
                case 'j':
                case 'k':
                case 'q':
                case 's':
                case 'x':
                case 'z':
                    return "2";
                case 'd':
                case 't':
                    return "3";
                case 'l':
                    return "4";
                case 'm':
                case 'n':
                    return "5";
                case 'r':
                    return "6";
                default:
                    return string.Empty;
            }
        }
    }
}