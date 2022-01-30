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

        public override void Acept(IDocumentExporter documentExporter)
        {
            foreach (var documentElement in DocumentElements)
            {
                documentElement.Acept(documentExporter);
            }

            documentExporter.Export(this);
        }
    }
}
