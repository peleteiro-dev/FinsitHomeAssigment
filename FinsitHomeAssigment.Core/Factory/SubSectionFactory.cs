using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Implementation of IDocumentElementFactory to be used by MarkdownParser
    /// in order to create SubSection DocumentElements
    /// </summary>
    public class SubSectionFactory : IDocumentElementFactory
    {
        public string Delimiter => Separator.SubSection;

        public DocumentElement Create(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;

            return line.StartsWith(Delimiter) 
                ? new SubSection(line.Replace(Delimiter, "")) 
                : null;
        }
    }
}
