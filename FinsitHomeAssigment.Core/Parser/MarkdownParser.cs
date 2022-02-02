using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    public class MarkdownParser : AbstractParser
    {
        private readonly TextLineParser _textLineParser;

        public MarkdownParser(TextLineParser textLineParser)
        {
            _textLineParser = textLineParser;
        }

        public Document Parse(IList<string> lines)
        {
            var document = new Document();
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

            return document;
        }
    }
}
