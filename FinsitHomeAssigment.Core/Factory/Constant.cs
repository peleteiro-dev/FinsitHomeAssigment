using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Factory
{
    public class Constant
    {
        public const string SectionDelimiter = "# ";
        public const string SubSectionDelimiter = "## ";
        public const string ParagraphDelimiter = "";
        public const string BoldTextDelimiter = "**";

        // Delimiters have to contain the list of constant values
        // in case of adding new constants add them also to the list
        public static IEnumerable<string> Delimiters => new List<string>
        {
            SectionDelimiter,
            SubSectionDelimiter,
            ParagraphDelimiter,
            BoldTextDelimiter
        };
    }
}
