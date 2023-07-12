using Flight.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.BusinessLogic.Interface
{
    public interface IFlightBL
    {
        FlightResponse Search(FlightRequest request);
    }
}
