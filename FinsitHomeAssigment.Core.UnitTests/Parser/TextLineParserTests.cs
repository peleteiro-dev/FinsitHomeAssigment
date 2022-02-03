using FinsitHomeAssigment.Core.Model;
using FinsitHomeAssigment.Core.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Parser
{
    public class TextLineParserTests
    {
        [Fact]
        public void WhenInputContainsValidDelimiters_Parse_ShouldReturnExpectedOutput()
        {
            const string textLine = "Some **introduction** to Section 1.";
            var expectedOutput = new List<DocumentElement>
            {
                new Text("Some "), 
                new BoldText("introduction"), 
                new Text(" to Section 1.\n")
            };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);

            Assert.True(equal);
        }

        [Fact]
        public void WhenInputContainsOnlyBoldText_Parse_ShouldReturnExpectedOutput()
        {
            const string textLine = "**Some introduction to Section 1.**";
            var expectedOutput = new List<DocumentElement>
            {
                new BoldText("Some introduction to Section 1.\n")
            };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);

            Assert.True(equal);
        }

        [Fact]
        public void WhenInputContainsOnlyText_Parse_ShouldReturnExpectedOutput()
        {
            const string textLine = "Some introduction to Section 1.";
            var expectedOutput = new List<DocumentElement>
            {
                new Text("Some introduction to Section 1.\n")
            };

            var parser = new TextLineParser();
            var documentElements = parser.Parse(textLine);

            var equal = expectedOutput.SequenceEqual(documentElements);

            Assert.True(equal);
        }

        [Fact]
        public void WhenInputDoeNotContainsValidDelimiters_Parse_ShouldReturnExpectedOutput()
        {
            const string textLine = "Some ++introduction++ to Section 1.";
            var expectedOutput = new List<DocumentElement>
            {
                new Text("Some ++introduction++ to Section 1.\n")
            };

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
