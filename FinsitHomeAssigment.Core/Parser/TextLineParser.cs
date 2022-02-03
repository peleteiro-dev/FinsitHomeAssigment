using FinsitHomeAssigment.Core.Extension;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace FinsitHomeAssigment.Core.Parser
{
    public class TextLineParser : AbstractParser
    {
        public List<DocumentElement> Parse(string line)
        {
            var documentElements = new List<DocumentElement>();
            if (string.IsNullOrEmpty(line)) return documentElements;

            var delimiters = Factories
                .Select(f => f.Delimiter)
                .Where(d=>!string.IsNullOrEmpty(d))
                .ToList();
            var textItems = line.ToListOfTextItems(delimiters);
            foreach (var textItem in textItems)
            {
                var documentElement = CreateDocumentElement(textItem);
                if (documentElement != null)
                {
                    documentElements.Add(documentElement);
                }
            }

            return documentElements;
        }
    }
}
