using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Implementation of IDocumentElementFactory to be used by MarkdownParser
    /// in order to create Section DocumentElements
    /// </summary>
    public class SectionFactory : IDocumentElementFactory
    {
        public string Delimiter => Separator.Section;

        public DocumentElement Create(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;

            return line.StartsWith(Delimiter) 
                ? new Section(line.Replace(Delimiter, "")) 
                :  null;
        }
    }
}
