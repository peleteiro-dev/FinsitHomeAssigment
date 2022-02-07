using FinsitHomeAssigment.Core.Util;
using Xunit;

namespace FinsitHomeAssigment.Core.UnitTests
{
    public class MarkdownConverterTests
    {
        private MarkdownConverter _markdownConverter;
        private string _requiredCaseFilePath;
        private string _requiredCaseFileContent;
        private string _expectedMediawikiFileContent;
        private string _expectedHtmlFileContent;
        private string _nonExistentFilePath;
        private string _wrongExtensionFilePath;
        private const string EmptyHtmlDocument = "<html><head></head><body></body></html>";
        private const string FileNotFound = "File  not found.";

        private void Setup()
        {
            _markdownConverter = new MarkdownConverter();
            var directory = FileUtils.GetAssemblyDir();

            _requiredCaseFilePath = FileUtils.JoinPaths(directory, "Files/RequiredCase.md");
            _requiredCaseFileContent = FileUtils.ReadFileAsString(_requiredCaseFilePath);

            var expectedMediawikiFilePath = FileUtils.JoinPaths(directory, "Files/MediawikiRequiredCase.txt");
            _expectedMediawikiFileContent = FileUtils.ReadFileAsString(expectedMediawikiFilePath);

            var expectedHtmlFilePath  = FileUtils.JoinPaths(directory, "Files/HtmlRequiredCase.txt");
            _expectedHtmlFileContent = FileUtils.ReadFileAsString(expectedHtmlFilePath);

            _nonExistentFilePath = FileUtils.JoinPaths(directory, "Files/NonExistent.md");
            _wrongExtensionFilePath = FileUtils.JoinPaths(directory, "Files/HtmlRequiredCase.txt");
        }

        [Fact]
        public void FromFileToMarkdown_ShouldReturnFileEqualToSource()
        {
            Setup();

            var converted= _markdownConverter.FromFileToMarkdown(_requiredCaseFilePath);

            Assert.Equal(_requiredCaseFileContent, converted);
        }

        [Fact]
        public void FromFileToMediawiki_ShouldReturnExpectedFileContent()
        {
            Setup();

            var converted = _markdownConverter.FromFileToMediawiki(_requiredCaseFilePath);

            Assert.Equal(_expectedMediawikiFileContent, converted);
        }

        [Fact]
        public void FromFileToHtml_ShouldReturnExpectedFileContent()
        {
            Setup();

            var converted = _markdownConverter.FromFileToHtml(_requiredCaseFilePath);

            Assert.Equal(_expectedHtmlFileContent, converted);
        }

        [Fact]
        public void WhenPathDoesNotExist_FromFileToMarkdown_ShouldReturnErrorMessageContainingPath()
        {
            Setup();

            var converted = _markdownConverter.FromFileToMarkdown(_nonExistentFilePath);

            Assert.Contains(_nonExistentFilePath, converted);
        }

        [Fact]
        public void WhenPathDoesNotExist_FromFileToMediawiki_ShouldReturnErrorMessageContainingPath()
        {
            Setup();

            var converted = _markdownConverter.FromFileToMediawiki(_nonExistentFilePath);

            Assert.Contains(_nonExistentFilePath, converted);
        }

        [Fact]
        public void WhenPathDoesNotExist_FromFileToHtml_ShouldReturnErrorMessageContainingPath()
        {
            Setup();

            var converted = _markdownConverter.FromFileToHtml(_nonExistentFilePath);

            Assert.Contains(_nonExistentFilePath, converted);
        }

        [Fact]
        public void WhenInvalidExtension_FromFileToMarkdown_ShouldReturnErrorMessage()
        {
            Setup();

            var converted = _markdownConverter.FromFileToMarkdown(_wrongExtensionFilePath);

            Assert.Contains("txt", converted);
        }

        [Fact]
        public void WhenInvalidExtension_FromFileToMediawiki_ShouldReturnErrorMessage()
        {
            Setup();

            var converted = _markdownConverter.FromFileToMediawiki(_wrongExtensionFilePath);

            Assert.Contains("txt", converted);
        }
        [Fact]
        public void WhenInvalidExtension_FromFileToHtml_ShouldReturnErrorMessage()
        {
            Setup();

            var converted = _markdownConverter.FromFileToHtml(_wrongExtensionFilePath);

            Assert.Contains("txt", converted);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFromFileToMarkdown_ReceivesEmptyOrNullString_ShouldReturnFileNotFound(string input)
        {
            Setup();

            var converted = _markdownConverter.FromFileToMarkdown(input);

            Assert.Equal(FileNotFound, converted);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFromFileToMediawikii_ReceivesEmptyOrNullString_ShouldReturnEmptyString(string input)
        {
            Setup();

            var converted = _markdownConverter.FromFileToMediawiki(input);

            Assert.Equal(FileNotFound, converted);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFromFileToHtml_ReceivesEmptyOrNullString_ShouldReturnEmptyString(string input)
        {
            Setup();

            var converted = _markdownConverter.FromFileToHtml(input);

            Assert.Equal(FileNotFound, converted);
        }

        [Fact]
        public void FromStringToMarkdown_ShouldReturnFileEqualToSource()
        {
            Setup();

            var converted = _markdownConverter.FromStringToMarkdown(_requiredCaseFileContent);

            Assert.Equal(_requiredCaseFileContent, converted);
        }

        [Fact]
        public void FromStringToMediawiki_ShouldReturnExpectedFileContent()
        {
            Setup();

            var converted = _markdownConverter.FromStringToMediawiki(_requiredCaseFileContent);

            Assert.Equal(_expectedMediawikiFileContent, converted);
        }

        [Fact]
        public void FromStringToHtml_ShouldReturnExpectedFileContent()
        {
            Setup();

            var converted = _markdownConverter.FromStringToHtml(_requiredCaseFileContent);

            Assert.Equal(_expectedHtmlFileContent, converted);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFromStringToMarkdown_ReceivesEmptyOrNullString_ShouldReturnEmptyString(string input)
        {
            Setup();

            var converted = _markdownConverter.FromStringToMarkdown(input);

            Assert.Equal(string.Empty, converted);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFromStringToMediawiki_ReceivesEmptyOrNullString_ShouldReturnEmptyString(string input)
        {
            Setup();

            var converted = _markdownConverter.FromStringToMediawiki(input);

            Assert.Equal(string.Empty, converted);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFromStringToHtml_ReceivesEmptyOrNullString_ShouldReturnEmptyString(string input)
        {
            Setup();

            var converted = _markdownConverter.FromStringToHtml(input);

            Assert.Equal(EmptyHtmlDocument, converted);
        }
    }
}
