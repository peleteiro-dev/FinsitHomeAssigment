using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Parser
{
    public class ParagraphFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return new Paragraph();
        }
    }
}
