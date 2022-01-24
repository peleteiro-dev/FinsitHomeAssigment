using FinsitHomeAssigment.Core.Abstract;
using FinsitHomeAssigment.Core.Interface;
using System;

namespace FinsitHomeAssigment.Core.Model
{
    class Section : DocumentElement
    {
        public string Title { get; set; }

        public override void Accept(IDocumentVisitor documentVisitor)
        {
            throw new NotImplementedException();
        }
    }
}
