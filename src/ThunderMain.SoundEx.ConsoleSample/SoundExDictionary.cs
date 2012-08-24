using System;
using System.Collections.Generic;
using System.IO;

namespace ThunderMain.SoundEx.ConsoleSample
{
    public abstract class SoundExDictionary
    {
        /// <summary>
        /// Factory method for creating a SoundEx dictonary using any of the
        /// SoundEx implementations available
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="soundex">The type of soundex algorithm.</param>
        /// <returns></returns>
        public static SoundExDictionary CreateCustomDictionary(Stream stream, SoundEx soundex)
        {
            var custom = new CustomDictionary(soundex);
            var reader = new StreamReader(stream);

            Console.Write("Loading");

            string line = reader.ReadLine();

            do
            {
                if (custom.WordCount % 1000 == 0)
                    Console.Write(".");

                custom.AddWord(line);
                line = reader.ReadLine();
            } 
            while (line != null);

            Console.WriteLine();

            Console.WriteLine("Number of words loaded: " + custom.WordCount);
            Console.WriteLine("Number of unique SoundEx values: " + custom.SoundExGroups);

            return custom;
        }

        /// <summary>
        /// TODO: A soundex with statically compiled data
        /// </summary>
        /// <returns></returns>
        public static SoundExDictionary CreateStaticDictionary()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search for words similar to the given word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>A list of all similar words, including the word itself, if found</returns>
        public abstract ICollection<string> Search(string word);

        /// <summary>
        /// Generates a SoundEx value for the given string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public abstract string GenerateSoundEx(string s);
    }
}