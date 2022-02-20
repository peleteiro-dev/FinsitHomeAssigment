using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Factory
{
    /// <summary>
    /// Interface to be implemented by every type of DocumentElement factory
    /// </summary>
    public interface IDocumentElementFactory
    {
        string Delimiter { get; }
        DocumentElement Create(string line);
    }
}
