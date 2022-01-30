using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    public class Text : DocumentElement
    {
        public string Content { get; set; }

        public Text(string content)
        {
            Content = content;
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override void Acept(IDocumentExporter documentExporter)
        {
            documentExporter.Export(this);
        }
    }
}
