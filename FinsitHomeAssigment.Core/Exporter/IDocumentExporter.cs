using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Exporter
{
    public interface IDocumentExporter
    {
        IDocumentTags GetTags();
        void Export(Document document);
        void Export(Section section);
        void Export(SubSection subSection);
        void Export(Paragraph paragraph);
        void Export(Text text);
        void Export(BoldText boldText);
    }
}
