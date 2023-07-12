using Flight.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.DataAccess.Interface
{
    public interface IFlightDAL
    {
        List<FlightServiceReponse> Search(FlightRequest request);
    }
}
