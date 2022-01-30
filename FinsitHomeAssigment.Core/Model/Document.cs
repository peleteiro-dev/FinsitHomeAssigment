using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public partial class Document : DocumentElement
    {
        public override bool IsComposite()
        {
            return true;
        }

        public override void Acept(IDocumentExporter documentExporter)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Acept(documentExporter);
            }

            documentExporter.Export(this);
        }
    }
}
