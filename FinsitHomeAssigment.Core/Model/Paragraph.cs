using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    /// <summary>
    /// Implementation of DocumentElement for Paragraph
    /// </summary>
    public class Paragraph : DocumentElement
    {
        public override bool IsComposite()
        {
            return true;
        }

        public override void Accept(IDocumentExporter documentExporter)
        {
            documentExporter.Export(this);
        }

        public override bool Equals(DocumentElement other)
        {
            if (!(other is Paragraph otherParagraph)) return false;

            return DocumentElements.SequenceEqual(otherParagraph.DocumentElements) &&
                   IsComposite() == otherParagraph.IsComposite();
        }
    }
}
