using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using NextPermutation.Service;

namespace TestNextPermutation
{
    public class IntegTestPermutationApp : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly WebApplicationFactory<Startup> factory;
        public IntegTestPermutationApp(WebApplicationFactory<Startup> _factory)
        {
            factory = _factory;
        }

        [Theory]
        [InlineData(new int[] { 1000, 0, 0, 0, 0 }, "BadRequest")]
        [InlineData(new int[] { -10, 0, 0, 0, 0 }, "BadRequest")]
        [InlineData(new int[] { 1, 0, 0, 0, 0 }, "OK")]
        [InlineData(null, "BadRequest")]
        public async void TestNextPermutation(int[] body, string statuscode)
        {
            string url = "/permutation/next";
            var client = factory.CreateClient();
            var req = JsonContent.Create<int[]>(body);

            var response = await client.PostAsync(url, req);

            Assert.Equal(statuscode.ToString(), response.StatusCode.ToString());
        }
    }
}
