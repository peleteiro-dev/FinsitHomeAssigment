using FinsitHomeAssigment.Core.Exporter;
using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.UnitTests.Exporter
{
    public class ExporterBaseTest
    {
        internal Document Document;
        internal IDocumentTags Tags;
        internal IDocumentExporter DocumentExporter;
        internal readonly Section Section = new Section(Constant.Section);
        internal readonly SubSection SubSection = new SubSection(Constant.SubSection);
        internal readonly Paragraph Paragraph = new Paragraph();
        internal readonly Text Text = new Text(Constant.Text);
        internal readonly BoldText BoldText = new BoldText(Constant.BoldText);
        internal string ExpectedExportedContent;

        public ExporterBaseTest()
        {
            Document = new Document();
            ExpectedExportedContent = string.Empty;
        }
    }
}
