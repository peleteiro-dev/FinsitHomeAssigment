using FinsitHomeAssigment.Core.Exporter;
using System.Linq;

namespace FinsitHomeAssigment.Core.Model
{
    public class Document : DocumentElement
    {
        public override bool IsComposite()
        {
            return true;
        }

        public override void AddDocumentElement(DocumentElement documentElement)
        {
            if (documentElement == null) return;

            DocumentElements.Add(documentElement);
        }

        public override void RemoveDocumentElement(DocumentElement documentElement)
        {
            if (documentElement == null) return;

            DocumentElements.Remove(documentElement);
        }

        public override string GetContent(DocumentElement document)
        {
            var exportedContent = document.OpeningTag;
            exportedContent += document.Title;

            exportedContent = document.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += document.ClosingTag;

            return exportedContent;
        }

        public override void Export(IDocumentExporter documentExporter)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Export(documentExporter);
            }

            documentExporter.Visit(this);
        }
    }
}
