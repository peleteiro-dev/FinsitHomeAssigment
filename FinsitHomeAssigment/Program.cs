using FinsitHomeAssigment.Core.Model;
using FinsitHomeAssigment.Core.Parser;
using System;
using System.IO;
using System.Linq;

namespace FinsitHomeAssigment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...\n");

            //var paragraph = new Paragraph();
            //paragraph.DocumentElements.Add(new Text("testing text"));
            //paragraph.DocumentElements.Add(new BoldText("bold text"));

            //var document = new Document();
            //document.DocumentElements.Add(paragraph);

            //var section = new Section();
            //section.DocumentElements.Add(new Section());
            //section.DocumentElements.Add(paragraph);

            //document.DocumentElements.Add(section);

            //document.Accept(new HtmlVisitor());
            //Console.WriteLine(document.ExportedContent);

            var parser = new MarkdownParser();
            var path = @"C:\Users\Martin\source\repos\FinsitHomeAssigment\FinsitHomeAssigment.Core\Parser\MarkdownText.txt";
            var lines = File.ReadAllLines(path).ToList();
            parser.Parse(lines, out Document document);

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }
    }
}
