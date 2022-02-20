using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Exporter
{
    /// <summary>
    /// Interface to be implemented by Exporters
    /// </summary>
    public interface IDocumentExporter
    {
        IDocumentTags GetTags();
        string GetExportedContent();
        void Export(Document document);
        void Export(Section section);
        void Export(SubSection subSection);
        void Export(Paragraph paragraph);
        void Export(Text text);
        void Export(BoldText boldText);
    }
}
