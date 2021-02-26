using Newtonsoft.Json;

namespace PocGetNet.DTOs
{
    public class CardTokenizationRequest
    {
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("customer_id")]
        public string CustiomerId { get; set; }
    }
}
