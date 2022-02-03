using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class SectionFactory : IDocumentElementFactory
    {
        public string Delimiter { get; set; } = "# ";

        public DocumentElement Create(string line)
        {
            return  line.StartsWith(Delimiter) 
                ? new Section(line.Replace(Delimiter, "")) 
                :  null;
        }
    }
}
