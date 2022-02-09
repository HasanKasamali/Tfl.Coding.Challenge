using Xunit;
using Moq;
using Tfl.Coding.Challenge.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Tfl.Coding.Challenge.Tests
{
    public class ServiceTests
    {
        private readonly Mock<ITflApi> _tflApi;
        private readonly Mock<IConfiguration> _config;

        public ServiceTests()
        {
            _config = new Mock<IConfiguration>();
            _config.SetupGet(x => x[It.Is<string>(s => s == "BaseUrl")]).Returns("https://api.tfl.gov.uk/");
            _config.SetupGet(x => x[It.Is<string>(s => s == "AppId")]).Returns("your app id");
            _config.SetupGet(x => x[It.Is<string>(s => s == "AppKey")]).Returns("your app key");

            _tflApi = new Mock<ITflApi>();

            var roadStatusModel = new RoadStatusModel { Id = "A6", SuccessCode = "NOTFOUND" };
            _tflApi.Setup(x => x.Status(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(roadStatusModel));
        }

        [Fact]
        public void When_Valid_Road_Should_Return_Success ()
        {

            // Arrange

            // Act
            var actual = _tflApi.Object.Status("A6", default).Result;

            // Assert
            Assert.True(actual.Id == "A6");
            Assert.True(actual.SuccessCode== "NOTFOUND");
            _tflApi.Verify(c => c.Status(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());

        }
    }
}
