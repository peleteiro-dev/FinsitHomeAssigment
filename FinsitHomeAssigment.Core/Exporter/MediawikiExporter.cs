using System;
using FinsitHomeAssigment.Core.Model;
using System.Linq;

namespace FinsitHomeAssigment.Core.Exporter
{
    public class MediawikiExporter : IDocumentExporter
    {
        private readonly IDocumentTags _tags = new MediawikiTags();

        public IDocumentTags GetTags() => _tags;

        public void Export(Document document)
        {
            var exportedContent = _tags.OpeningDocument();
            exportedContent += GetChildrenContent(document);
            exportedContent += _tags.ClosingDocument();

            document.ExportedContent = exportedContent;
        }

        public void Export(Section section)
        {
            var exportedContent = _tags.OpeningSection();
            exportedContent += BuildTitle(section.Title, _tags.ClosingSection());
            exportedContent += _tags.SectionSeparator();
            exportedContent += GetChildrenContent(section);

            section.ExportedContent = exportedContent;
        }

        public void Export(SubSection subSection)
        {
            var exportedContent = _tags.OpeningSubSection();
            exportedContent += BuildTitle(subSection.Title, _tags.ClosingSubSection()); ;
            exportedContent += _tags.SubSectionSeparator();
            exportedContent += GetChildrenContent(subSection);

            subSection.ExportedContent = exportedContent;
        }

        public void Export(Paragraph paragraph)
        {
            var exportedContent = _tags.OpeningParagraph();
            exportedContent += GetChildrenContent(paragraph);
            exportedContent += _tags.ClosingParagraph();
            exportedContent += _tags.ParagraphSeparator();

            paragraph.ExportedContent = exportedContent;
        }

        private static string GetChildrenContent(DocumentElement parent)
        {
            var childrenContent = string.Empty;
            childrenContent = parent.DocumentElements.Aggregate(childrenContent,
                            (current, documentElement) => current + documentElement.ExportedContent);

            return childrenContent;
        }

        public void Export(Text text)
        {
            text.ExportedContent = $"{_tags.OpeningText()}{text.Content}{_tags.ClosingText()}";
        }

        public void Export(BoldText boldText)
        {
            boldText.ExportedContent = $"{_tags.OpeningBoldText()}{boldText.Content}{_tags.ClosingBoldText()}";
        }

        private static string BuildTitle(string title, string closingTag)
        {
            return title.Contains(Environment.NewLine)
                ? title.Replace(Environment.NewLine, $"{closingTag}{Environment.NewLine}")
                : $"{title}{closingTag}";
        }
    }
}
