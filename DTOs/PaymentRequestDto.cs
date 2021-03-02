using Newtonsoft.Json;

namespace PocGetNet.DTOs
{
    public class PaymentRequestDto
    {
        public class OrderDto
        {
            [JsonProperty("order_id")]
            public string OrderId { get; set; }
        }
        public class BillingAddressDto
        {
            [JsonProperty("street")]
            public string Street { get; set; }

            [JsonProperty("number")]
            public string Number { get; set; }

            [JsonProperty("complement")]
            public string Complement { get; set; }

            [JsonProperty("district")]
            public string District { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("postal_code")]
            public string PostalCode { get; set; }
        }
        public class CustomerDto
        {
            [JsonProperty("customer_id")]
            public string CustomerId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("billing_address")]
            public BillingAddressDto BillingAddress { get; set; }
        }
        public class CardDto
        {
            [JsonProperty("number_token")]
            public string NumberToken { get; set; }

            [JsonProperty("expiration_month")]
            public string ExpirationMonth { get; set; }

            [JsonProperty("expiration_year")]
            public string ExpirationYear { get; set; }
        }
        public class CreditDto
        {
            [JsonProperty("delayed")]
            public bool Delayed { get; set; }

            [JsonProperty("pre_authorization")]
            public bool PreAuthorization { get; set; }

            [JsonProperty("save_card_data")]
            public bool SaveCardData { get; set; }

            [JsonProperty("transaction_type")]
            public string TransactionType { get; set; } // FULL || INSTALL_NO_INTEREST || INSTALL_WITH_INTEREST

            [JsonProperty("number_installments")]
            public int NumberInstallments { get; set; }

            [JsonProperty("soft_descriptor")]
            public string SoftDescriptor { get; set; }

            [JsonProperty("card")]
            public CardDto Card { get; set; }
        }
        public class RequisicaoPagamentoCreditoDto
        {
            [JsonProperty("seller_id")]
            public string SellerId { get; set; }

            [JsonProperty("amount")]
            public decimal Amount { get; set; }

            [JsonProperty("order")]
            public OrderDto Order { get; set; }

            [JsonProperty("customer")]
            public CustomerDto Customer { get; set; }

            [JsonProperty("credit")]
            public CreditDto Credit { get; set; }
        }
    }
}
