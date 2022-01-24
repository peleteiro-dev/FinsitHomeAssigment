using FinsitHomeAssigment.Core.Interface;
using FinsitHomeAssigment.Core.Model;
using System;

namespace FinsitHomeAssigment.Core.Visitor
{
    public class HtmlVisitor : IDocumentVisitor
    {
        public void Visit(Document document)
        {
            Console.WriteLine($"{document.GetType().Name} visited by {this.GetType().Name}");
        }

        public void Visit(Section section)
        {
            Console.WriteLine($"{section.GetType().Name} visited by {this.GetType().Name}");
        }

        public void Visit(Paragraph paragraph)
        {
            Console.WriteLine($"{paragraph.GetType().Name} visited by {this.GetType().Name}");
        }

        public void Visit(Text text)
        {
            Console.WriteLine($"{text.GetType().Name} visited by {this.GetType().Name}");
        }

        public void Visit(BoldText boldText)
        {
            Console.WriteLine($"{boldText.GetType().Name} visited by {this.GetType().Name}");
        }
    }
}
