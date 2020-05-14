using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WordSolver
{
    class Words
    {
        private HashSet<string> words;

        public Words()
        {
            words = new HashSet<string>();
            parseWords();
        }

        /// <summary>
        /// Checks if the word is in the word list.
        /// </summary>
        /// <param name="word">Word to check.</param>
        /// <returns>True if the word is in the list, False otherwise.</returns>
        public bool contains(String word) => words.Contains(word);

        /// <summary>
        /// Gets a reference to the list of words.
        /// </summary>
        /// <returns>The list of words.</returns>
        public HashSet<string> getWordList() => words;

        /// <summary>
        /// Parses the word list txt file into a data structure.
        /// </summary>
        private void parseWords()
        {
            //Get the resource txt file and turn it into a HashSet
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(Words)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("WordSolver.words_alpha.txt");
            StreamReader reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                //Don't care about words that are less than 3 letters
                if (line.Length > 2)
                {
                    words.Add(line);
                }
            }
        }
    }
}
