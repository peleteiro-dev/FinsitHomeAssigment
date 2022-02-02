using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public class BoldTextFactory : IDocumentElementFactory
    {
        public DocumentElement Create(string line)
        {
            return line.StartsWith("** ") 
                ? new BoldText(line.Replace("** ", "")) 
                : null;
        }
    }
}
