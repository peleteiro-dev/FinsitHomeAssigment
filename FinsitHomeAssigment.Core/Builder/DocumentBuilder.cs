﻿using System.Collections.Generic;
using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Builder
{
    public class DocumentBuilder
    {
        private readonly Document _document = new Document();
        private DocumentElement _currentDocumentElement;
        private Paragraph _paragraph = new Paragraph();

        public DocumentBuilder()
        {
            _currentDocumentElement = _document;
        }

        public Document GetDocument()
        {
            Close();
            return _document;
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
            switch (documentElement)
            {
                case Section section:
                    AddToDocument(section);
                    break;
                case SubSection subSection:
                    AddToDocument(subSection);
                    break;
                case Paragraph paragraph:
                    AddToDocument(paragraph);
                    break;
                case Text text:
                    AddToDocument(text);
                    break;
                case BoldText boldText:
                    AddToDocument(boldText);
                    break;
            }
        }

        private void AddToDocument(Section section)
        {
            _document.AddDocumentElement(section);
            _currentDocumentElement = section;
        }

        private void AddToDocument(SubSection subSection)
        {
            _currentDocumentElement.AddDocumentElement(subSection);
            _currentDocumentElement = subSection;
        }

        private void AddToDocument(Paragraph paragraph)
        {
            if (_paragraph.DocumentElements.Count > 0)
                _currentDocumentElement.AddDocumentElement(_paragraph);
            _paragraph = paragraph;
        }

        private void AddToDocument(Text text)
        {
            _paragraph.AddDocumentElement(text);
        }

        private void AddToDocument(BoldText boldText)
        {
            _paragraph.AddDocumentElement(boldText);
        }

        private void Close()
        {
            if (_paragraph.DocumentElements.Count > 0)
            {
                _currentDocumentElement.AddDocumentElement(_paragraph);
            }
        }
    }
}
