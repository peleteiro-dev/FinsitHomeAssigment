using FinsitHomeAssigment.Core.Interface;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Abstract
{
    public abstract class DocumentElement
    {
        public IList<DocumentElement> DocumentElements { get; set; }

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
