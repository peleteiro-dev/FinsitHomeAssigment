using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class SectionFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return  line.StartsWith("# ") ? new Section(line) :  null;
        }
    }
}
