using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tests1.DTO.OrdersDTO
{
    public record DeliveryDTO
        (
        [property: JsonPropertyName("type")]
        string Type,

        [property: JsonPropertyName("status")]
        string Status,

        [property: JsonPropertyName("estimatedDate")]
        string EstimatedDate,

        [property: JsonPropertyName("trackingNumber")]
        string TrackingNumber
        );
}