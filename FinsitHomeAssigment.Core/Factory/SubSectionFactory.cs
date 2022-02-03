using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class SubSectionFactory : IDocumentElementFactory
    {
        public string Delimiter { get; set; } = "## ";

        public DocumentElement Create(string line)
        {
            return line.StartsWith(Delimiter) 
                ? new SubSection(line.Replace(Delimiter, "")) 
                : null;
        }
    }
}
