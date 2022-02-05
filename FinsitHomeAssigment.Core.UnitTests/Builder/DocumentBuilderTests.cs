using FinsitHomeAssigment.Core.Builder;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Builder
{
    public class DocumentBuilderTests
    {
        private DocumentBuilder _documentBuilder;
        private Document _expectedDocument;
        private Section _section;
        private SubSection _subSection;
        private Paragraph _paragraph;
        private readonly Text _text = new Text("First line ");
        private readonly BoldText _boldText = new BoldText("bold");

        private void Setup()
        {
            _documentBuilder = new DocumentBuilder();
            _expectedDocument = new Document();
            _section = new Section("Section 1");
            _subSection = new SubSection("Subsection 1");
            _paragraph = new Paragraph();
        }

        [Fact]
        public void CanCreateEmptyDocument()
        {
            Setup();

            _documentBuilder = new DocumentBuilder();

            Assert.NotNull(_documentBuilder.GetDocument());
        }

        [Fact]
        public void CanCreateSingleLineDoc()
        {
            Setup();

            _documentBuilder.AddToDocument(_text);
            _documentBuilder.AddToDocument(_boldText);

            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_boldText); 
            _expectedDocument.AddDocumentElement(_paragraph);

            var equal = _expectedDocument.Equals(_documentBuilder.GetDocument());
            Assert.True(equal);
        }

        [Fact]
        public void CanCreateDocumentWithOneParagraphSection()
        {
            Setup();

            _documentBuilder.AddToDocument(_section);
            _documentBuilder.AddToDocument(_text);
            _documentBuilder.AddToDocument(_boldText);

            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_boldText);
            _section.AddDocumentElement(_paragraph);
            _expectedDocument.AddDocumentElement(_section);

            var equal = _expectedDocument.Equals(_documentBuilder.GetDocument());
            Assert.True(equal);
        }

        [Fact]
        public void CanCreateDocumentWithTwoParagraphSection()
        {
            Setup();

            _documentBuilder.AddToDocument(_section);
            _documentBuilder.AddToDocument(_text);
            _documentBuilder.AddToDocument(_boldText);
            _documentBuilder.AddToDocument(_paragraph);
            _documentBuilder.AddToDocument(_text);

            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_boldText);
            _section.AddDocumentElement(_paragraph);
            _paragraph = new Paragraph();
            _paragraph.AddDocumentElement(_text);
            _section.AddDocumentElement(_paragraph);
            _expectedDocument.AddDocumentElement(_section);

            var equal = _expectedDocument.Equals(_documentBuilder.GetDocument());
            Assert.True(equal);
        }

        [Fact]
        public void CanCreateNestedSectionDocument()
        {
            Setup();

            _documentBuilder.AddToDocument(_section);
            _documentBuilder.AddToDocument(_text);
            _documentBuilder.AddToDocument(_subSection);
            _documentBuilder.AddToDocument(_text);

            _section.AddDocumentElement(_text);
            _subSection.AddDocumentElement(_text);
            _section.AddDocumentElement(_subSection);
            _expectedDocument.AddDocumentElement(_section);

            var equal = _expectedDocument.Equals(_documentBuilder.GetDocument());
            Assert.True(equal);
        }
    }
}
