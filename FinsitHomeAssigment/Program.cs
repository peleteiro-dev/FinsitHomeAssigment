using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Factory;
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

            var lineParser = new TextLineParser();
            lineParser.AddFactory(new BoldTextFactory());
            lineParser.AddFactory(new TextFactory());

            var parser = new MarkdownParser(lineParser);
            parser.AddFactory(new SectionFactory());
            parser.AddFactory(new SubSectionFactory());
            parser.AddFactory(new ParagraphFactory());

            var path = @"C:\Users\Martin\source\repos\FinsitHomeAssigment\FinsitHomeAssigment.Core\Parser\MarkdownText.txt";
            var lines = File.ReadAllLines(path).ToList();
            var newlines = lines
                .Select(line => string.IsNullOrEmpty(line) ? line : line + Environment.NewLine)
                .ToList();

            var document = parser.Parse(newlines);

            var markdownExporter = new MarkdownExporter();
            document.Accept(markdownExporter);
            var exported = document.ExportedContent;
            Console.WriteLine(exported);

            var htmlExporter = new HtmlExporter();
            document.Accept(htmlExporter);
            exported = document.ExportedContent;
            Console.WriteLine(exported);

            var mediawikiExporter = new MediawikiExporter();
            document.Accept(mediawikiExporter);
            exported = document.ExportedContent;
            Console.WriteLine(exported);

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }
    }
}
