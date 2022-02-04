using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Factory
{
    public class BodTextFactoryTests
    {
        private readonly IDocumentElementFactory _factory = new BoldTextFactory();

        [Fact]
        public void WhenValueProvidedStartsWithFactoryDelimiter_Create_ShouldReturnBoldText()
        {
            const string content = "any text";
            var validContent = $"{_factory.Delimiter}any text";

            var documentElement = _factory.Create(validContent);

            Assert.True(documentElement is BoldText);
            var boldText = (BoldText)documentElement;
            Assert.True(boldText.Content == content);
        }

        [Theory]
        [InlineData("any text")]
        [InlineData(null)]
        [InlineData("")]
        public void WhenValueDoesNotStartWithFactoryDelimiter_Create_ShouldReturnNull(string content)
        {
            var documentElement = _factory.Create(content);

            Assert.Null(documentElement);
        }
    }
}
