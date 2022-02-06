using FinsitHomeAssigment.Core.Builder;
using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    public class MarkdownParser : AbstractParser
    {
        private readonly TextLineParser _textLineParser = new TextLineParser();

        public MarkdownParser()
        {
            AddFactory(new SectionFactory());
            AddFactory(new SubSectionFactory());
            AddFactory(new ParagraphFactory());
        }

        public Document Parse(IEnumerable<string> lines)
        {
            var document = new DocumentBuilder();
            foreach (var line in lines)
            {
                var documentElement = CreateDocumentElement(line);
                if (documentElement != null)
                {
                    document.AddToDocument(documentElement);
                    continue;
                }

                var textItems = _textLineParser.Parse(line);
                document.AddToDocument(textItems);
            }

            return document.GetDocument();
        }
    }
}
