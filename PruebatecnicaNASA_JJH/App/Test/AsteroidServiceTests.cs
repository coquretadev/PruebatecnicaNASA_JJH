using AutoFixture;
using Moq;
using Newtonsoft.Json;
using PruebatecnicaNASA_JJH.App.Dto;
using PruebatecnicaNASA_JJH.App.Services;
using System.ComponentModel.Design;
using System.Net;
using Xunit;

namespace PruebatecnicaNASA_JJH.App.Test
{
    public class AsteroidServiceTests
    {
        //private readonly IConfiguration _configuration;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IAsteroidService> _asteroidServiceMock;

        public AsteroidServiceTests()
        {
            _asteroidServiceMock = new Mock<IAsteroidService>();
            _configuration = new Mock<IConfiguration>();
        }

        [Fact]
        public async Task ShouldGetAsteroidsAsync()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            _configuration.Setup(x => x["AppSettingsNasa:api_url"]).Returns("https://api.nasa.gov/neo/rest/v1/feed");
            _configuration.Setup(x => x["AppSettingsNasa:api_key"]).Returns("zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb");

            var httpServiceMock = new Mock<IHttppService>();
            httpServiceMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(GetApiNasaResponse())
            });

            //var asteroidService = new AsteroidService(httpServiceMock.Object, configurationMock.Object);
            var asteroidService = new AsteroidService(httpServiceMock.Object, _configuration.Object);

            // Act
            var result = await asteroidService.GetAsteroidsAsync(3);

            // Assert
        }

        private string GetApiNasaResponse()
        {
            var fixture = new Fixture();
            var date = DateTime.Now.Date;

            var sampleData = new
            {
                NearEarthObjects = new Dictionary<string, List<AsteroidDto>>
                {
                    {
                        date.ToString(), new List<AsteroidDto>
                        {
                            new AsteroidDto
                            {
                                Id = fixture.Create<string>(),
                                Name = fixture.Create<string>(),
                                IsPotentiallyHazardousAsteroid = fixture.Create<bool>(),
                                EstimatedDiameter = new EstimatedDiameterDto
                                {
                                    Kilometers = new DiameterRangeDto
                                    {
                                        EstimatedDiameterMin = fixture.Create<double>(),
                                        EstimatedDiameterMax = fixture.Create<double>()
                                    }
                                },
                                CloseApproachData = new List<CloseApproachDataDto>
                                {
                                    new CloseApproachDataDto
                                    {
                                        CloseApproachDate = DateTime.Now,
                                        RelativeVelocity = new RelativeVelocityDto
                                        {
                                            KilometersPerHour = fixture.Create<int>(),
                                        },
                                        OrbitingBody = fixture.Create<string>()
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(sampleData);
        }
    }
}
