using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Extension;
using FinsitHomeAssigment.Core.Parser;
using FinsitHomeAssigment.Core.Util;
using System;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core
{

    /// <summary>
    /// Facade of the library, converts a markdown file or set of lines, into a:
    /// - Html string
    /// - Mediawiki string
    /// - Markdown string
    /// 
    /// with the help of:
    /// - MarkdownParser
    /// - HtmlExporter
    /// - MediawikiExporter
    /// - MarkdownExporter
    /// </summary>
    public class MarkdownConverter
    {
        private static readonly MarkdownParser MarkdownParser = new MarkdownParser();
        private static readonly HtmlExporter HtmlExporter = new HtmlExporter();
        private static readonly MediawikiExporter MediawikiExporter = new MediawikiExporter();
        private static readonly MarkdownExporter MarkdownExporter = new MarkdownExporter();
        private const bool AddNewLine = true;
        private const bool DoNotAddNewLine = false;

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
            return ExportFromFile(filePath, HtmlExporter, DoNotAddNewLine);
        }

        public string FromFileToMediawiki(string filePath)
        {
            return ExportFromFile(filePath, MediawikiExporter, AddNewLine);
        }

        public string FromFileToMarkdown(string filePath)
        {
            return ExportFromFile(filePath, MarkdownExporter, AddNewLine);
        }

        public string FromStringToHtml(string markdownText)
        {
            return ExportFromString(markdownText, HtmlExporter, DoNotAddNewLine);
        }

        public string FromStringToMediawiki(string markdownText)
        {
            return ExportFromString(markdownText, MediawikiExporter, AddNewLine);
        }

        public string FromStringToMarkdown(string markdownText)
        {
            return ExportFromString(markdownText, MarkdownExporter, AddNewLine);
        }

        private static string ExportFromFile(string filePath, IDocumentExporter exporter, bool addNewLine)
        {
            try
            {
                var validationResult = FileUtils.ValidateFile(filePath, ValidExtensions);
                if (!string.IsNullOrEmpty(validationResult)) return validationResult;

                var buffer = FileUtils.ReadFileAsLines(filePath);
                if (addNewLine) buffer = buffer.AddNewLine();

                return Export(buffer, exporter);
            }
            catch (Exception e)
            {
                return $"Unexpected exception. Please contact with Martin and provide with this information. Message: {e.Message}.";
            }
        }

        private static string ExportFromString(string content, IDocumentExporter exporter, bool addNewLine)
        {
            try
            {
                IEnumerable<string> buffer = content?
                    .Split(Environment.NewLine);

                if (addNewLine) buffer = buffer.AddNewLine();

                return Export(buffer, exporter);
            }
            catch (Exception e)
            {
                return $"Unexpected exception. Please contact with Martin and provide with this information. Message: {e.Message}.";
            }
        }

        private static string Export(IEnumerable<string> buffer, IDocumentExporter exporter)
        {
            var document = MarkdownParser.Parse(buffer);
            document.Accept(exporter);

            return RemoveTrailingNewLines(exporter.GetExportedContent());
        }

        private static string RemoveTrailingNewLines(string content)
        {
            var found = content.EndsWith(Environment.NewLine);
            while (found)
            {
                var index = content.LastIndexOf(Environment.NewLine, StringComparison.Ordinal);
                content = content.Substring(0, index);
                
                found = content.EndsWith(Environment.NewLine);
            }

            return content;
        }
    }
}
