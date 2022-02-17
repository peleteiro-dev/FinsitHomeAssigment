using System;
using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Exporter
{
    public class MarkdownExporterTests
    {
        private const string SectionTitle = "section title";
        private const string NestedSectionTitle = "nested section title";
        private const string TestingText = "testing text";
        private const string TestingBoldText = "testing bold";

        private Document _document;
        private IDocumentTags _tags;
        private IDocumentExporter _documentExporter;
        private readonly Section _section = new Section(SectionTitle);
        private readonly SubSection _subSection = new SubSection(NestedSectionTitle);
        private readonly Paragraph _paragraph = new Paragraph();
        private readonly Text _text = new Text(TestingText);
        private readonly BoldText _boldText = new BoldText(TestingBoldText);
        private string _expectedExportedContent;

        private void Setup()
        {
            _document = new Document();
            _documentExporter = new MarkdownExporter();
            _tags = _documentExporter.GetTags();
            _expectedExportedContent = string.Empty;
        }

        [Fact]
        public void MarkdownExporter_ShouldExportAnEmptyDocument()
        {
            Setup();
            _expectedExportedContent = $"{_tags.OpeningDocument()}{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }

        [Fact]
        public void MarkdownExporter_ShouldExportADocument_WithAnEmptySection()
        {
            Setup();
            _document.AddDocumentElement(_section);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningSection()}{SectionTitle}" +
                $"{Environment.NewLine}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }

        [Fact]
        public void MarkdownExporter_ShouldExportADocument_WithANestedEmptySection()
        {
            Setup();
            _section.AddDocumentElement(_subSection);
            _document.AddDocumentElement(_section);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningSection()}{SectionTitle}" +
                $"{Environment.NewLine}" +
                $"{_tags.OpeningSubSection()}{NestedSectionTitle}" +
                $"{Environment.NewLine}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }

        [Fact]
        public void MarkdownExporter_ShouldExportADocument_WithAnEmptyParagraph()
        {
            Setup();
            _document.AddDocumentElement(_paragraph);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningParagraph()}{_tags.ClosingParagraph()}" +
                $"{Environment.NewLine}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }

        [Fact]
        public void MarkdownExporter_ShouldExportADocument_WithAText()
        {
            Setup();
            _document.AddDocumentElement(_text);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningText()}{TestingText}{_tags.ClosingText()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }

        [Fact]
        public void MarkdownExporter_ShouldExportADocument_WithABoldText()
        {
            Setup();
            _document.AddDocumentElement(_boldText);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningBoldText()}{TestingBoldText}{_tags.ClosingBoldText()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }

        [Fact]
        public void MarkdownExporter_ShouldExportADocument_WithSectionParagraphTextAndBoldText()
        {
            Setup();
            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_boldText);
            _section.AddDocumentElement(_paragraph);
            _document.AddDocumentElement(_section);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningSection()}{SectionTitle}" +
                $"{Environment.NewLine}" +
                $"{_tags.OpeningParagraph()}" +
                $"{_tags.OpeningText()}{TestingText}{_tags.ClosingText()}" +
                $"{_tags.OpeningBoldText()}{TestingBoldText}{_tags.ClosingBoldText()}" +
                $"{_tags.ClosingParagraph()}" +
                $"{Environment.NewLine}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(_documentExporter);

            Assert.Equal(_expectedExportedContent, _documentExporter.GetExportedContent());
        }
    }
}
