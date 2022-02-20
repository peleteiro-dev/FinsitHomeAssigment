using System.Collections.Generic;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Used by Factories to identify the different types of Markdown elements
    /// </summary>
    public class Separator
    {
        private static readonly IDocumentTags MarkdownTags = new MarkdownTags();

        public static string Section = MarkdownTags.OpeningSection();
        public static string SubSection = MarkdownTags.OpeningSubSection();
        public static string Paragraph = MarkdownTags.OpeningParagraph();
        public static string BoldText = MarkdownTags.OpeningBoldText();

        // List have to contain the list of constant values
        // in case of adding new constants add them also to the list
        public static IEnumerable<string> List => new List<string>
        {
            Section,
            SubSection,
            Paragraph,
            BoldText
        };
    }
}
