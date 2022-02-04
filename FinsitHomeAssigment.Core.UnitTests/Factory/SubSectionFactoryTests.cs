using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Factory
{
    public class SubSectionFactoryTests
    {
        private readonly IDocumentElementFactory _factory = new SubSectionFactory();

        [Fact]
        public void WhenValueProvidedStartsWithFactoryDelimiter_Create_ShouldReturnSubSection()
        {
            const string title = "any text";
            var validTitle = $"{_factory.Delimiter}any text";

            var documentElement = _factory.Create(validTitle);

            Assert.True(documentElement is SubSection);
            var subSection = (SubSection)documentElement;
            Assert.True(subSection.Title == title);
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
