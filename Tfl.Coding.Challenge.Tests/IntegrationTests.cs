using Xunit;
using Moq;
using Tfl.Coding.Challenge.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Tfl.Coding.Challenge.Tests
{
    public class IntegrationTests
    {
        private readonly TflApi _sut;
        private readonly Mock<IConfiguration> _config;

        public IntegrationTests()
        {
            _config = new Mock<IConfiguration>();
            _config.SetupGet(x => x[It.Is<string>(s => s == "BaseUrl")]).Returns("https://api.tfl.gov.uk/");
            _config.SetupGet(x => x[It.Is<string>(s => s == "AppId")]).Returns("put your app id from you TFL portal");
            _config.SetupGet(x => x[It.Is<string>(s => s == "AppKey")]).Returns("put your api key from your TFL portal");

            _sut = new TflApi(_config.Object);
        }

        [Fact]
        public void When_Valid_Road_Return_Success ()
        {
            // Arrange

            // Act
            var actual = _sut.Status("A10", default).Result;

            // Assert
            Assert.True(actual.Id == "a10");
            Assert.True(actual.SuccessCode == "OK");
            Assert.True(actual.Url != null);
        }

        [Fact]
        public void When_InValid_Road_Return_Success()
        {
            // Arrange

            // Act
            var actual = _sut.Status("A6", default).Result;

            // Assert
            Assert.True(actual.SuccessCode != "OK");
            Assert.True(actual.Url == null);
        }
    }
}
