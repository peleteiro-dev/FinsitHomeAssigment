namespace FinsitHomeAssigment.Core.Exporter
{
    /// <summary>
    /// Implementation of IDocumentTags to provide with mark tags
    /// used for opening and closing Markdown DocumentElements
    /// </summary>
    public class MarkdownTags : IDocumentTags
    {
        public string OpeningDocument() => string.Empty;
        public string ClosingDocument() => string.Empty;

        public string OpeningSection() => "# ";
        public string ClosingSection() => string.Empty;

        public string OpeningSubSection() => "## ";
        public string ClosingSubSection() => string.Empty;

        public string OpeningParagraph() => string.Empty;
        public string ClosingParagraph() => string.Empty;

        public string OpeningText() => string.Empty;
        public string ClosingText() => string.Empty;

        public string OpeningBoldText() => "**";
        public string ClosingBoldText() => "**";
    }
}
