using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Exporter
{
    public class HtmlExporterTests
    {
        private readonly HtmlConstants _constants = new HtmlConstants();
        private const string SectionTitle = "section";
        private const string NestedSectionTitle = "nested section";
        private const string TestingText = "testing";

        [Fact]
        public void HtmlExporter_ShouldExportAnEmptyDocument()
        {
            var document = new Document();
            var expectedExportedContent = $"{_constants.OpeningDocument}{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithAnEmptySection()
        {
            var document = new Document();
            document.AddDocumentElement(new Section(SectionTitle));
            var expectedExportedContent =
                $"{_constants.OpeningDocument}" +
                $"{_constants.OpeningSection}{SectionTitle}{_constants.ClosingSection}" +
                $"{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithANestedEmptySection()
        {
            var document = new Document();
            var section = new Section(SectionTitle);
            section.AddDocumentElement(new Section(NestedSectionTitle));
            document.AddDocumentElement(section);
            var expectedExportedContent =
                $"{_constants.OpeningDocument}" +
                $"{_constants.OpeningSection}{SectionTitle}" +
                $"{_constants.OpeningSection}{NestedSectionTitle}{_constants.ClosingSection}" +
                $"{_constants.ClosingSection}" +
                $"{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithAnEmptyParagraph()
        {
            var document = new Document();
            document.AddDocumentElement(new Paragraph());
            var expectedExportedContent =
                $"{_constants.OpeningDocument}" +
                $"{_constants.OpeningParagraph}{_constants.ClosingParagraph}" +
                $"{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithAText()
        {
            var document = new Document();
            document.AddDocumentElement(new Text(TestingText));
            var expectedExportedContent =
                $"{_constants.OpeningDocument}" +
                $"{_constants.OpeningText}{TestingText}{_constants.ClosingText}" +
                $"{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithABoldText()
        {
            var document = new Document();
            document.AddDocumentElement(new BoldText(TestingText));
            var expectedExportedContent =
                $"{_constants.OpeningDocument}" +
                $"{_constants.OpeningBoldText}{TestingText}{_constants.ClosingBoldText}" +
                $"{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }

        [Fact]
        public void HtmlExporter_ShouldExportADocument_WithSectionParagraphTextAndBoldText()
        {
            var document = new Document();
            var paragraph = new Paragraph();
            paragraph.AddDocumentElement(new Text(TestingText));
            paragraph.AddDocumentElement(new BoldText(TestingText));
            var section = new Section(SectionTitle);
            section.AddDocumentElement(paragraph);
            document.AddDocumentElement(section);
            var expectedExportedContent =
                $"{_constants.OpeningDocument}" +
                $"{_constants.OpeningSection}{SectionTitle}" +
                $"{_constants.OpeningParagraph}" +
                $"{_constants.OpeningText}{TestingText}{_constants.ClosingText}" +
                $"{_constants.OpeningBoldText}{TestingText}{_constants.ClosingBoldText}" +
                $"{_constants.ClosingParagraph}" +
                $"{_constants.ClosingSection}" +
                $"{_constants.ClosingDocument}";

            document.Acept(new HtmlExporter(_constants));

            Assert.Equal(expectedExportedContent, document.ExportedContent);
        }
    }
}
