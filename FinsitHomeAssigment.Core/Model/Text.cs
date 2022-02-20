using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    /// <summary>
    /// Implementation of DocumentElement for Text
    /// </summary>
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
            if (!(other is Text otherText)) return false;

            return Content == otherText.Content &&
                   IsComposite() == otherText.IsComposite();
        }
    }
}

