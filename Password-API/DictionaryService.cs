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
           
            GenerateCombinations(word.ToCharArray(), 0, new char [word.Length], substitutions, results);

            return  results;
        }

        private static void GenerateCombinations(char[] input, int index, char[] current, Dictionary<char, char[]> substitutions, List<string> results)
        {
            if (index == input.Length)
            {
                results.Add(new string(current));
                return;
            }

            char character = char.ToLower(input[index]);

            if (substitutions.ContainsKey(character))
            {
                foreach (char substitute in substitutions[character])
                {
                    current[index] = substitute;
                    GenerateCombinations(input, index + 1, current, substitutions, results);
                }
            }
            else
            {
                current[index] = char.ToLower(character);
                GenerateCombinations(input, index + 1, current, substitutions, results);

                current[index] = char.ToUpper(character);
                GenerateCombinations(input, index + 1, current, substitutions, results);
            }
        }
    }
}
