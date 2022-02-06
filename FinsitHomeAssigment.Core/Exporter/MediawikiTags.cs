using System;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class MediawikiTags : IDocumentTags
    {
        public string OpeningDocument() => string.Empty;
        public string ClosingDocument() => string.Empty;

        public string OpeningSection() => "== ";
        public string ClosingSection() => " ==";
        public string SectionSeparator() => Environment.NewLine;

        public string OpeningSubSection() => "=== ";
        public string ClosingSubSection() => " ===";
        public string SubSectionSeparator() => Environment.NewLine;

        public string OpeningParagraph() => string.Empty;
        public string ClosingParagraph() => string.Empty;
        public string ParagraphSeparator() => Environment.NewLine;

        public string OpeningText() => string.Empty;
        public string ClosingText() => string.Empty;

        public string OpeningBoldText() => "'''";
        public string ClosingBoldText() => "'''";
    }
}
