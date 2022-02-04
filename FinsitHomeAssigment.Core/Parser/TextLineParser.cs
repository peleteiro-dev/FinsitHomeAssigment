using FinsitHomeAssigment.Core.Extension;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;
using System.Linq;
using FinsitHomeAssigment.Core.Factory;

namespace FinsitHomeAssigment.Core.Parser
{
    public class TextLineParser : AbstractParser
    {
        public TextLineParser()
        {
            AddFactory(new BoldTextFactory());
            AddFactory(new TextFactory());
        }

        public IList<DocumentElement> Parse(string line)
        {
            var documentElements = new List<DocumentElement>();
            if (string.IsNullOrEmpty(line)) return documentElements;

            var delimiters = GetDelimiters();
            var textItems = line.ToListOfTextItems(delimiters);
            var converted = ConvertTextItems(textItems );
            documentElements.AddRange(converted);

            return documentElements;
        }

        private IList<string> GetDelimiters()
        {
            return GetFactories()
                .Select(f => f.Delimiter)
                .Where(d => !string.IsNullOrEmpty(d))
                .ToList();
        }

        private IEnumerable<DocumentElement> ConvertTextItems(IList<string> textItems)
        {
            var documentElements = new List<DocumentElement>();
            foreach (var textItem in textItems)
            {
                var documentElement = CreateDocumentElement(textItem);
                if (documentElement == null) continue;

                documentElements.Add(documentElement);
            }

            return documentElements;
        }
    }
}
