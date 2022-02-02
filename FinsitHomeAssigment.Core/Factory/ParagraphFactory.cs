using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class ParagraphFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return string.IsNullOrEmpty(line) ? new Paragraph() : null;
        }
    }
}
