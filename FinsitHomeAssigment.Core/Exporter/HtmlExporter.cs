using FinsitHomeAssigment.Core.Model;
using System.Linq;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class HtmlExporter : IDocumentExporter
    {
        private readonly HtmlConstants _constants;

        public HtmlExporter(HtmlConstants constants)
        {
            _constants = constants;
        }

        public void Export(Document document)
        {
            var exportedContent = _constants.OpeningDocument;

            exportedContent = document.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += _constants.ClosingDocument;

            document.ExportedContent = exportedContent;
        }

        public void Export(Section section)
        {
            var exportedContent = _constants.OpeningSection;
            exportedContent += section.Title;

            exportedContent = section.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += _constants.ClosingSection;

            section.ExportedContent = exportedContent;
        }

        public void Export(Paragraph paragraph)
        {
            var exportedContent = _constants.OpeningParagraph;

            exportedContent = paragraph.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += _constants.ClosingParagraph;

            paragraph.ExportedContent = exportedContent;
        }

        public void Export(Text text)
        {
           text.ExportedContent = $"{_constants.OpeningText}{text.Content}{_constants.ClosingText}";
        }

        public void Export(BoldText boldText)
        {
            boldText.ExportedContent = $"{_constants.OpeningBoldText}{boldText.Content}{_constants.ClosingBoldText}";
        }
    }
}
