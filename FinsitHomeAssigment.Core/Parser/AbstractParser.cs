using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;
using FinsitHomeAssigment.Core.Factory;

namespace FinsitHomeAssigment.Core.Parser
{
    public abstract class AbstractParser
    {
        private readonly List<IDocumentElementFactory> _factories = new List<IDocumentElementFactory>();

        internal DocumentElement CreateDocumentElement(string line)
        {
            DocumentElement documentElement = null;
            foreach (var documentElementFactory in _factories)
            {
                documentElement = documentElementFactory.Create(line);
                if (documentElement != null) break;
            }

            return documentElement;
        }

        public void AddFactory(IDocumentElementFactory factory)
        {
            if (factory == null || _factories.Contains(factory)) return;

            _factories.Add(factory);
        }

        public void RemoveFactory(IDocumentElementFactory factory)
        {
            if (factory == null || !_factories.Contains(factory)) return;

            _factories.Remove(factory);
        }

        public IEnumerable<IDocumentElementFactory> GetFactories()
        {
            return _factories;
        }
    }
}
