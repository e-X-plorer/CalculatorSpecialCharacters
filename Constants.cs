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

        private static SortedDictionary<string, double> cache;

        private static void Init()
        {
            cache = new SortedDictionary<string, double>(specialStrings,
                Comparer<string>.Create((string lhs, string rhs) => lhs.CompareTo(rhs)));
        }

        private static void SubstituteConstantsSinglePass(StringBuilder input, int pass)
        {
            foreach (var entry in cache)
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
            for (int i = 0; i < cache.Count; i++)
            {
                SubstituteConstantsSinglePass(inputBuilder, i);
            }
            return inputBuilder.ToString();
        }
    }
}
