using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;

namespace FinsitHomeAssigment.Core.Model
{
    public class Section : DocumentElement
    {
        public string Title { get; set; }

        public override void Accept(IDocumentVisitor documentVisitor)
        {
            documentVisitor.Visit(this);

            foreach (var documentElement in DocumentElements)
            {
                documentElement.Accept(documentVisitor);
            }
        }
    }
}
