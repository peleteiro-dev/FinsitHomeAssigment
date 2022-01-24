using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;
using System;

namespace FinsitHomeAssigment.Core.Model
{
    public class BoldText : DocumentElement
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
            throw new NotImplementedException();
        }
    }
}
