using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WordSolver
{
    class Words
    {
        private HashSet<string> words;

        public Words()
        {
            words = new HashSet<string>();
            parseWords();
            Console.WriteLine(words.Count);
        }

        public bool contains(String word) => words.Contains(word);
        private void parseWords()
        {
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(Words)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("WordSolver.words_alpha.txt");
            StreamReader reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Length > 2 && line.Length < 10)
                {
                    words.Add(line);
                }
            }

            //Console.WriteLine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words_alpha.txt"));
            //string[] lines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words_alpha.txt"));
            //foreach (string line in lines)
            //{
            //    if (line.Length > 2 && line.Length < 10)
            //    {
            //        words.Add(line);
            //    }
            //}
        }
    }
}
