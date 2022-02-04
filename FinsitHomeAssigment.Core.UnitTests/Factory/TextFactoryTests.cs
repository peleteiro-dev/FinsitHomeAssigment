using FinsitHomeAssigment.Core.Factory;
using FinsitHomeAssigment.Core.Model;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests.Factory
{
    public  class TextFactoryTests
    {
        private readonly IDocumentElementFactory _factory = new TextFactory();
        
        [Theory]
        [InlineData("any text")]
        public void WhenAnyValueIsProvided_Create_ShouldReturnText(string content)
        {
            var documentElement = _factory.Create(content);

            Assert.True(documentElement is Text);
            var text = (Text)documentElement;
            Assert.True(text.Content == content);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenAnyNullOrEmptyIsProvided_Create_ShouldReturnNull(string content)
        {
            var documentElement = _factory.Create(content);

            Assert.Null(documentElement);
        }
    }
}
