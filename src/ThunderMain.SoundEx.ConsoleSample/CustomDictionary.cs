using System.Collections.Generic;
using System.Collections.Specialized;

namespace ThunderMain.SoundEx.ConsoleSample
{
    internal class CustomDictionary : SoundExDictionary
    {
        // Contains a unique list of all SoundEx values.
        // Each entry contains a collection of words which have that 
        // SoundEx value
        private readonly Dictionary<string, List<string>> _allSoundEx = new Dictionary<string, List<string>>();

        // Contains a name-value, where the name is the name of the string and
        // the value is the value of the soundex. This allows us to 
        // quickly look up the SoundEx value of a particular word.
        // The names are sorted to allow efficient lookup
        private readonly StringDictionary _allWords = new StringDictionary();

        private readonly SoundEx _soundExStrategy;

        public CustomDictionary(SoundEx soundEx)
        {
            _soundExStrategy = soundEx;
        }

        public override string GenerateSoundEx(string s)
        {
            return _soundExStrategy.GenerateSoundEx(s);
        }

        public void AddWord(string s)
        {
            if (_allWords.ContainsKey(s) == false)
            {
                string soundEx = _soundExStrategy.GenerateSoundEx(s);

                // Add the word to the list of all words and associate
                // a SoundEx value with it
                _allWords.Add(s, soundEx);

                // Create a new SoundEx group
                if (_allSoundEx.ContainsKey(soundEx) == false)
                {
                    _allSoundEx.Add(soundEx, new List<string>());
                }

                // Now add the string into the collection of all strings
                // with the same SoundEx
                _allSoundEx[soundEx].Add(s);
            }
        }

        public int SoundExGroups
        {
            get { return _allSoundEx.Count; }
        }

        public int WordCount
        {
            get { return _allWords.Count; }
        }

        public override ICollection<string> Search(string word)
        {
            string soundEx = _allWords[word];

            if (soundEx == null)
            {
                // Return the empty collection singleton
                return new string[0];
            }

            return _allSoundEx[soundEx];
        }
    }
}