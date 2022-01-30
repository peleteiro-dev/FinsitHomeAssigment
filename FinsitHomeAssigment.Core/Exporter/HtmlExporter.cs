using FinsitHomeAssigment.Core.Model;
using System.Linq;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class HtmlExporter : IDocumentExporter
    {
        private HtmlConstants _cons;

        public HtmlExporter(HtmlConstants constants)
        {
            _cons = constants;
        }

        public void Visit(Document document)
        {
            document.OpeningTag = _cons.OpeningDocument;
            document.ClosingTag = _cons.ClosingDocument;

            var exportedContent = document.OpeningTag;

            exportedContent = document.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += document.ClosingTag;

            document.ExportedContent = exportedContent;
        }

        public void Visit(Section section)
        {
            section.OpeningTag = _cons.OpeningSection;
            section.ClosingTag = _cons.ClosingSection;

            var exportedContent = section.OpeningTag;
            exportedContent += section.Title;

            exportedContent = section.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += section.ClosingTag;

            section.ExportedContent = exportedContent;
        }

        public void Visit(Paragraph paragraph)
        {
            paragraph.OpeningTag = _cons.OpeningParagraph;
            paragraph.ClosingTag = _cons.ClosingParagraph;

            var exportedContent = paragraph.OpeningTag;

            exportedContent = paragraph.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += paragraph.ClosingTag;

            paragraph.ExportedContent = exportedContent;
        }

        public void Visit(Text text)
        {
            text.OpeningTag = _cons.OpeningText;
            text.ClosingTag = _cons.ClosingText;

            text.ExportedContent = $"{text.OpeningTag}{text.Content}{text.ClosingTag}";
        }

        public void Visit(BoldText boldText)
        {
            boldText.OpeningTag = _cons.OpeningBoldText;
            boldText.ClosingTag = _cons.ClosingBoldText; 

            boldText.ExportedContent = $"{boldText.OpeningTag}{boldText.Content}{boldText.ClosingTag}";
        }
    }
}
