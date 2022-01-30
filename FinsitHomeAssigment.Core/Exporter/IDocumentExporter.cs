using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Exporter
{
    public interface IDocumentExporter
    {
        void Visit(Document document);
        void Visit(Section section);
        void Visit(Paragraph paragraph);
        void Visit(Text text);
        void Visit(BoldText boldText);
    }
}
