using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public interface IDocumentElementFactory
    {
        DocumentElement Create(string line);
    }
}
