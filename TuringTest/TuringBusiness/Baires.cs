using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Baires
    {
        public bool solution(string sequence)
        {
            bool result = false;
            bool cursorAtStartingChar = false;
            string lastChar = string.Empty;
            string nextChar = string.Empty;

            List<string> startingCharacters = new List<string>() { "(", "[", "{" };
            List<string> endingCharacters = new List<string>() { ")", "]", "}" };

            if (string.IsNullOrWhiteSpace(sequence) || sequence.Length <= 1)
            {
                return false;
            }

            foreach (char c in sequence.ToCharArray())
            {
                string _c = c.ToString();
                if (lastChar == String.Empty)
                {
                    lastChar = _c;
                    cursorAtStartingChar = true;
                }

                if (cursorAtStartingChar)
                {
                    result = startingCharacters.Contains(_c);

                    if (result)
                    {
                        if (_c == "(")
                        {
                            nextChar = ")";
                        }
                        else if (_c == "[")
                        {
                            nextChar = "]";
                        }
                        else if (_c == "{")
                        {
                            nextChar = "}";
                        }
                    }

                    cursorAtStartingChar = false;
                }
                else
                {
                    result = _c == nextChar;
                    if (result)
                    {
                        nextChar = string.Empty;
                    }

                    cursorAtStartingChar = true;
                }

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        int result(string a, string b)
        {
            int[] freq = new int[26];

            int l1 = a.Length;
            int[] freq2 = new int[26];

            int l2 = b.Length;

            for (int i = 0; i < l1; i++)
            {
                freq[a[i] - 'a'] += 1;
            }
            for (int i = 0; i < l2; i++)
            {
                freq2[b[i] - 'a'] += 1;
            }

            int count = int.MaxValue;
            
            for (int i = 0; i < l2; i++)
            {
                if (freq2[b[i] - 'a'] != 0)
                    count = Math.Min(
                        count, freq[b[i] - 'a']
                                   / freq2[b[i] - 'a']);
            }

            return count;
        }
    }
}
