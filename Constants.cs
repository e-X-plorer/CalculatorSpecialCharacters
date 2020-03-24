using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorSpecialCharacters
{
    static class Constants
    {
        private static Dictionary<string, double> specialStrings= new Dictionary<string, double>()
        {
            ["pi"] = 3.14159265,
            ["e"] = 2.71828183
        };

        private static List<Dictionary<string, double>> cache;

        private static void Init()
        {
            cache = new List<Dictionary<string, double>>();
            foreach (var entry in specialStrings)
            {
                int index = entry.Key.Length - 1;
                if (index < 0)
                {
                    Console.WriteLine("Empty string representing {0} found and skipped during initialization!", entry.Value);
                    continue;
                }
                if (cache[index] == null)
                {
                    cache.Capacity = index;
                }
                cache[index].Add(entry.Key, entry.Value);
            }
        }

        private static void SubstituteConstantsSinglePass(StringBuilder input, int pass)
        {
            foreach (var entry in cache[pass])
            {
                input.Replace(entry.Key, entry.Value.ToString());
            }
            
        }

        public static string SubstituteConstants(string input)
        {
            if (cache == null)
            {
                Init();
            }
            StringBuilder inputBuilder = new StringBuilder(input);
            for (int i = cache.Count - 1; i >= 0; i--)
            {
                SubstituteConstantsSinglePass(inputBuilder, i);
            }
            return inputBuilder.ToString();
        }
    }
}
