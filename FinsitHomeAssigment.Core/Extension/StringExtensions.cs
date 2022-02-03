using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinsitHomeAssigment.Core.Extension
{
    public static class StringExtensions
    {
        public static IList<string> ToListOfTextItems(this string line, IList<string> delimiters)
        {
            var textItems = new List<string>();
            if (string.IsNullOrEmpty(line)) return textItems;

            var splits = SplitLine(line, delimiters);
            textItems = ConvertSplitsToList(splits, delimiters);
            AddNewLineToLastItem(textItems);
            
            return textItems;
        }

        private static IList<string> SplitLine(string line, IList<string> delimiters)
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

        private static List<string> ConvertSplitsToList(IList<string> splits, IList<string> delimiters)
        {
            var textItems = new List<string>();
            for (var i = 0; i < splits.Count; i++)
            {
                if (delimiters.Contains(splits[i]))
                {
                    textItems.Add($"{splits[i]}{splits[i + 1]}");
                    i += 2;
                    continue;
                }

                if (!string.IsNullOrEmpty(splits[i]))
                    textItems.Add(splits[i]);
            }

            return textItems;
        }

        private static void AddNewLineToLastItem(IList<string> list)
        {
            const string newLine = "\n";
            var lastItem = list.Last();
            if (lastItem.Contains(newLine)) return;

            list[list.Count - 1] = lastItem + newLine;
        }
    }
}
