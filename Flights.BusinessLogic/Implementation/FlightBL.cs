using Flight.Entities;
using Flights.BusinessLogic.Interface;
using Flights.DataAccess.Interface;
using System.Diagnostics;

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
                string strOrigin = string.Empty;
                string strDestination = string.Empty;
                List<FlightServiceReponse> nodesOrigin = new List<FlightServiceReponse>();
                List<FlightServiceReponse> nodesTravel = new List<FlightServiceReponse>();
                List<FlightServiceReponse> nodesDestination = new List<FlightServiceReponse>();
                nodesOrigin = lstFights.Where(x => x.DepartureStation == request.Origin).ToList();
                
                nodesDestination = lstFights.Where(x => x.ArrivalStation == request.Destination).ToList();
                FlightServiceReponse[] arrOrigin = nodesOrigin.ToArray();
                for (int i = 0; i < arrOrigin.Length; i++) {
                    strOrigin = arrOrigin[i].ArrivalStation;
                    if (nodesDestination.Count(x => x.DepartureStation == strOrigin) > 0)
                    {
                        nodesTravel.Add(arrOrigin[i]);
                        nodesTravel.Add(nodesDestination.First(x => x.DepartureStation == strOrigin));
                        i = arrOrigin.Length;
                    }                    
                }
                if (nodesTravel.Count > 0)
                {
                    objJourney.Flights = new List<Flight.Entities.Flight>();
                    foreach (var item in nodesTravel)
                    {                        
                        objJourney.Flights.Add(new Flight.Entities.Flight
                        {
                            Origin = request.Origin,
                            Destination = request.Destination,
                            Price = item.Price,
                            Transport = new Transport
                            {
                                FlightCarrier = item.FlightCarrier,
                                FlightNumber = item.FlightNumber
                            },
                        });
                        objJourney.Price += item.Price;
                    }
                }
                else { 
                    
                }

            }
            return objJourney;
        }

        //private string[] funcionPrueba(string origin, string destination, List<FlightServiceReponse> lstFlights)
        //{
        //    string originAux = origin;
        //    string destinationAux = string.Empty;
        //    List<FlightNode> lstNodes = new List<FlightNode>();
        //    foreach (var item in lstFlights) {
        //        lstNodes.Add(new FlightNode
        //        {
        //            Origin = item.DepartureStation,
        //            Destination = item.ArrivalStation,
        //            Price = item.Price,
        //            Checked = false
        //        });
        //    }
        //    foreach(var item in lstNodes.Where(x => x.Origin == originAux)) {
        //        if (item.Destination != destination) {
        //            originAux = item.Destination;
        //        }    
            
        //    }
        //    List<FlightServiceReponse> nodesOrigin = lstFlights.Where(x => x.DepartureStation == origin).ToList();
        //    string trip = origin;
        //    while
        //}
    }
}