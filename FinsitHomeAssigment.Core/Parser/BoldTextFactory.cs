using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Parser
{
    public class BoldTextFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return new BoldText(line);
        }
    }
}
