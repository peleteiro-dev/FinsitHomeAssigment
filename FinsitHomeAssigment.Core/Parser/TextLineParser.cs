using FinsitHomeAssigment.Core.Extension;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    public class TextLineParser : AbstractParser
    {
        public List<DocumentElement> Parse(string line)
        {
            var documentElements = new List<DocumentElement>();
            var textItems = line.ToListOfTextItems();
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
