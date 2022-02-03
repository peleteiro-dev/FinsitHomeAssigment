using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    public interface IDocumentElementFactory
    {
        string Delimiter { get; set; }
        DocumentElement Create(string line);
    }
}
