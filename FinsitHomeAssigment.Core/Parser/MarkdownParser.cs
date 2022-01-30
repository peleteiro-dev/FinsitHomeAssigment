using FinsitHomeAssigment.Core.Model;
using System.Collections.Generic;

namespace FinsitHomeAssigment.Core.Parser
{
    public class MarkdownParser
    {
        public bool Parse(List<string> lines, out Document document)
        {
            DocumentElement currentDocumentElement = document = new Document();
            Section section = null;
            var paragraph = new Paragraph();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) && paragraph.DocumentElements.Count == 0)
                {
                    continue;
                }
                else if (string.IsNullOrEmpty(line))
                {
                    currentDocumentElement.AddDocumentElement(paragraph);
                    paragraph = new Paragraph();
                }
                else if (line.StartsWith("# "))
                {
                    currentDocumentElement = section = new Section(line);
                    document.AddDocumentElement(section);
                }
                else if (line.StartsWith("## ") && section == null)
                {
                    // a sub section can not exist before the first section is created
                    return false;
                }
                else if (line.StartsWith("## "))
                {
                    var subSection = new Section(line);
                    currentDocumentElement = subSection;
                    section.AddDocumentElement(subSection);
                }
                else
                {
                    var text = new Text(line);
                    paragraph.AddDocumentElement(text);
                }
            }

            // in case last line was not empty and the last element was a paragraph it wouldn't be added
            if (paragraph.DocumentElements.Count > 0)
            {
                currentDocumentElement.AddDocumentElement(paragraph);
            }

            return true;
        }

        private List<DocumentElement> ConvertLineToTextItems(string line)
        {
            var elements = new List<DocumentElement>();
            if (string.IsNullOrEmpty(line)) return elements;

            if(!line.Contains("**"))
            {
                elements.Add(new Text(line));
                return elements;
            }

            var index = line.IndexOf("**");
            
            if (index != 0)
                elements.Add(new Text(line.Substring(0, index)));
            do
            {
                var first = index;
                var last = line.IndexOf("**", first);

            } while (index != -1);


            return elements;
        }
    }
}
