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
            var lineToSplit = $"{Constant.Text}**{Constant.BoldText}**{Constant.Text}";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { Constant.Text, $"**{Constant.BoldText}", Constant.Text};

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanContainSeveralDelimitedStrings()
        {
            var lineToSplit = $"{Constant.Text}**{Constant.BoldText}** **{Constant.BoldText}**{Constant.Text}";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { Constant.Text, $"**{Constant.BoldText}", " ", $"**{Constant.BoldText}", Constant.Text};

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanStartWithDelimitedString()
        {
            var lineToSplit = $"**{Constant.BoldText}**{Constant.Text}";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { $"**{Constant.BoldText}", Constant.Text};

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanFinishWithDelimitedString()
        {
            var lineToSplit = $"{Constant.Text}**{Constant.BoldText}**";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { Constant.Text, $"**{Constant.BoldText}" };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void InputCanStartAndFinishWithDelimitedStrings()
        {
            var lineToSplit = $"**{Constant.BoldText}**{Constant.Text}**{Constant.BoldText}**";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { $"**{Constant.BoldText}", { Constant.Text }, $"**{Constant.BoldText}" };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenInputContainsDelimiter_ToListOfTextItems_ShouldReturnExpectedItems()
        {
            var lineToSplit = $"{Constant.Text}**{Constant.BoldText}**{Constant.Text}";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { Constant.Text, $"**{Constant.BoldText}", Constant.Text };

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
            var lineToSplit = $"{Constant.Text}**{Constant.BoldText}";
            var delimiters = new List<string> { "**" };
            var expectedOutput = new List<string> { Constant.Text, $"**{Constant.BoldText}" };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenUsingSeveralDelimiters_ToListOfTextItems_ShouldReturnExpectedItems()
        {
            var lineToSplit = $"++{Constant.Text}++ **{Constant.BoldText}** ##{Constant.Text}## ++{Constant.Text}";
            var delimiters = new List<string> { "**", "++", "##" };
            var expectedOutput = new List<string> { $"++{Constant.Text}", " ", $"**{Constant.BoldText}", " ", $"##{Constant.Text}", " ", $"++{Constant.Text}" };

            var splitLine = lineToSplit.ToListOfTextItems(delimiters);

            var equal = expectedOutput.SequenceEqual(splitLine);
            Assert.True((equal));
        }

        [Fact]
        public void WhenDelimitersIsEmpty_ToListOfTextItems_ShouldReturnInput()
        {
            var lineToSplit = $"++{Constant.Text}++ **{Constant.BoldText}** ##{Constant.Text}## ++{Constant.Text}";
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
