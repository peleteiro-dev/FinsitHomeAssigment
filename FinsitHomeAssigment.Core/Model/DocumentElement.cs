using FinsitHomeAssigment.Core.Exporter;
using System.Collections.Generic;
using System.Linq;

namespace FinsitHomeAssigment.Core.Model
{
    public abstract class DocumentElement
    {
        public string Title { get; set; }
        public string OpeningTag { get; set; }
        public string ClosingTag { get; set; }
        public string ExportedContent { get; set; }
        public IList<DocumentElement> DocumentElements { get; set; } = new List<DocumentElement>();

        public abstract bool IsComposite();
        public abstract void AddDocumentElement(DocumentElement documentElement);
        public abstract void RemoveDocumentElement(DocumentElement documentElement);
        public abstract string GetContent(DocumentElement document);
        public abstract void Export(IDocumentExporter documentExporter);
    }
}
