using System;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;
using FinsitHomeAssigment.Core.Builder;
using FinsitHomeAssigment.Core.Factory;

namespace FinsitHomeAssigment.Core.Parser
{
    public class MarkdownParser : AbstractParser
    {
        private readonly TextLineParser _textLineParser;

        public MarkdownParser(TextLineParser textLineParser)
        {
            _textLineParser = textLineParser ?? throw new ArgumentNullException(nameof(textLineParser));

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
