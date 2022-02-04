using FinsitHomeAssigment.Core.Parser;
using System;
using System.IO;
using System.Linq;
using FinsitHomeAssigment.Core.Factory;

namespace FinsitHomeAssigment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...\n");

            var lineParser = new TextLineParser();
            lineParser.AddFactory(new BoldTextFactory());
            lineParser.AddFactory(new TextFactory());

            var parser = new MarkdownParser(lineParser);
            parser.AddFactory(new SectionFactory());
            parser.AddFactory(new SubSectionFactory());
            parser.AddFactory(new ParagraphFactory());

            var path = @"C:\Users\Martin\source\repos\FinsitHomeAssigment\FinsitHomeAssigment.Core\Parser\MarkdownText.txt";
            var lines = File.ReadAllLines(path).ToList();
            var document = parser.Parse(lines);

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }
    }
}
