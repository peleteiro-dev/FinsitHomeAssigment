using FinsitHomeAssigment.Core.Model;

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

            document.ExportedContent = document.GetContent(document);
        }

        public void Visit(Section section)
        {
            section.OpeningTag = _cons.OpeningSection;
            section.ClosingTag = _cons.ClosingSection;

            section.ExportedContent = section.GetContent(section);
        }

        public void Visit(Paragraph paragraph)
        {
            paragraph.OpeningTag = _cons.OpeningParagraph;
            paragraph.ClosingTag = _cons.ClosingParagraph;

            paragraph.ExportedContent = paragraph.GetContent(paragraph);
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
