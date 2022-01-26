using FinsitHomeAssigment.Core.Interface;
using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Visitor
{
    public class HtmlVisitor : IDocumentVisitor
    {
        public void Visit(Document document)
        {
            document.OpeningTag = "<doc>";
            document.ClosingTag = "</doc>";
        }

        public void Visit(Section section)
        {
            section.OpeningTag = "<section>";
            section.ClosingTag = "</section>";
        }

        public void Visit(Paragraph paragraph)
        {
            paragraph.OpeningTag = "<p>";
            paragraph.ClosingTag = "</p>";
        }

        public void Visit(Text text)
        {
            text.OpeningTag = "<text>";
            text.ClosingTag = "</text>";
        }

        public void Visit(BoldText boldText)
        {
            boldText.OpeningTag = "<bold>";
            boldText.ClosingTag = "</bold>";
        }
    }
}
