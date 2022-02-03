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

        public override void Accept(IDocumentExporter documentExporter)
        {
            documentExporter.Export(this);
        }

        public override bool Equals(DocumentElement other)
        {
            if (other == null || !(other is Text otherText)) return false;

            return Content == otherText.Content &&
                   IsComposite() == otherText.IsComposite();
        }
    }
}

