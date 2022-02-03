using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinsitHomeAssigment.Core.Extension
{
    public static class StringExtensions
    {
        public static List<string> ToListOfTextItems(this string line, IList<string> delimiters)
        {
            var textItems = new List<string>();
            if (string.IsNullOrEmpty(line)) return textItems;

            var parts = SplitLine(line, delimiters);
            for (var i = 0; i < parts.Count; i++)
            {
                if (delimiters.Contains(parts[i]))
                {
                    textItems.Add($"{parts[i]}{parts[i + 1]}");
                    i += 2; 
                    continue;
                };
                textItems.Add(parts[i]);
            }

            return textItems;
        }

        private static IList<string> SplitLine(string line, ICollection<string> delimiters)
        {
            var divided = new List<string>();
            if (delimiters.Count < 1)
            {
                divided.Add(line); 
                return divided;
            }

            var escapedDelimiters = delimiters.Select(Regex.Escape).ToArray();
            var delimitersString = string.Join("|", escapedDelimiters);
            var pattern = $"({delimitersString})";

            divided = Regex.Split(line, pattern).ToList();

            return divided;
        }
    }
}
