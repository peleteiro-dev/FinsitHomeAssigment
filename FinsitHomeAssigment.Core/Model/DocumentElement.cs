using FinsitHomeAssigment.Core.Exporter;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Model
{
    public abstract class DocumentElement
    {
        public string ExportedContent { get; set; }
        public IList<DocumentElement> DocumentElements { get; set; } = new List<DocumentElement>();

        public abstract bool IsComposite();
        public abstract void AddDocumentElement(DocumentElement documentElement);
        public abstract void RemoveDocumentElement(DocumentElement documentElement);
        public abstract void Export(IDocumentExporter documentExporter);
    }
}
