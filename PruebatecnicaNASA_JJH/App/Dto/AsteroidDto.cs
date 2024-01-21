using Newtonsoft.Json;

namespace PruebatecnicaNASA_JJH.App.Dto
{
    public class AsteroidDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameterDto EstimatedDiameter { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachDataDto> CloseApproachData { get; set; }
    }
}
