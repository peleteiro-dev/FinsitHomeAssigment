namespace FinsitHomeAssigment.Core.Model
{
    public partial class Document
    {
        private DocumentElement _currentDocumentElement;
        private Paragraph _paragraph = new Paragraph();

        public Document()
        {
            _currentDocumentElement = this;
        }

        public void AddToDocument(DocumentType documentType, DocumentElement documentElement)
        {
            switch (documentType)
            {
                case DocumentType.Section:
                    AddDocumentElement(documentElement);
                    _currentDocumentElement = documentElement;
                    break;
                case DocumentType.SubSection:
                    _currentDocumentElement.AddDocumentElement(documentElement);
                    _currentDocumentElement = documentElement;
                    break;
                case DocumentType.Paragraph:
                    if (_paragraph.DocumentElements.Count > 0)
                        _currentDocumentElement.AddDocumentElement(_paragraph);
                    _paragraph = (Paragraph)documentElement;
                    break;
                case DocumentType.Text:
                    _paragraph.AddDocumentElement(documentElement);
                    break;
                case DocumentType.BoldText:
                    _paragraph.AddDocumentElement(documentElement);
                    break;
            }
        }
    }
}
