using FinsitHomeAssigment.Core.Extension;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    public class TextLineParser
    {
        private readonly Dictionary<DocumentType, IDocumentElementFactory> _documentElementFactories = new Dictionary<DocumentType, IDocumentElementFactory>
            {
                { DocumentType.Text, new TextFactory() },
                { DocumentType.BoldText, new BoldTextFactory() }
            };

        public List<DocumentElement> Parse(string line)
        {
            var documentElements = new List<DocumentElement>();
            var textItems = line.ToListOfTextItems();
            foreach (var textItem in textItems)
            {
                var documentType = textItem.ToDocumentElementType();
                var factory = _documentElementFactories[documentType];
                var documentElement = factory.Create(textItem);

                documentElements.Add(documentElement);
            }
            
            return documentElements;
        }
    }
}
