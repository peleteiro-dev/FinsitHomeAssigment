using System;
using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Parser;
using FinsitHomeAssigment.Core.Util;
using System.Collections.Generic;
using System.Linq;
using FinsitHomeAssigment.Core.Extension;

namespace FinsitHomeAssigment.Core
{
    public class MarkdownConverter
    {
        private static readonly MarkdownParser MarkdownParser = new MarkdownParser();
        private static readonly HtmlExporter HtmlExporter = new HtmlExporter();
        private static readonly MediawikiExporter MediawikiExporter = new MediawikiExporter();
        private static readonly MarkdownExporter MarkdownExporter = new MarkdownExporter();

        private static readonly IEnumerable<string> ValidExtensions = new List<string>
        {
            "md",
            "mkd",
            "mkdn",
            "mdwn",
            "mdown",
            "markdown"
        };

        public string FromFileToHtml(string filePath)
        {
            const bool addNewLine = false;
            
            return ExportFromFile(filePath, HtmlExporter, addNewLine);
        }

        public string FromFileToMediawiki(string filePath)
        {
            const bool addNewLine = true;

            return ExportFromFile(filePath, MediawikiExporter, addNewLine);
        }

        public string FromFileToMarkdown(string filePath)
        {
            const bool addNewLine = true;
         
            return ExportFromFile(filePath, MarkdownExporter, addNewLine);
        }

        public string FromStringToHtml(string markdownText)
        {
            const bool addNewLine = false;

            return ExportFromString(markdownText, HtmlExporter, addNewLine);
        }

        public string FromStringToMediawiki(string markdownText)
        {
            const bool addNewLine = true;

            return ExportFromString(markdownText, MediawikiExporter, addNewLine);
        }

        public string FromStringToMarkdown(string markdownText)
        {
            const bool addNewLine = true;

            return ExportFromString(markdownText, MarkdownExporter, addNewLine);
        }

        private static string ExportFromFile(string filePath, IDocumentExporter exporter, bool addNewLine)
        {
            FileUtils.ValidateFile(filePath, ValidExtensions);

            var buffer = FileUtils.ReadFileAsLines(filePath);
            if (addNewLine) buffer = buffer.AddNewLine();

            return Export(buffer, exporter);
        }

        private static string ExportFromString(string content, IDocumentExporter exporter, bool addNewLine)
        {
            IEnumerable<string> buffer = content?
                .Split(Environment.NewLine);

            if (addNewLine) buffer = buffer.AddNewLine();

            return Export(buffer, exporter);
        }

        private static string Export(IEnumerable<string> buffer, IDocumentExporter exporter)
        {
            var document = MarkdownParser.Parse(buffer);
            document.Accept(exporter);

            return document.ExportedContent;
        }
    }
}
