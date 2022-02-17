using FinsitHomeAssigment.Core.Model;
using System;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class MarkdownExporter : IDocumentExporter
    {
        private readonly IDocumentTags _tags = new MarkdownTags();
        private string _exportedContent;

        public IDocumentTags GetTags() => _tags;
        public string GetExportedContent() => _exportedContent;

        public void Export(Document document)
        {
            _exportedContent = _tags.OpeningDocument();
            ExportChildrenContent(document);
            _exportedContent += _tags.ClosingDocument();
        }

        private void ExportChildrenContent(DocumentElement parent)
        {
            foreach (var documentElement in parent.DocumentElements)
            {
                Export(documentElement);
            }
        }

        private void Export(DocumentElement documentElement)
        {
            switch (documentElement)
            {
                case Section section:
                    Export(section);
                    break;
                case SubSection subSection:
                    Export(subSection);
                    break;
                case Paragraph paragraph:
                    Export(paragraph);
                    break;
                case Text text:
                    Export(text);
                    break;
                case BoldText boldText:
                    Export(boldText);
                    break;
            }
        }

        public void Export(Section section)
        {
            _exportedContent += _tags.OpeningSection();
            _exportedContent += section.Title;
            _exportedContent += Environment.NewLine;
            ExportChildrenContent(section);
            _exportedContent += _tags.ClosingSection();
        }

        public void Export(SubSection subSection)
        {
            _exportedContent += _tags.OpeningSubSection();
            _exportedContent += subSection.Title;
            _exportedContent += Environment.NewLine;
            ExportChildrenContent(subSection);
            _exportedContent += _tags.ClosingSubSection();
        }

        public void Export(Paragraph paragraph)
        {
            _exportedContent += _tags.OpeningParagraph();
            ExportChildrenContent(paragraph);
            _exportedContent += _tags.ClosingParagraph();
            _exportedContent += Environment.NewLine;
        }

        public void Export(Text text)
        {
            _exportedContent += $"{_tags.OpeningText()}{text.Content}{_tags.ClosingText()}";
        }

        public void Export(BoldText boldText)
        {
            _exportedContent += $"{_tags.OpeningBoldText()}{boldText.Content}{_tags.ClosingBoldText()}";
        }
    }
}
