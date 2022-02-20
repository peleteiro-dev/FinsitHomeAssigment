using System.Linq;
using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    /// <summary>
    /// Implementation of DocumentElement for Section
    /// </summary>
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
            documentExporter.Export(this);
        }

        public override bool Equals(DocumentElement other)
        {
            if (!(other is Section otherSection)) return false;

            return DocumentElements.SequenceEqual(otherSection.DocumentElements) &&
                   Title == otherSection.Title &&
                   IsComposite() == otherSection.IsComposite();
        }
    }
}
