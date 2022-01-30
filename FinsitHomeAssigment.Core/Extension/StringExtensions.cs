using FinsitHomeAssigment.Core.Model;

namespace FinsitHomeAssigment.Core.Extension
{
    public static class StringExtensions
    {
        public static DocumentType ToDocumentElementType(this string line)
        {
            DocumentType documentType;

            if (line.StartsWith("# "))
            {
                documentType = DocumentType.Section;
            }
            else if (line.StartsWith("## "))
            {
                documentType = DocumentType.SubSection;
            }
            else if (string.IsNullOrEmpty(line))
            {
                documentType = DocumentType.Paragraph;
            }
            else
            {
                documentType = DocumentType.Text;
            }

            return documentType;
        }
    }
}
