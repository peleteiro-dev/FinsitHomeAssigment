using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class Paragraph : DocumentElement
    {
        public override bool IsComposite()
        {
            return true;
        }

        public override void Accept(IDocumentExporter documentExporter)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Accept(documentExporter);
            }

            documentExporter.Export(this);
        }

        public override bool Equals(DocumentElement other)
        {
            if (other == null || !(other is Paragraph otherParagraph)) return false;

            return DocumentElements.SequenceEqual(otherParagraph.DocumentElements) &&
                   IsComposite() == otherParagraph.IsComposite();
        }
    }
}
