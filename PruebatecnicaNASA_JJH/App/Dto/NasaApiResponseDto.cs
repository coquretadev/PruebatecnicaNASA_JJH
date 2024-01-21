using Newtonsoft.Json;

namespace PruebatecnicaNASA_JJH.App.Dto
{
    public class NasaApiResponseDto
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, List<AsteroidDto>> NearEarthObjects { get; set; }
    }
}
