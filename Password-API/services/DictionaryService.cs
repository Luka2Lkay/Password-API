using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_API.services
{
    public class DictionaryService
    {

        public List<string> GeneratePassword(string word)
        {

            Dictionary<char, char[]> substitutions = new Dictionary<char, char[]>
            {
                ['a'] = new[] { 'a', 'A', '@' },
                ['s'] = new[] { 's', 'S', '5' },
                ['o'] = new[] { 'o', 'O', '0' }
            };

            List<string> results = new List<string>();
            GenerateCombinations(string.Empty, word, substitutions, results);

            return  results;
        }

        private static void GenerateCombinations(string current, string remainingChars, Dictionary<char, char[]> substitutions, List<string> results)
        {
     
            if (string.IsNullOrEmpty(remainingChars))
            {
                results.Add(current);
                return;
            }

            char firstChar = remainingChars[0];
            string rest = remainingChars.Substring(1);

            if (substitutions.ContainsKey(firstChar))
            {
                foreach (char substitute in substitutions[firstChar])
                {
                    GenerateCombinations(current + substitute, rest, substitutions, results);
                }
            }
            else
            {
                GenerateCombinations(current + firstChar, rest, substitutions, results);
            }
        }

    }
}
