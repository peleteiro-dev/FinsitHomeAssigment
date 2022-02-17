using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class Document : DocumentElement
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
            if (!(other is Document otherDocument)) return false;

            return DocumentElements.SequenceEqual(otherDocument.DocumentElements) &&
                   IsComposite() == otherDocument.IsComposite();
        }
    }
}
