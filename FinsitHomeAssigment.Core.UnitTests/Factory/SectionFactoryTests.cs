using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Factory
{
    public class SectionFactoryTests
    {
        private readonly IDocumentElementFactory _factory = new SectionFactory();

        [Fact]
        public void WhenValueProvidedStartsWithFactoryDelimiter_Create_ShouldReturnSection()
        {
            const string title = "any text";
            var validTitle = $"{_factory.Delimiter}any text";

            var documentElement = _factory.Create(validTitle);

            Assert.True(documentElement is Section);
            var section = (Section)documentElement;
            Assert.True(section.Title == title);
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
