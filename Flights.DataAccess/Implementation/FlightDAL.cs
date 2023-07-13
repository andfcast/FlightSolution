using Flight.Entities;
using Flights.DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Flights.DataAccess.Implementation
{
    public class FlightDAL : IFlightDAL
    {
        private IConfiguration _configuration;

        public FlightDAL(IConfiguration configuration) {
            _configuration = configuration;
        }

        public List<FlightServiceReponse> Search(FlightRequest request) {
            string serviceUrl = _configuration["AppSettings:MainService"];
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
                List<FlightServiceReponse> lstFlights = new List<FlightServiceReponse>();
                if (response.IsSuccessStatusCode)
                {
                    lstFlights = JsonConvert.DeserializeObject<List<FlightServiceReponse>>(response.Content.ReadAsStringAsync().Result)!;
                }
                return lstFlights;
            }
            catch (Exception) {
                return null;
            }            
        }
    }
}