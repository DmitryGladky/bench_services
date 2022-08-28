using System;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Talabat.ServiceBench.External;
using Xunit;

namespace Talabat.ServiceBench.Controllers
{
    public class ExampleControllerTest
    {
        private readonly ExampleController exampleController;
        private readonly DateTime dateTime;
        private readonly Mock<IExternalServiceClient> externalService;

        public ExampleControllerTest()
        {
            var config = new Mock<IConfiguration>();
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            var mockHttpResponse = new Mock<HttpContext>().Object;
            httpContextAccessor.Setup(x => x.HttpContext).Returns(mockHttpResponse);
            var mediator = new Mock<IMediator>().Object;
            var logger = new Mock<ILogger<ExampleController>>().Object;
            externalService = new Mock<IExternalServiceClient>();

            exampleController = new ExampleController(config.Object, httpContextAccessor.Object, mediator, logger, externalService.Object);
            dateTime = new DateTime(2022, 1, 1);
        }

        [Fact]
        public async Task RelayMessageAsync_With_Date_And_Message_Throws_Exception_For_Mock_Url()
        {
            const int adviceId = 1;
            externalService.Setup(s => s.Advice(It.IsAny<int>())).Throws(new HttpRequestException());

            await Assert.ThrowsAsync<HttpRequestException>(() => Task.FromResult(exampleController.RelayMessageAsync(adviceId)));
        }

        [Fact]
        public async void GetCart_With_Id_Returns_Null_Response_For_Mock_Url() => Assert.Null(await exampleController.GetCart("1234"));

    }
}
