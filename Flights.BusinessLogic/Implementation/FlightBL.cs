using Flight.Entities;
using Flights.BusinessLogic.Interface;
using Flights.DataAccess.Interface;

namespace Flights.BusinessLogic.Implementation
{
    public class FlightBL : IFlightBL
    {
        private readonly IFlightDAL _flightDAL;

        public FlightBL(IFlightDAL flightDAL) { 
            _flightDAL = flightDAL;
        }
        public FlightResponse Search(FlightRequest request) {
            FlightResponse response = new FlightResponse();
            List<FlightServiceReponse> respService = _flightDAL.Search(request);
            response.Journey = new Journey();
            if (respService.Count > 0)
            {
                response.Journey = CalculateFlights(request, respService);                
            }            
            response.Journey.Origin = request.Origin;
            response.Journey.Destination = request.Destination;
            return response;
        }

        private Journey CalculateFlights(FlightRequest request, List<FlightServiceReponse> lstFights) {
            var objJourney = new Journey();
            var resFlight = lstFights.FirstOrDefault(x => x.DepartureStation == request.Origin && x.ArrivalStation == request.Destination);
            if (resFlight != null)
            {
                objJourney.Flights = new List<Flight.Entities.Flight>
                {
                    new Flight.Entities.Flight
                    {
                        Origin = request.Origin,
                        Destination = request.Destination,
                        Price = resFlight.Price,
                        Transport = new Transport
                        {
                            FlightCarrier = resFlight.FlightCarrier,
                            FlightNumber = resFlight.FlightNumber
                        },

                    }
                };
                objJourney.Price = resFlight.Price;
            }
            else { 
                //More than a flight
            }
            return objJourney;
        }
    }
}