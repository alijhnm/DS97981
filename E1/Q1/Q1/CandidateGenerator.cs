using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public static class CandidateGenerator
    {
        public static readonly char[] Alphabet =
            Enumerable.Range('a', 'z' - 'a' + 1)
                      .Select(c => (char)c)
                      .ToArray();

        public static string[] GetCandidates(string word)
        {
            List<string> candidates = new List<string>();
            //Insert
            for (int i = 0; i <= word.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    candidates.Add(Insert(word, i, Alphabet[j]));
                }
            }

            //Delete
            for (int i = 0; i < word.Length; i++)
            {
                candidates.Add(Delete(word, i));
            }

            //Substitute
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    candidates.Add(Substitute(word, i, Alphabet[j]));
                }
            }

            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length+1];
            int counter = 0;
            for (int i = 0; i < newWord.Length; i++)
            {
                if (i == pos)
                {
                    newWord[i] = c;
                    counter++;
                }
                else
                {
                    newWord[i] = wordChars[i - counter];
                }
            }
            return new string(newWord);
        }

        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length-1];
            int counter = 0;
            for (int i = 0; i < wordChars.Length; i++)
            {
                if (i == pos)
                {
                    counter++;
                    continue;
                }
                else
                {
                    newWord[i - counter] = wordChars[i];
                }
            }
            return new string(newWord);
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length];

            for (int i = 0; i < newWord.Length; i++)
            {
                if (i == pos)
                {
                    newWord[i] = c;
                }
                else
                {
                    newWord[i] = wordChars[i];
                } 
            }
            return new string(newWord);
        }

    }
}
