using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.OrdersDTO
{
    public record SummaryDTO
        (
        [property: JsonPropertyName("itemsTotal")]
        decimal ItemsTotal,

        [property: JsonPropertyName("deliveryFee")]
        decimal DeliveryFee,

        [property: JsonPropertyName("discount")]
        decimal Discount,

        [property: JsonPropertyName("finalTotal")]
        decimal FinalTotal
        );
}
