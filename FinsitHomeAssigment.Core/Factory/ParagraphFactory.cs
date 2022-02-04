using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class ParagraphFactory : IDocumentElementFactory
    {
        public string Delimiter => Constant.ParagraphDelimiter;

        public DocumentElement Create(string line)
        {
            return line == Delimiter ? new Paragraph() : null;
        }
    }
}
