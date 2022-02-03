using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public partial class Document : DocumentElement
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
            if (other == null || !(other is Document otherDocument)) return false;

            return DocumentElements.SequenceEqual(otherDocument.DocumentElements) &&
                   IsComposite() == otherDocument.IsComposite();
        }
    }
}
