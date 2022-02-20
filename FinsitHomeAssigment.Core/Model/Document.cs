using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    /// <summary>
    /// Implementation of DocumentElement for Document
    /// </summary>
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
