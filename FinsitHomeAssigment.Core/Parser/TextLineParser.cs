﻿using FinsitHomeAssigment.Core.Extension;
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
            Factories.Add(new BoldTextFactory());
            Factories.Add(new TextFactory());
        }

        public IList<DocumentElement> Parse(string line)
        {
            var documentElements = new List<DocumentElement>();
            if (string.IsNullOrEmpty(line)) return documentElements;

            var delimiters = GetDelimiters();
            var textItems = line.ToListOfTextItems(delimiters);
            ConvertTextItemsAndAddToDocumentElements(textItems, documentElements);

            return documentElements;
        }

        private IList<string> GetDelimiters()
        {
            return Factories
                .Select(f => f.Delimiter)
                .Where(d => !string.IsNullOrEmpty(d))
                .ToList();
        }

        private void ConvertTextItemsAndAddToDocumentElements(IList<string> textItems, IList<DocumentElement> documentElements)
        {
            foreach (var textItem in textItems)
            {
                var documentElement = CreateDocumentElement(textItem);
                if (documentElement == null) continue;

                documentElements.Add(documentElement);
            }
        }
    }
}
