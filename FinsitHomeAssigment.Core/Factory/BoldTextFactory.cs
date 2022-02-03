using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class BoldTextFactory : IDocumentElementFactory
    {
        public string Delimiter { get; set; } = "**";

        public DocumentElement Create(string line)
        {
            return line.StartsWith(Delimiter) 
                ? new BoldText(line.Replace(Delimiter, "")) 
                : null;
        }
    }
}
