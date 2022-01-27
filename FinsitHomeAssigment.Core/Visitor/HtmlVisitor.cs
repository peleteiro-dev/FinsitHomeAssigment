using FinsitHomeAssigment.Core.Interface;
using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Visitor
{
    public class HtmlVisitor : IDocumentVisitor
    {
        public void Visit(Document document)
        {
            document.OpeningTag = "<doc>\n";
            document.ClosingTag = "</doc>\n";
            
            document.ExportedContent = document.GetContent(document);
        }

        public void Visit(Section section)
        {
            section.OpeningTag = "<section>\n";
            section.ClosingTag = "</section>\n";

            section.ExportedContent = section.GetContent(section);
        }

        public void Visit(Paragraph paragraph)
        {
            paragraph.OpeningTag = "<p>\n";
            paragraph.ClosingTag = "\n</p>\n";

            paragraph.ExportedContent = paragraph.GetContent(paragraph);
        }

        public void Visit(Text text)
        {
            text.OpeningTag = "<text>";
            text.ClosingTag = "</text>";

            text.ExportedContent = $"{text.OpeningTag}{text.Content}{text.ClosingTag}";
        }

        public void Visit(BoldText boldText)
        {
            boldText.OpeningTag = "<bold>";
            boldText.ClosingTag = "</bold>";

            boldText.ExportedContent = $"{boldText.OpeningTag}{boldText.Content}{boldText.ClosingTag}";
        }
    }
}
