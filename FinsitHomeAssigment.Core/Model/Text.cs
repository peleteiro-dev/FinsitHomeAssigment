﻿using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;

namespace FinsitHomeAssigment.Core.Model
{
    public class Text : DocumentElement
    {
        public string Content { get; set; }

        public override void AddDocumentElement(DocumentElement documentElement)
        {
            // do nothing, it's a leaf, could also throw an exception
        }

        public override void RemoveDocumentElement(DocumentElement documentElement)
        {
            // do nothing, it's a leaf, could also throw an exception
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override void Accept(IDocumentVisitor documentVisitor)
        {
            documentVisitor.Visit(this);
        }
    }
}
