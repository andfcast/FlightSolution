using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Flight.Entities
{
    [Serializable]
    public class FlightServiceReponse
    {
        [JsonPropertyName("departureStation")]
        public string DepartureStation { get; set; }

        [JsonPropertyName("arrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonPropertyName("flightCarrier")]
        public string FlightCarrier { get; set; }

        [JsonPropertyName("flightNumber")]
        public string FlightNumber { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
