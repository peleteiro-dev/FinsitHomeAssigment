using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Parser
{
    public class SectionFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return new Section(line);
        }
    }
}
