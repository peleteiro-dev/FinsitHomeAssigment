using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;
using System.Linq;

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

        public override string Export()
        {
            var result = OpeningTag + "\n";

            result = DocumentElements.Aggregate(result,
                (current, documentElement) => current + documentElement.Export());

            return $"{result}{ClosingTag}\n";
        }
    }
}
