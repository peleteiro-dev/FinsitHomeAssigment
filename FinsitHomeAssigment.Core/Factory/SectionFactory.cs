using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
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
