using FinsitHomeAssigment.Core.Model;
using System.Linq;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Implementation of IDocumentElementFactory to be used by MarkdownParser
    /// in order to create Text DocumentElements
    /// </summary>
    public class TextFactory : IDocumentElementFactory
    {
        public string Delimiter => null;

        public DocumentElement Create(string line)
        {
            if (string.IsNullOrEmpty(line) || StartsWithAnyDelimiter(line))
            {
                return null;
            }

            return new Text(line);
        }

        // Text factory can not intercept lines that should be processed by other factories
        private static bool StartsWithAnyDelimiter(string line)
        {
            return Separator.List
                .Where(delimiter => delimiter != string.Empty)// exclude empty cos any non null string starts with empty
                .Any(delimiter => line.StartsWith(delimiter));
        }
    }
}
