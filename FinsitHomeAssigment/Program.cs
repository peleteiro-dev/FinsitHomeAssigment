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

            var parser = new MarkdownParser();
            var path = @"C:\Users\Martin\source\repos\FinsitHomeAssigment\FinsitHomeAssigment.Core\Parser\MarkdownText.txt";
            var lines = File.ReadAllLines(path).ToList();
            var document = parser.Parse(lines);

            Console.WriteLine("\nFinishing program. Press enter to quit...");

            Console.ReadLine();
        }
    }
}
