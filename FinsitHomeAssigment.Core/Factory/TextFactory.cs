using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class TextFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return new Text(line);
        }
    }
}
