using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Implementation of IDocumentElementFactory to be used by MarkdownParser
    /// in order to create Paragraph DocumentElements
    /// </summary>
    public class ParagraphFactory : IDocumentElementFactory
    {
        public string Delimiter => Separator.Paragraph;

        public DocumentElement Create(string line)
        {
            return line == Delimiter ? new Paragraph() : null;
        }
    }
}
