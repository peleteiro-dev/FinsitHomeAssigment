namespace FinsitHomeAssigment.Core.Exporter
{
    /// <summary>
    /// Implementation of IDocumentTags to provide with mark tags
    /// used for opening and closing Html DocumentElements
    /// </summary>
    public class HtmlTags : IDocumentTags
    {
        public string OpeningDocument() => "<html><head></head><body>";
        public string ClosingDocument() => "</body></html>";

        public string OpeningSection() => "<section>";
        public string ClosingSection() => "</section>";

        public string OpeningSubSection() => "<section>";
        public string ClosingSubSection() => "</section>";

        public string OpeningParagraph() => "<p>";
        public string ClosingParagraph() => "</p>";

        public string OpeningText() => string.Empty;
        public string ClosingText() => string.Empty;

        public string OpeningBoldText() => "<bold>";
        public string ClosingBoldText() => "</bold>";
    }
}
