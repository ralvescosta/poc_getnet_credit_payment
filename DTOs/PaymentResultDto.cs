using Newtonsoft.Json;
using System;

namespace PocGetNet.DTOs
{
    public partial class Credit
    {
        [JsonProperty("delayed")]
        public bool Delayed { get; set; }

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("authorized_at")]
        public DateTimeOffset AuthorizedAt { get; set; }

        [JsonProperty("reason_code")]
        public long ReasonCode { get; set; }

        [JsonProperty("reason_message")]
        public string ReasonMessage { get; set; }

        [JsonProperty("acquirer")]
        public string Acquirer { get; set; }

        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("terminal_nsu")]
        public string TerminalNsu { get; set; }

        [JsonProperty("acquirer_transaction_id")]
        public string AcquirerTransactionId { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
    public class PaymentResultDto
    {
        [JsonProperty("payment_id")]
        public Guid PaymentId { get; set; }

        [JsonProperty("seller_id")]
        public Guid SellerId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("order_id")]
        public Guid OrderId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("received_at")]
        public DateTimeOffset ReceivedAt { get; set; }

        [JsonProperty("credit")]
        public Credit Credit { get; set; }
    }
}
