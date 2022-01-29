using FinsitHomeAssigment.Core.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FinsitHomeAssigment.Core.Abstract
{
    public abstract class DocumentElement
    {
        public string Title { get; set; }
        public string OpeningTag { get; set; }
        public string ClosingTag { get; set; }
        public string ExportedContent { get; set; }
        public IList<DocumentElement> DocumentElements { get; set; } = new List<DocumentElement>();

        public virtual string GetContent(DocumentElement document)
        {
            var exportedContent = document.OpeningTag;
            exportedContent += document.Title;

            exportedContent = document.DocumentElements.Aggregate(exportedContent,
                (current, documentElement) => current + documentElement.ExportedContent);

            exportedContent += document.ClosingTag;

            return exportedContent;
        }

        public virtual void AddDocumentElement(DocumentElement documentElement)
        {
            if (documentElement == null) return;

            DocumentElements.Add(documentElement);
        }

        public virtual void RemoveDocumentElement(DocumentElement documentElement)
        {
            if (documentElement == null) return;

            DocumentElements.Remove(documentElement);
        }

        public virtual bool IsComposite()
        {
            return true;
        }

        public abstract void Accept(IDocumentVisitor documentVisitor);
    }
}
