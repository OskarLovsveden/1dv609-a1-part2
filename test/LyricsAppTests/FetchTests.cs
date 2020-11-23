using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Model.DAL;
using Moq;
using Moq.Protected;
using Xunit;

public class FetchTests
{
    [Fact]
    public async Task GetAsync_GetAsyncRequest_ReturnsResponse()
    {
        Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();

        mockHandler.Protected()
                  .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                  .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
        Fetch sut = new Fetch(new HttpClient(mockHandler.Object));
        string testUrl = "http://www.test.com/";

        HttpResponseMessage response = await sut.GetAsync(testUrl);
        HttpStatusCode actual = response.StatusCode;
        HttpStatusCode expected = HttpStatusCode.OK;

        Assert.Equal(expected, actual);
    }
}