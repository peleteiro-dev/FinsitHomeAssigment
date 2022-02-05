using System.Collections.Generic;
using FinsitHomeAssigment.Core.Model;
using FinsitHomeAssigment.Core.Parser;
using FinsitHomeAssigment.Core.Util;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Parser
{
    public class MarkdownParserTests
    {
        private IEnumerable<string> _textToParse;
        private MarkdownParser _markdownParser;
        private Document _expectedOutput;
        private Section _section1;
        private Section _section2;
        private SubSection _subSection1;
        private SubSection _nestedSubsection;
        private Paragraph _paragraph1;
        private Paragraph _paragraph2;
        private Paragraph _paragraph3;
        private Paragraph _subSectionParagraph;
        private Paragraph _section2Paragraph1;
        private Paragraph _section2Paragraph2;
        private Paragraph _nestedSubSectionParagraph;
        private Paragraph _oneLineParagraph;
        private Paragraph _multiLineParagraph;

        private void Setup(string testCaseFile)
        {
            var dir = FileUtils.GetAssemblyDir();
            var filePath = FileUtils.JoinPaths(dir, @$"\Files\{testCaseFile}");
            _textToParse = FileUtils.ReadFile(filePath);

            var textLineParser = new TextLineParser();
            _markdownParser = new MarkdownParser(textLineParser);

            _expectedOutput = new Document();
            _section1 = new Section("Section 1");
            _subSection1 = new SubSection("Section 1.1");
            _nestedSubsection = new SubSection("Nested Subsection 1.1.1");
            _section2 = new Section("Section 2");

            _paragraph1 = new Paragraph();
            _paragraph1.AddDocumentElement(new Text("Some "));
            _paragraph1.AddDocumentElement(new BoldText("(bold) introduction"));
            _paragraph1.AddDocumentElement(new Text(" to Section 1.\n"));

            _paragraph2 = new Paragraph();
            _paragraph2.AddDocumentElement(new Text("A text describing Section 1.1\n"));

            _paragraph3 = new Paragraph();
            _paragraph3.AddDocumentElement(new Text("Some conclusion to Section 1.\n"));

            _subSectionParagraph = new Paragraph();
            _subSectionParagraph.AddDocumentElement(new Text("An introduction to Subsection 1.1.\n"));

            _nestedSubSectionParagraph = new Paragraph();
            _nestedSubSectionParagraph.AddDocumentElement(new Text("An introduction to Nested Subsection 1.1.1.\n"));

            _section2Paragraph1 = new Paragraph();
            _section2Paragraph1.AddDocumentElement(new Text("An introduction to Section 2.\n"));

            _section2Paragraph2 = new Paragraph();
            _section2Paragraph2.AddDocumentElement(new Text("Some conclusion to Section 2.\n"));

            _oneLineParagraph = new Paragraph();
            _oneLineParagraph.AddDocumentElement(new Text("An introduction to Section 1.\n"));

            _multiLineParagraph = new Paragraph();
            _multiLineParagraph.AddDocumentElement(new Text("Some text "));
            _multiLineParagraph.AddDocumentElement(new BoldText("introduction"));
            _multiLineParagraph.AddDocumentElement(new Text(" to "));
            _multiLineParagraph.AddDocumentElement(new BoldText("this paragraph.\n"));
            _multiLineParagraph.AddDocumentElement(new Text("A second line in the same paragraph.\n"));
            _multiLineParagraph.AddDocumentElement(new BoldText("And a third bold line.\n"));
        }

        [Fact]
        public void RequiredCase()
        {
            const string testCaseFile = "RequiredText.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section1);
            _section1.AddDocumentElement(_paragraph1);
            _section1.AddDocumentElement(_subSection1);
            _subSection1.AddDocumentElement(_paragraph2);
            _subSection1.AddDocumentElement(_paragraph3);
            _expectedOutput.AddDocumentElement(_section2);
            _section2.AddDocumentElement(_section2Paragraph1);
            _section2.AddDocumentElement(_section2Paragraph2);

            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void OneSectionAndOneLineParagraph()
        {
            const string testCaseFile = "OneSectionAndOneLineParagraph.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section1);
            _section1.AddDocumentElement(_oneLineParagraph);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void OnlyOneMultilineParagraph()
        {
            const string testCaseFile = "OnlyOneMultilineParagraph.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_multiLineParagraph);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void SectionWithNestedSubsections()
        {
            const string testCaseFile = "SectionWithNestedSubsections.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section1);
            _section1.AddDocumentElement(_oneLineParagraph);
            _section1.AddDocumentElement(_subSection1);
            _subSection1.AddDocumentElement(_subSectionParagraph);
            _subSection1.AddDocumentElement(_nestedSubsection);
            _nestedSubsection.AddDocumentElement(_nestedSubSectionParagraph);
            _expectedOutput.AddDocumentElement(_section2);
            _section2.AddDocumentElement(_section2Paragraph1);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void OnlySubsection()
        {
            const string testCaseFile = "OnlySubsection.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_subSection1);
            _subSection1.AddDocumentElement(_subSectionParagraph);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void EmptyFile()
        {
            const string testCaseFile = "EmptyFile.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }
    }
}
