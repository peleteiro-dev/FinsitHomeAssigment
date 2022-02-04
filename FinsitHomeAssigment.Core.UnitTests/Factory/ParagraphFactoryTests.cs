using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Factory
{
    public class ParagraphFactoryTests
    {
        private readonly IDocumentElementFactory _factory = new ParagraphFactory();

        [Fact]
        public void WhenValueProvidedStartsWithFactoryDelimiter_Create_ShouldReturnParagraph()
        {
            var documentElement = _factory.Create(_factory.Delimiter);

            Assert.True(documentElement is Paragraph);
        }

        [Theory]
        [InlineData("any text")]
        [InlineData(null)]
        public void WhenValueDoesNotStartWithFactoryDelimiter_Create_ShouldReturnNull(string content)
        {
            var documentElement = _factory.Create(content);

            Assert.Null(documentElement);
        }
    }
}
