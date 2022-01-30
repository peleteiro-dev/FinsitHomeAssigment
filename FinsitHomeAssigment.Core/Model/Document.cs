﻿using FinsitHomeAssigment.Core.Exporter;
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
