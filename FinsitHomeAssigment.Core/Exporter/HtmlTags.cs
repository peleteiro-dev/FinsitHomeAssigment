namespace FinsitHomeAssigment.Core.Exporter
{
    public class HtmlTags : IDocumentTags
    {
        public string OpeningDocument() => "<html><head></head><body>";
        public string ClosingDocument() => "</body></html>";

        public string OpeningSection() => "<section>";
        public string ClosingSection() => "</section>";
        public string SectionSeparator() => string.Empty;

        public string OpeningSubSection() => "<section>";
        public string ClosingSubSection() => "</section>";
        public string SubSectionSeparator() => string.Empty;

        public string OpeningParagraph() => "<p>";
        public string ClosingParagraph() => "</p>";
        public string ParagraphSeparator() => string.Empty;

        public string OpeningText() => string.Empty;
        public string ClosingText() => string.Empty;

        public string OpeningBoldText() => "<bold>";
        public string ClosingBoldText() => "</bold>";
    }
}
