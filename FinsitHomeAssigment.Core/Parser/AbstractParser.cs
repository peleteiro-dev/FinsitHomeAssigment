using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;
using FinsitHomeAssigment.Core.Factory;

namespace FinsitHomeAssigment.Core.Parser
{
    public abstract class AbstractParser
    {
        public List<IDocumentElementFactory> Factories = new List<IDocumentElementFactory>();

        internal DocumentElement CreateDocumentElement(string line)
        {
            DocumentElement documentElement = null;
            foreach (var documentElementFactory in Factories)
            {
                documentElement = documentElementFactory.Create(line);
                if (documentElement != null) break;
            }

            return documentElement;
        }
    }
}
