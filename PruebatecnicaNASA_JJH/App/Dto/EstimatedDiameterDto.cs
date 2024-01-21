using Newtonsoft.Json;

namespace PruebatecnicaNASA_JJH.App.Dto
{
    public class EstimatedDiameterDto
    {
        [JsonProperty("kilometers")]
        public DiameterRangeDto Kilometers { get; set; }
    }
}
