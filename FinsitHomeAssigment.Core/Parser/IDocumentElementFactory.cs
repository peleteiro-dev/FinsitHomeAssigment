using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Parser
{
    public interface IDocumentElementFactory
    {
        DocumentElement Create(string line);
    }
}
