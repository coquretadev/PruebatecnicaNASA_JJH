using Newtonsoft.Json;
using PruebatecnicaNASA_JJH.App.Dto;
using System.ComponentModel.Design;

namespace PruebatecnicaNASA_JJH.App.Services
{
    public class AsteroidService : IAsteroidService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttppService _httpService;
        private IHttppService object1;
        private IConfiguration object2;

        public AsteroidService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AsteroidService(IHttppService object1, IConfiguration object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        public async Task<IEnumerable<AsteroidResponseDto>> GetAsteroidsAsync(int days)
        {
            var result = new List<AsteroidResponseDto>();

            // Calcular fechas
            DateTime startDate = DateTime.Now.Date;
            DateTime endDate = startDate.AddDays(days);

            // Obtener datos de la API de la NASA
            var url = _configuration["AppSettingsNasa:api_url"];
            var key = _configuration["AppSettingsNasa:api_key"];

            string apiUrl = $"{url}?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&api_key={key}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                //HttpResponseMessage response = await _httpService.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la solicitud a la API de la NASA: {response.ReasonPhrase}. StatusCode {(int)response.StatusCode}");
                }

                string jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<NasaApiResponseDto>(jsonContent);

                // Filtrar asteroides potencialmente peligrosos y ordenar por tamaño y Construir respuesta en el formato requerido
                result = data.NearEarthObjects
                    .SelectMany(pair => pair.Value)
                    .Where(asteroid => asteroid.IsPotentiallyHazardousAsteroid)
                    .OrderByDescending(asteroid => asteroid.EstimatedDiameter.Kilometers.EstimatedDiameterMax)
                    .Take(3)
                    .Select(asteroid => new AsteroidResponseDto
                    {
                        //id = asteroid.Id,
                        Name = asteroid.Name,
                        Diameter = (asteroid.EstimatedDiameter.Kilometers.EstimatedDiameterMin + asteroid.EstimatedDiameter.Kilometers.EstimatedDiameterMax) / 2,
                        Velocity = asteroid.CloseApproachData.First().RelativeVelocity.KilometersPerHour,
                        Date = asteroid.CloseApproachData.First().CloseApproachDate,
                        Planet = asteroid.CloseApproachData.First().OrbitingBody
                        //isPotentiallyHazardousAsteroid = asteroid.IsPotentiallyHazardousAsteroid,
                    })
                    .ToList();

                return result;
            }
        }
    }
}
