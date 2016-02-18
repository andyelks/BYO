using BYOJetServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Models
{
    public class FlightSearchRequest : IFlightSearchRequest
    {
        public DateTime Date
        {
            get; set;
        }

        public string From
        {
            get; set;
        }

        public string To
        {
            get; set;
        }
    }
}
