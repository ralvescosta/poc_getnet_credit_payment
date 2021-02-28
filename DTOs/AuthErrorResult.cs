using Newtonsoft.Json;

namespace PocGetNet.DTOs
{
    public class AuthErrorResult
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
