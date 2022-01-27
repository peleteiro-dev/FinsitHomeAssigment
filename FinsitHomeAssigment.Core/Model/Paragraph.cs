using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;

namespace FinsitHomeAssigment.Core.Model
{
    public class Paragraph : DocumentElement
    {
        public override void Accept(IDocumentVisitor documentVisitor)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Accept(documentVisitor);
            }

            documentVisitor.Visit(this);
        }
    }
}
