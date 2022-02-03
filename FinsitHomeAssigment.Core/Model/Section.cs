using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class Section : DocumentElement
    {
        public string Title { get; set; }

        public Section(string title)
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
            if (other == null || !(other is Section otherSection)) return false;

            return DocumentElements.SequenceEqual(otherSection.DocumentElements) &&
                   Title == otherSection.Title &&
                   IsComposite() == otherSection.IsComposite();
        }
    }
}
