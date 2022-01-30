using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class Section : DocumentElement
    {
        public Section(string title)
        {
            Title = title;
        }

        public override void Export(IDocumentExporter documentExporter)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Export(documentExporter);
            }

            documentExporter.Visit(this);
        }
    }
}
