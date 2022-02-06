using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Exporter
{
    public class DocumentExporterTests
    {
        private const string SectionTitle = "section title";
        private const string NestedSectionTitle = "nested section title";
        private const string TestingText = "testing text";
        private const string TestingBoldText = "testing bold";

        private Document _document;
        private IDocumentTags _tags;
        private readonly Section _section = new Section(SectionTitle);
        private readonly SubSection _subSection = new SubSection(NestedSectionTitle);
        private readonly Paragraph _paragraph = new Paragraph();
        private readonly Text _text = new Text(TestingText);
        private readonly BoldText _boldText = new BoldText(TestingBoldText);
        private string _expectedExportedContent;

        private void Setup(IDocumentExporter documentExporter)
        {
            _document = new Document();
            _tags = documentExporter.GetTags();
            _expectedExportedContent = string.Empty;
        }

        public static IEnumerable<object[]> DocumentExporters => new List<object[]>
        {
            new object[] { new DocumentExporter(new HtmlTags()) },
            new object[] { new DocumentExporter(new MarkdownTags()) }
        };

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportAnEmptyDocument(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);
            
            _expectedExportedContent = $"{_tags.OpeningDocument()}{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportADocument_WithAnEmptySection(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);

            _document.AddDocumentElement(_section);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningSection()}{SectionTitle}{_tags.SectionSeparator()}{_tags.ClosingSection()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportADocument_WithANestedEmptySection(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);

            _section.AddDocumentElement(_subSection);
            _document.AddDocumentElement(_section);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningSection()}{SectionTitle}{_tags.SectionSeparator()}" +
                $"{_tags.OpeningSubSection()}{NestedSectionTitle}{_tags.SubSectionSeparator()}{_tags.ClosingSubSection()}" +
                $"{_tags.ClosingSection()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportADocument_WithAnEmptyParagraph(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);
            _document.AddDocumentElement(_paragraph);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningParagraph()}{_tags.ClosingParagraph()}" +
                $"{_tags.ParagraphSeparator()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportADocument_WithAText(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);
            _document.AddDocumentElement(_text);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningText()}{TestingText}{_tags.ClosingText()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportADocument_WithABoldText(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);
            _document.AddDocumentElement(_boldText);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningBoldText()}{TestingBoldText}{_tags.ClosingBoldText()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }

        [Theory]
        [MemberData(nameof(DocumentExporters))]
        public void HtmlExporter_ShouldExportADocument_WithSectionParagraphTextAndBoldText(IDocumentExporter documentExporter)
        {
            Setup(documentExporter);
            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_boldText);
            _section.AddDocumentElement(_paragraph);
            _document.AddDocumentElement(_section);
            _expectedExportedContent =
                $"{_tags.OpeningDocument()}" +
                $"{_tags.OpeningSection()}{SectionTitle}{_tags.SectionSeparator()}" +
                $"{_tags.OpeningParagraph()}" +
                $"{_tags.OpeningText()}{TestingText}{_tags.ClosingText()}" +
                $"{_tags.OpeningBoldText()}{TestingBoldText}{_tags.ClosingBoldText()}" +
                $"{_tags.ClosingParagraph()}{_tags.ParagraphSeparator()}" +
                $"{_tags.ClosingSection()}" +
                $"{_tags.ClosingDocument()}";

            _document.Accept(documentExporter);

            Assert.Equal(_expectedExportedContent, _document.ExportedContent);
        }
    }
}
