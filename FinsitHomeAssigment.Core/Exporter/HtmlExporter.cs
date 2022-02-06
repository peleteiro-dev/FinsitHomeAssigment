using FinsitHomeAssigment.Core.Model;
using System.Linq;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class HtmlExporter : IDocumentExporter
    {
        private readonly IDocumentTags _tags = new HtmlTags();

        public IDocumentTags GetTags() => _tags;

        public void Export(Document document)
        {
            var exportedContent = _tags.OpeningDocument();
            exportedContent += GetChildrenContent(document);
            exportedContent += _tags.ClosingDocument();

            document.ExportedContent = exportedContent;
        }

        public void Export(Section section)
        {
            var exportedContent = _tags.OpeningSection();
            exportedContent += section.Title;
            exportedContent += GetChildrenContent(section);
            exportedContent += _tags.ClosingSection();

            section.ExportedContent = exportedContent;
        }

        public void Export(SubSection subSection)
        {
            var exportedContent = _tags.OpeningSubSection();
            exportedContent += subSection.Title;
            exportedContent += GetChildrenContent(subSection);
            exportedContent += _tags.ClosingSubSection();

            subSection.ExportedContent = exportedContent;
        }

        public void Export(Paragraph paragraph)
        {
            var exportedContent = _tags.OpeningParagraph();
            exportedContent += GetChildrenContent(paragraph);
            exportedContent += _tags.ClosingParagraph();

            paragraph.ExportedContent = exportedContent;
        }

        private static string GetChildrenContent(DocumentElement parent)
        {
            var childrenContent = string.Empty;
            childrenContent = parent.DocumentElements.Aggregate(childrenContent,
                            (current, documentElement) => current + documentElement.ExportedContent);

            return childrenContent;
        }

        public void Export(Text text)
        {
            text.ExportedContent = $"{_tags.OpeningText()}{text.Content}{_tags.ClosingText()}";
        }

        public void Export(BoldText boldText)
        {
            boldText.ExportedContent = $"{_tags.OpeningBoldText()}{boldText.Content}{_tags.ClosingBoldText()}";
        }
    }
}
