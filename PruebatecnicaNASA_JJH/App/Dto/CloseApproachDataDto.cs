using Newtonsoft.Json;

namespace PruebatecnicaNASA_JJH.App.Dto
{
    public class CloseApproachDataDto
    {
        [JsonProperty("relative_velocity")]
        public RelativeVelocityDto RelativeVelocity { get; set; }

        [JsonProperty("close_approach_date")]
        public DateTime CloseApproachDate { get; set; }

        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
    }
}
