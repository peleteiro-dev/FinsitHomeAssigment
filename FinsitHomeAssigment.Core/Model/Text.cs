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

        public override void AddDocumentElement(DocumentElement documentElement)
        {
            // do nothing, it's a leaf, could also throw an exception
        }

        public override void RemoveDocumentElement(DocumentElement documentElement)
        {
            // do nothing, it's a leaf, could also throw an exception
        }

        public override void Export(IDocumentExporter documentExporter)
        {
            documentExporter.Visit(this);
        }
    }
}
