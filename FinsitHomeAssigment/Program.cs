using FinsitHomeAssigment.Core.Model;
using FinsitHomeAssigment.Core.Visitor;
using System;

namespace FinsitHomeAssigment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...\n");

            var paragraph = new Paragraph();
            paragraph.DocumentElements.Add(new Text("testing text"));
            paragraph.DocumentElements.Add(new BoldText("bold text"));

            var document = new Document();
            document.DocumentElements.Add(paragraph);

            var section = new Section();
            section.DocumentElements.Add(new Section());
            section.DocumentElements.Add(paragraph);

            document.DocumentElements.Add(section);

            document.Accept(new HtmlVisitor());
            Console.WriteLine(document.Export());

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }
    }
}
