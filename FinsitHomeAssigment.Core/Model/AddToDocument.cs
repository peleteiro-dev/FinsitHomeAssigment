using System.Collections.Generic;

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

        public void AddToDocument(IEnumerable<DocumentElement> documentElements)
        {
            foreach (var documentElement in documentElements)
            {
                AddToDocument(documentElement);
            }
        }

        public void AddToDocument(DocumentElement documentElement)
        {
            var documentType = documentElement.GetType().Name;
            switch (documentType)
            {
                case nameof(Section):
                    AddDocumentElement(documentElement);
                    _currentDocumentElement = documentElement;
                    break;
                case nameof(SubSection):
                    _currentDocumentElement.AddDocumentElement(documentElement);
                    _currentDocumentElement = documentElement;
                    break;
                case nameof(Paragraph):
                    if (_paragraph.DocumentElements.Count > 0)
                        _currentDocumentElement.AddDocumentElement(_paragraph);
                    _paragraph = (Paragraph)documentElement;
                    break;
                case nameof(Text):
                    _paragraph.AddDocumentElement(documentElement);
                    break;
                case nameof(BoldText):
                    _paragraph.AddDocumentElement(documentElement);
                    break;
            }
        }

        public void Close()
        {
            if (_paragraph.DocumentElements.Count > 0)
            {
                _currentDocumentElement.AddDocumentElement(_paragraph);
            }
        }
    }
}
