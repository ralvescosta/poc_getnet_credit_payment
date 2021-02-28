using Newtonsoft.Json;

namespace PocGetNet.DTOs
{
    public class GetNetDetailsDto
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_detail")]
        public string DescriptionDetails { get; set; }
    }
    public class GetNetErrorResultDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("details")]
        public GetNetDetailsDto[] Details { get; set; }
    }
}
