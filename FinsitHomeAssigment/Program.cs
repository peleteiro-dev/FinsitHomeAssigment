using FinsitHomeAssigment.Core;
using FinsitHomeAssigment.Core.Util;
using System;

namespace FinsitHomeAssigment
{
    /// <summary>
    /// Console application to serve as an example of using the library
    /// </summary>
    public class Program
    {
        private static readonly MarkdownConverter MarkdownConverter = new MarkdownConverter();
        private static readonly string NewLine = $"{Environment.NewLine}{Environment.NewLine}";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...\n");

            var directory = FileUtils.GetAssemblyDir();
            var path = FileUtils.JoinPaths(directory, "MarkdownText.md");
            PrintFromFile(path);

            Console.WriteLine($"{NewLine}Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            var text = FileUtils.ReadFileAsString(path);
            PrintFromString(text);

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }

        private static void PrintFromString(string text)
        {
            var mediawikiText = MarkdownConverter.FromStringToMediawiki(text);
            ConsoleWriteColoredLine($"From string to Mediawiki{NewLine}");
            Console.WriteLine(mediawikiText);

            var markdownText = MarkdownConverter.FromStringToMarkdown(text);
            ConsoleWriteColoredLine($"From string to Markdown{NewLine}");
            Console.WriteLine(markdownText);

            var htmlText = MarkdownConverter.FromStringToHtml(text);
            ConsoleWriteColoredLine($"From string to Html{NewLine}");
            Console.WriteLine(htmlText);
        }

        private static void PrintFromFile(string path)
        {
            var mediawiki = MarkdownConverter.FromFileToMediawiki(path);
            ConsoleWriteColoredLine($"From file to Mediawiki{NewLine}");
            Console.WriteLine(mediawiki);

            var markdown = MarkdownConverter.FromFileToMarkdown(path);
            ConsoleWriteColoredLine($"From file to Markdown{NewLine}");
            Console.WriteLine(markdown);

            var html = MarkdownConverter.FromFileToHtml(path);
            ConsoleWriteColoredLine($"From file to Html{NewLine}");
            Console.WriteLine(html);
        }

        private static void ConsoleWriteColoredLine(string line, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}
