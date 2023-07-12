using Flight.Entities;
using Flights.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flights.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightBL _flightBL;

        public FlightsController(IFlightBL flightBL) {
            _flightBL = flightBL;
        }
        // GET: api/<FlightsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }        

        // POST api/<FlightsController>
        [HttpPost]
        [Route("GetFlights")]
        public FlightResponse GetFlights([FromBody] FlightRequest request)
        {
            return _flightBL.Search(request);
        }        
    }
}
