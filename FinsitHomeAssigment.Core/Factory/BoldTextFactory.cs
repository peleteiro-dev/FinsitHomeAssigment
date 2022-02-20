using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Implementation of IDocumentElementFactory to be used by MarkdownParser
    /// in order to create BoldText DocumentElements
    /// </summary>
    public class BoldTextFactory : IDocumentElementFactory
    {
        public string Delimiter => Separator.BoldText;

        public DocumentElement Create(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;

            return line.StartsWith(Delimiter) 
                ? new BoldText(line.Replace(Delimiter, "")) 
                : null;
        }
    }
}
