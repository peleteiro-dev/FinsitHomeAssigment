using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class SubSection : DocumentElement
    {
        public string Title { get; set; }

        public SubSection(string title)
        {
            Title = title;
        }

        public override bool IsComposite()
        {
            return true;
        }

        public override void Accept(IDocumentExporter documentExporter)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Accept(documentExporter);
            }

            documentExporter.Export(this);
        }

        public override bool Equals(DocumentElement other)
        {
            if (other == null || !(other is SubSection otherSubSection)) return false;

            return DocumentElements.SequenceEqual(otherSubSection.DocumentElements) &&
                   Title == otherSubSection.Title &&
                   IsComposite() == otherSubSection.IsComposite();
        }
    }
}
