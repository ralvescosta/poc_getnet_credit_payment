﻿using Newtonsoft.Json;

namespace PocGetNet.DTOs
{
    public class CardTokenizationRequestDto
    {
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
    }
}
