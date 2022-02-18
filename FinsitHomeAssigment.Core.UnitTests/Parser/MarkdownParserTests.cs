using FinsitHomeAssigment.Core.Model;
using FinsitHomeAssigment.Core.Parser;
using FinsitHomeAssigment.Core.Util;
using System.Collections.Generic;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Parser
{
    public class MarkdownParserTests
    {
        private IEnumerable<string> _textToParse;
        private MarkdownParser _markdownParser;
        private Document _expectedOutput;
        private Section _section;
        private SubSection _subSection;
        private SubSection _nestedSubsection;
        private Paragraph _paragraph;
        private readonly Text _text = new Text("text");
        private readonly BoldText _boldText = new BoldText("bold text");

        private void Setup(string testCaseFile)
        {
            var dir = FileUtils.GetAssemblyDir();
            var filePath = FileUtils.JoinPaths(dir, @$"\Files\{testCaseFile}");
            _textToParse = FileUtils.ReadFileAsLines(filePath);

            _markdownParser = new MarkdownParser();

            _expectedOutput = new Document();
            _section = new Section("section");
            _subSection = new SubSection("subsection");
            _nestedSubsection = new SubSection("nested subsection");
            _paragraph = new Paragraph();
        }

        [Fact]
        public void ParseEmptyFileTest()
        {
            const string testCaseFile = "EmptyFile.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseEmptySectionTest()
        {
            const string testCaseFile = "EmptySection.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseOnlySubsectionTest()
        {
            const string testCaseFile = "OnlySubsection.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_subSection);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseEmptySectionAndSubSectionTest()
        {
            const string testCaseFile = "EmptySectionAndSubSection.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section);
            _section.AddDocumentElement(_subSection);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseParagraphWithTextAndBoldTextTest()
        {
            const string testCaseFile = "ParagraphWithTextAndBoldText.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_paragraph);
            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_boldText);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseMultilineParagraphTest()
        {
            const string testCaseFile = "MultilineParagraph.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_paragraph);
            _paragraph.AddDocumentElement(_text);
            _paragraph.AddDocumentElement(_text);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseOneSectionAndOneLineParagraphTest()
        {
            const string testCaseFile = "OneSectionAndOneLineParagraph.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section);
            _section.AddDocumentElement(_paragraph);
            _paragraph.AddDocumentElement(_text);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }

        [Fact]
        public void ParseSectionWithNestedSubsectionsTest()
        {
            const string testCaseFile = "SectionWithNestedSubsections.txt";
            Setup(testCaseFile);

            var parsedText = _markdownParser.Parse(_textToParse);

            _expectedOutput.AddDocumentElement(_section);
            _section.AddDocumentElement(_subSection);
            _subSection.AddDocumentElement(_nestedSubsection);
            var equal = _expectedOutput.Equals(parsedText);
            Assert.True(equal);
        }
    }
}
