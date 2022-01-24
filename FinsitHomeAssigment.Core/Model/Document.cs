using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;
using System;

namespace FinsitHomeAssigment.Core.Model
{
    public class Document : DocumentElement
    {
        public string Title { get; set; }

        public override void Accept(IDocumentVisitor documentVisitor)
        {
            throw new NotImplementedException();
        }
    }
}
