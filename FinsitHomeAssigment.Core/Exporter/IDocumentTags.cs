namespace FinsitHomeAssigment.Core.Exporter
{
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