using System;
using System.IO;
using System.IO.Compression;

namespace ThunderMain.SoundEx.ConsoleSample
{
    static class Program
    {
        static void Main()
        {
            SoundExDictionary util;
            const string dictionary = "words.zip";

            Console.WriteLine("Enter SoundEx Type (M=Miracode, S=Simplified, K=Knuth TAOCP Edition2, T=SQL Server):");
            
            using(Stream stream = new GZipStream(File.OpenRead(dictionary), CompressionMode.Decompress))
            {
                switch (Console.ReadLine().ToUpperInvariant())
                {
                    case "M":
                        util = SoundExDictionary.CreateCustomDictionary(stream, SoundExEnum.Miracode);
                        break;
                    case "S":
                        util = SoundExDictionary.CreateCustomDictionary(stream, SoundExEnum.Simplified);
                        break;
                    case "K":
                        util = SoundExDictionary.CreateCustomDictionary(stream, SoundExEnum.KnuthEd2);
                        break;
                    case "T":
                        util = SoundExDictionary.CreateCustomDictionary(stream, SoundExEnum.SqlServer);
                        break;
                    default:
                        Console.WriteLine("Unknown type");
                        return;
                }
            }

            while (true)
            {
                Console.Write("Enter a word to find similar words:");
                string input = Console.ReadLine();

                Console.WriteLine("---------------- {0} ({1}) -------------------- ", input, util.GenerateSoundEx(input));
                
                foreach (string s in util.Search(input))
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}