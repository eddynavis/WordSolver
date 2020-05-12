using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSolver
{
    class Combinations
    {
        private HashSet<string> wordCombinations;

        public Combinations(String letters)
        {
            wordCombinations = new HashSet<string>();
            generate(letters, "");
        }

        public HashSet<string> getWordCombinations()
        {
            return wordCombinations;
        }

        private void generate(string remainingLetters, string build)
        {
            for (int i = 0; i < remainingLetters.Length; i++)
            {
                string newCombo = build + remainingLetters.ElementAt(i);
                string newRemaining = remainingLetters.Substring(0, i);
                if (i < remainingLetters.Length - 1)
                {
                    newRemaining = newRemaining + remainingLetters.Substring(i + 1);
                }
                if (newCombo.Length > 2)
                {
                    wordCombinations.Add(newCombo);
                }
                if (newRemaining.Length > 0)
                {
                    generate(newRemaining, newCombo);
                }
            }
        }
    }
}
