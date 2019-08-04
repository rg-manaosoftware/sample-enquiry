using Sample.Enquiry.Api;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Enquiry.Tests.Integration.Web
{
    public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerIndex(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsViewWithCorrectMessage()
        {
            HttpResponseMessage response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("Sample.Enquiry.Api", stringResponse);
        }
    }
}
