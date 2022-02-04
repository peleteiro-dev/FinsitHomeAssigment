using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class SubSectionFactory : IDocumentElementFactory
    {
        public string Delimiter { get; set; } = Constant.SubSectionDelimiter;

        public DocumentElement Create(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;

            return line.StartsWith(Delimiter) 
                ? new SubSection(line.Replace(Delimiter, "")) 
                : null;
        }
    }
}
