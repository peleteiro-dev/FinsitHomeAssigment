using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class SubSectionFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return line.StartsWith("## ") ? new SubSection(line) : null;
        }
    }
}
