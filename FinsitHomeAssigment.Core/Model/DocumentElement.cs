using System;
using FinsitHomeAssigment.Core.Exporter;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Model
{
    /// <summary>
    /// Abstract class from which every different document element will inherit
    /// </summary>
    public abstract class DocumentElement : IEquatable<DocumentElement>
    {
        public IList<DocumentElement> DocumentElements { get; set; } = new List<DocumentElement>();

        public abstract bool IsComposite();
        public abstract void Accept(IDocumentExporter documentExporter);
        public abstract bool Equals(DocumentElement other);
        
        public void AddDocumentElement(DocumentElement documentElement)
        {
            if (!IsComposite() || documentElement == null) return;

            DocumentElements.Add(documentElement);
        }
    }
}
