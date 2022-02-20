namespace FinsitHomeAssigment.Core.Exporter
{
    /// <summary>
    /// Interface to be implemented by different languages tags
    /// </summary>
    public interface IDocumentTags
    {
        string OpeningDocument();
        string ClosingDocument();

        string OpeningSection();
        string ClosingSection();

        string OpeningSubSection();
        string ClosingSubSection();

        string OpeningParagraph();
        string ClosingParagraph();

        string OpeningText();
        string ClosingText();

        string OpeningBoldText();
        string ClosingBoldText();
    }
}