using System;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class MarkdownTags : IDocumentTags
    {
        public string OpeningDocument() => string.Empty;
        public string ClosingDocument() => string.Empty;

        public string OpeningSection() => "# ";
        public string ClosingSection() => string.Empty;
        public string SectionSeparator() => Environment.NewLine;

        public string OpeningSubSection() => "## ";
        public string ClosingSubSection() => string.Empty;
        public string SubSectionSeparator() => Environment.NewLine;

        public string OpeningParagraph() => string.Empty;
        public string ClosingParagraph() => string.Empty;
        public string ParagraphSeparator() => Environment.NewLine;

        public string OpeningText() => string.Empty;
        public string ClosingText() => string.Empty;

        public string OpeningBoldText() => "**";
        public string ClosingBoldText() => "**";
    }
}
