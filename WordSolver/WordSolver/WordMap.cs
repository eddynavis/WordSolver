using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WordSolverTest
{
    /// <summary>
    /// Breaks down the given letters into a map to determine if a given word is a match.
    /// Trying to improve the algorithm for longer words
    /// </summary>
    class WordMap
    {
        int length;
        Dictionary<char, int> letterMap;
        /// <summary>
        /// Creates a map of the given letters so they can be compared and matched.
        /// </summary>
        /// <param name="letters">Letters to match words against.</param>
        public WordMap(string letters)
        {
            length = letters.Length;
            letterMap = new Dictionary<char, int>();

            //Put each letter in a Dictionary with the number of occurances as the value
            foreach (char letter in letters)
            {
                int value = 0;
                letterMap.TryGetValue(letter, out value);
                letterMap[letter] = value + 1;
            }
        }

        /// <summary>
        /// Checks if the supplied word can be made up of the given letters.
        /// </summary>
        /// <param name="word">Word to check if it's a match.</param>
        /// <returns>If the word is a match.</returns>
        public bool isMatch(string word)
        {
            //Get rid of long words
            if (word.Length > length)
            {
                return false;
            }
            //Cut out words with extra letters
            foreach (char letter in word)
            {
                if (!letterMap.ContainsKey(letter))
                {
                    return false;
                }
            }
            //Verify duplicate letters don't disqualify the match
            if (!checkDuplicates(word))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Helper method for verifying the counts of each letter are less then or equal.
        /// </summary>
        /// <param name="word">Word that we are checking against the map.</param>
        /// <returns>True if it's a match. False if the count of one of the letters is too high in the word.</returns>
        private bool checkDuplicates(string word)
        {
            //Go by each letter in the map
            foreach (var pair in letterMap)
            {
                //Count occurances of the letter
                int count = 0;
                foreach (char letter in word)
                {
                    if (letter == pair.Key)
                    {
                        count++;
                    }
                }
                //If there are too many occurances of the letter it's not a match
                if (count > pair.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
