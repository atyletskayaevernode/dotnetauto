using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.OrdersDTO
{
    public record PaymentDTO
        (
        [property: JsonPropertyName("method")]
        string Method,

        [property: JsonPropertyName("status")]
        string Status,

        [property: JsonPropertyName("transactionId")]
        string TransactionId
        );
}