namespace FinsitHomeAssigment.Core.Exporter
{
    public interface IDocumentTags
    {
        string OpeningDocument();
        string ClosingDocument();

        string OpeningSection();
        string ClosingSection();
        string SectionSeparator();

        string OpeningSubSection();
        string ClosingSubSection();
        string SubSectionSeparator();

        string OpeningParagraph();
        string ClosingParagraph();
        string ParagraphSeparator();

        string OpeningText();
        string ClosingText();

        string OpeningBoldText();
        string ClosingBoldText();
    }
}