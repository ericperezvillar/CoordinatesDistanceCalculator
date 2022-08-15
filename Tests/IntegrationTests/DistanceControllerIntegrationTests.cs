using Application.DTOs;
using Application.Wrappers;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi;
using Xunit;

namespace IntegrationTests
{
    public class DistanceControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
	{
		private readonly HttpClient _client;

        public DistanceControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
		public async Task GetDistanceBetweenCoordinates_HappyPath()
		{
			var url = "?firstCoordinate.latitud=10&firstCoordinate.longitud=-10&secondCoordinate.latitud=15&secondCoordinate.longitud=-15&measuringUnit=Kilometres";

			var response = await _client.GetAsync(Path.Combine("api/distance/GetDistanceBetweenCoordinates",url));

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<SuccessResponse<DistanceCalculatorResult>>(responseString);

			Assert.Equal(776.86, result.Data.Distance);
			Assert.True(result.Data.Measure.Name == "Kilometres");
		}

		[Fact]
		public async Task GetDistanceBetweenCoordinates_InvalidResponse_CoordinatesNotValid()
		{
			var url = "?firstCoordinate.latitud=-100&firstCoordinate.longitud=-10&secondCoordinate.latitud=15&secondCoordinate.longitud=-15&measuringUnit=Kilometres";

			var response = await _client.GetAsync(Path.Combine("api/distance/GetDistanceBetweenCoordinates", url));

			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

			var responseString = await response.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<InvalidResponse<DistanceCalculatorResult>>(responseString);

			Assert.False(result.Succeeded);
		}

	}
}
