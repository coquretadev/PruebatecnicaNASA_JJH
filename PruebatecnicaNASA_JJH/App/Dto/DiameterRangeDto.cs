using Newtonsoft.Json;

namespace PruebatecnicaNASA_JJH.App.Dto
{
    public class DiameterRangeDto
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }
}
