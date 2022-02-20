using FinsitHomeAssigment.Core.Builder;
using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    /// <summary>
    /// Implementation of AbstractParser to Parse a Markdown text
    /// into a Document class with the help of a DocumentBuilder and TextLineParser
    /// </summary>
    public class MarkdownParser : AbstractParser
    {
        private readonly TextLineParser _textLineParser = new TextLineParser();
        private DocumentBuilder _documentBuilder;

        public MarkdownParser()
        {
            AddFactory(new SectionFactory());
            AddFactory(new SubSectionFactory());
            AddFactory(new ParagraphFactory());
        }

        public Document Parse(IEnumerable<string> lines)
        {
            _documentBuilder = new DocumentBuilder();
            if (lines == null) return _documentBuilder.GetDocument();

            foreach (var line in lines)
            {
                var documentElement = CreateDocumentElement(line);
                if (documentElement != null)
                {
                    _documentBuilder.AddToDocument(documentElement);
                    continue;
                }

                var textItems = _textLineParser.Parse(line);
                _documentBuilder.AddToDocument(textItems);
            }

            return _documentBuilder.GetDocument();
        }
    }
}
