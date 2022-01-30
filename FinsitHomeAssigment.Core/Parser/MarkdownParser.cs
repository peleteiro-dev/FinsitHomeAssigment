using FinsitHomeAssigment.Core.Extension;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    public class MarkdownParser
    {
        public Document Document { get; private set; }

        private readonly Dictionary<DocumentType, IDocumentElementFactory> DocumentElementFactories = new Dictionary<DocumentType, IDocumentElementFactory>
            {
                { DocumentType.Paragraph, new ParagraphFactory() },
                { DocumentType.Section, new SectionFactory() },
                { DocumentType.SubSection, new SectionFactory() },
                { DocumentType.Text, new TextFactory() },
                { DocumentType.BoldText, new BoldTextFactory() }
            };

        public Document Parse(IList<string> lines)
        {
            Document = new Document();

            foreach (var line in lines)
            {
                var documentType = line.ToDocumentElementType();
                var factory = DocumentElementFactories[documentType];
                var documentElement = factory.Create(line);

                Document.AddToDocument(documentType, documentElement);
            }

            return Document;
        }
    }
}
