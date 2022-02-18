using FinsitHomeAssigment.Core.Exporter;
using System;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Exporter
{
    public class MediawikiExporterTests : ExporterBaseTest
    {
        private void Setup()
        {
            DocumentExporter = new MediawikiExporter();
            Tags = DocumentExporter.GetTags();
        }

        [Fact]
        public void MediawikiExporter_ShouldExportAnEmptyDocument()
        {
            Setup();
            ExpectedExportedContent = $"{Tags.OpeningDocument()}{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void MediawikiExporter_ShouldExportADocument_WithAnEmptySection()
        {
            Setup();
            Document.AddDocumentElement(Section);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningSection()}{Constant.Section}{Tags.ClosingSection()}" +
                $"{Environment.NewLine}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void MediawikiExporter_ShouldExportADocument_WithANestedEmptySection()
        {
            Setup();
            Section.AddDocumentElement(SubSection);
            Document.AddDocumentElement(Section);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningSection()}{Constant.Section}{Tags.ClosingSection()}" +
                $"{Environment.NewLine}" +
                $"{Tags.OpeningSubSection()}{Constant.SubSection}{Tags.ClosingSubSection()}" +
                $"{Environment.NewLine}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void MediawikiExporter_ShouldExportADocument_WithAnEmptyParagraph()
        {
            Setup();
            Document.AddDocumentElement(Paragraph);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningParagraph()}{Tags.ClosingParagraph()}" +
                $"{Environment.NewLine}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void MediawikiExporter_ShouldExportADocument_WithAText()
        {
            Setup();
            Document.AddDocumentElement(Text);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningText()}{Constant.Text}{Tags.ClosingText()}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void MediawikiExporter_ShouldExportADocument_WithABoldText()
        {
            Setup();
            Document.AddDocumentElement(BoldText);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningBoldText()}{Constant.BoldText}{Tags.ClosingBoldText()}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void MediawikiExporter_ShouldExportADocument_WithSectionParagraphTextAndBoldText()
        {
            Setup();
            Paragraph.AddDocumentElement(Text);
            Paragraph.AddDocumentElement(BoldText);
            Section.AddDocumentElement(Paragraph);
            Document.AddDocumentElement(Section);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningSection()}{Constant.Section}{Tags.ClosingSection()}" +
                $"{Environment.NewLine}" +
                $"{Tags.OpeningParagraph()}" +
                $"{Tags.OpeningText()}{Constant.Text}{Tags.ClosingText()}" +
                $"{Tags.OpeningBoldText()}{Constant.BoldText}{Tags.ClosingBoldText()}" +
                $"{Tags.ClosingParagraph()}" +
                $"{Environment.NewLine}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }
    }
}
