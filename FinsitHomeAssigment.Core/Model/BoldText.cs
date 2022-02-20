using FinsitHomeAssigment.Core.Exporter;

namespace FinsitHomeAssigment.Core.Model
{
    /// <summary>
    /// Implementation of DocumentElement for BoldText
    /// </summary>
    public class BoldText : DocumentElement
    {
        public string Content { get; set; }

        public BoldText(string content)
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
            if (!(other is BoldText otherBoldText)) return false;

            return Content == otherBoldText.Content &&
                   IsComposite() == otherBoldText.IsComposite();
        }
    }
}
