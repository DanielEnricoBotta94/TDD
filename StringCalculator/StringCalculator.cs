using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static StringCalculator CreateInstance()
        {
            return new StringCalculator();
        }
        
        private readonly List<string> _separators = new List<string>{",", "\n"};
        private List<string> _customSeparators;
        
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith("//"))
                input = Input(input);

            var inputList = InputList(input);

            if(inputList.Any(a => a < 0))
                throw new Exception(string.Join(",", inputList));

            return inputList.Sum();
        }

        private List<int> InputList(string input)
        {
            var allSeparators = _separators;
            if (_customSeparators != null)
                allSeparators.AddRange(_customSeparators);

            var inputList = input
                .Split(allSeparators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(w => w <= 1000)
                .ToList();
            return inputList;
        }

        private string Input(string input)
        {
            input = input.Replace("//", "");

            var matches = Regex.Matches(input, @"\[(.*?)\]", RegexOptions.Multiline);

            if (matches.Count > 0)
            {
                _customSeparators = new List<string>();
                matches.ToList().ForEach(f => _customSeparators.Add(f.Groups[1].Value));
                //3 is -> Skip these characters -> '[', ']', \n'
                input = input.Substring(_customSeparators.Sum(s => s.Length + 2) + 1);
            }
            else
            {
                _separators.Add(input.Substring(0, 1));
            }

            return input;
        }
    }
}