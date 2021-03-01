using Newtonsoft.Json;

namespace PocGetNet.DTOs
{
    public class CardTokenizationResultDto
    {
        [JsonProperty("number_token")]
        public string NumberToken { get; set; }
    }
}
