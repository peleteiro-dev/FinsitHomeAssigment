﻿using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class BoldText : DocumentElement
    {
        public string Content { get; set; }

        public BoldText(string content)
        {
            Content = content;
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override void AddDocumentElement(DocumentElement documentElement)
        {
            // do nothing, it's a leaf, could also throw an exception
        }

        public override void RemoveDocumentElement(DocumentElement documentElement)
        {
            // do nothing, it's a leaf, could also throw an exception
        }

        public override string GetContent(DocumentElement document)
        {
            return $"{document.OpeningTag}{Content}{document.ClosingTag}";
        }

        public override void Export(IDocumentExporter documentExporter)
        {
            documentExporter.Visit(this);
        }
    }
}
