using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Interface
{
    public interface IDocumentVisitor
    {
        void Visit(Document document);
        void Visit(Section section);
        void Visit(Paragraph paragraph);
        void Visit(Text text);
        void Visit(BoldText boldText);
    }
}
