using System;
using System.Collections.Generic;
using System.Linq;

namespace GreetingKata
{
    public static class Greeting
    {
        public static string Greet(params string [] names)
        {
            if (!names.Any() || names.All(string.IsNullOrEmpty))
                return "Hello, my friend";

            var tempNameList = GetNewNameList(names);

            names = tempNameList.ToArray();
            var capitalizedNames = names.Where(a => a.All(char.IsUpper)).ToList();
            var lowerNames = names.Where(a => !a.All(char.IsUpper)).ToList();
            var value = string.Join(", ", lowerNames.Take(lowerNames.Count - 1));
            
            value = names.Length > 1 
                ? GetMultipleNamesValue(value, lowerNames, capitalizedNames) 
                : $"{names.Last()}";
            
            return capitalizedNames.Any() && !lowerNames.Any()
                ? $"HELLO {value}!" 
                : $"Hello, {value}";
        }

        private static string GetMultipleNamesValue(string value, IEnumerable<string> lowerNames, IEnumerable<string> capitalizedNames)
        {
            value = string.IsNullOrEmpty(value) 
                ? $"{lowerNames.Last()}."
                : $"{value} and {lowerNames.Last()}."; 
            
            var jCapitalized = string.Join(" AND ", capitalizedNames);
            value = $"{value}{(jCapitalized.Any() ? $" AND HELLO {jCapitalized}!" : "")}";
            
            return value;
        }

        private static List<string> GetNewNameList(IEnumerable<string> names)
        {
            var tempNameList = new List<string>();
            foreach (var name in names)
            {
                if (name.StartsWith('"') && name.EndsWith('"'))
                {
                    tempNameList.Add(name.Replace("\"", ""));
                    continue;
                }
                var split = name.Split(",", StringSplitOptions.RemoveEmptyEntries);
                tempNameList.AddRange(split);
            }

            return tempNameList;
        }
    }
}