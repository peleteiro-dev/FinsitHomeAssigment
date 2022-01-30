using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Parser
{
    public class TextFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return new Text(line);
        }
    }
}
