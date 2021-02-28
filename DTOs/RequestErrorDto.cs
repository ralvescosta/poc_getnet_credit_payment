using Newtonsoft.Json;
using System.Collections.Generic;

namespace PocGetNet.DTOs
{
    public class ErrorDetailsDto
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_detail")]
        public string DescriptionDetail { get; set; }
    }
    public class RequestErrorDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("details")]
        public IEnumerable<ErrorDetailsDto> Details { get; set; }
    }
}
