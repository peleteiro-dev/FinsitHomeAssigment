using FinsitHomeAssigment.Core.Exporter;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Exporter
{
    public class HtmlExporterTests : ExporterBaseTest
    {
        private void Setup()
        {
            DocumentExporter = new HtmlExporter();
            Tags = DocumentExporter.GetTags();
        }

        [Fact]
        public void HtmlExporter_ShouldExportAnEmptyDocument()
        {
            Setup();
            ExpectedExportedContent = $"{Tags.OpeningDocument()}{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithAnEmptySection()
        {
            Setup();
            Document.AddDocumentElement(Section);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningSection()}{Constant.Section}{Tags.ClosingSection()}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithANestedEmptySection()
        {
            Setup();
            Section.AddDocumentElement(SubSection);
            Document.AddDocumentElement(Section);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningSection()}{Constant.Section}" +
                $"{Tags.OpeningSubSection()}{Constant.SubSection}{Tags.ClosingSubSection()}" +
                $"{Tags.ClosingSection()}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithAnEmptyParagraph()
        {
            Setup();
            Document.AddDocumentElement(Paragraph);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningParagraph()}{Tags.ClosingParagraph()}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithAText()
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
        public void HtmlExporter_ShouldExportADocument_WithABoldText()
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
        public void HtmlExporter_ShouldExportADocument_WithSectionParagraphTextAndBoldText()
        {
            Setup();
            Paragraph.AddDocumentElement(Text);
            Paragraph.AddDocumentElement(BoldText);
            Section.AddDocumentElement(Paragraph);
            Document.AddDocumentElement(Section);
            ExpectedExportedContent =
                $"{Tags.OpeningDocument()}" +
                $"{Tags.OpeningSection()}{Constant.Section}" +
                $"{Tags.OpeningParagraph()}" +
                $"{Tags.OpeningText()}{Constant.Text}{Tags.ClosingText()}" +
                $"{Tags.OpeningBoldText()}{Constant.BoldText}{Tags.ClosingBoldText()}" +
                $"{Tags.ClosingParagraph()}" +
                $"{Tags.ClosingSection()}" +
                $"{Tags.ClosingDocument()}";

            Document.Accept(DocumentExporter);

            Assert.Equal(ExpectedExportedContent, DocumentExporter.GetExportedContent());
        }
    }
}
