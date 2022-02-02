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
            lineParser.Factories.Add(new BoldTextFactory());
            lineParser.Factories.Add(new TextFactory());

            var parser = new MarkdownParser(lineParser);
            parser.Factories.Add(new SectionFactory());
            parser.Factories.Add(new SubSectionFactory());
            parser.Factories.Add(new ParagraphFactory());

            var path = @"C:\Users\Martin\source\repos\FinsitHomeAssigment\FinsitHomeAssigment.Core\Parser\MarkdownText.txt";
            var lines = File.ReadAllLines(path).ToList();
            var document = parser.Parse(lines);

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }
    }
}
