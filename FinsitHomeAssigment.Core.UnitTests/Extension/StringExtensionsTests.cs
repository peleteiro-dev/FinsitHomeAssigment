using FinsitHomeAssigment.Core.Extension;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Extension
{
    public class StringExtensionsTests
    {
        [Fact]
        public void InputCanContainADelimitedString()
        {
            const string lineToSplit = "Some **(bold) introduction** to Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "Some ", "**(bold) introduction", " to Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanContainSeveralDelimitedStrings()
        {
            const string lineToSplit = "Some **(bold) introduction** **to** Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "Some ", "**(bold) introduction", " ", "**to", " Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanStartWithDelimitedString()
        {
            const string lineToSplit = "**Some** introduction to Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "**Some", " introduction to Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanFinishWithDelimitedString()
        {
            const string lineToSplit = "Some introduction to **Section 1.**";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "Some introduction to ", "**Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanStartAndFinishWithDelimitedStrings()
        {
            const string lineToSplit = "**Some** introduction to **Section 1.**";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "**Some", " introduction to ", "**Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenInputContainsDelimiter_ToListOfTextItems_ShouldReturnExpectedItems()
        {
            const string lineToSplit = "Some **(bold) introduction** to Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "Some ", "**(bold) introduction", " to Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenInputDoesNotContainsDelimiter_ToListOfTextItems_ShouldReturnOneItem()
        {
            const string lineToSplit = "Some ++(bold) introduction++ to Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { $"{lineToSplit}" };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenInputContainsOnlyOneDelimiter_ToListOfTextItems_ShouldReturnOneItem()
        {
            const string lineToSplit = "Some **(bold) introduction to Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "Some ", "**(bold) introduction to Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenInputEndsWithNewLine_ToListOfTextItems_ShouldNotAddIt()
        {
            const string lineToSplit = "Some **(bold) introduction** to Section 1.";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { "Some ", "**(bold) introduction", " to Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenUsingSeveralDelimiters_ToListOfTextItems_ShouldReturnExpectedItems()
        {
            const string lineToSplit = "++Some++ **(bold) introduction** ##to## ++Section 1.++";
            var delimiters = new List<string> { "**", "++", "##" };
            var expectedOutput = new List<string> { "++Some", " ", "**(bold) introduction", " ", "##to", " ", "++Section 1." };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenDelimitersIsEmpty_ToListOfTextItems_ShouldReturnInput()
        {
            const string lineToSplit = "++Some++ **(bold) introduction** ##to## ++Section 1.++";
            var delimiters = new List<string>();
            var expectedOutput = new List<string> { $"{lineToSplit}" };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenInputIsEmpty_ToListOfTextItems_ShouldReturnEmptyList()
        {
            var lineToSplit = string.Empty;
            var delimiters = new List<string>();
            var expectedOutput = new List<string>();

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }
    }
}
