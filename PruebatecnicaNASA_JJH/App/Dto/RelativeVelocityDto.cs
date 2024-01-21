using Newtonsoft.Json;

namespace PruebatecnicaNASA_JJH.App.Dto
{
    public class RelativeVelocityDto
    {
        [JsonProperty("kilometers_per_hour")]
        public double KilometersPerHour { get; set; }
    }
}
