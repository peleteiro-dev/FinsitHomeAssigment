using FinsitHomeAssigment.Core.Model;
using FinsitHomeAssigment.Core.Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Parser
{
    public class TextLineParserTests
    {
        private readonly Text _text = new Text(Constant.Text);
        private readonly BoldText _bold = new BoldText(Constant.BoldText);

        [Fact]
        public void WhenInputContainsValidDelimiters_Parse_ShouldReturnExpectedOutput()
        {
            var textLine = $"{Constant.Text}**{Constant.BoldText}**{Constant.Text}";
            var expectedOutput = new List<DocumentElement> { _text, _bold, _text };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);
            Assert.True(equal);
        }

        [Fact]
        public void WhenInputContainsOnlyBoldText_Parse_ShouldReturnExpectedOutput()
        {
            var textLine = $"**{Constant.BoldText}**";
            var expectedOutput = new List<DocumentElement> { _bold };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);
            Assert.True(equal);
        }

        [Fact]
        public void WhenInputContainsOnlyText_Parse_ShouldReturnExpectedOutput()
        {
            var textLine = Constant.Text;
            var expectedOutput = new List<DocumentElement> { _text };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);
            Assert.True(equal);
        }

        [Fact]
        public void WhenInputDoeNotContainsValidDelimiters_Parse_ShouldReturnExpectedOutput()
        {
            var textLine = $"++{Constant.Text}++";
            var expectedOutput = new List<DocumentElement> { new Text(textLine) };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);
            Assert.True(equal);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenInputIsNullOrEmpty_Parse_ShouldReturnEmptyList(string textLine)
        {
            var expectedOutput = new List<DocumentElement>();

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);
            Assert.True(equal);
        }
    }
}
