using BYOJetServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Models
{
    public class FlightSearchResponse : IFlightSearchResult
    {
        public string Arrive
        {
            get; set;
        }

        public string Carrier
        {
            get; set;
        }

        public string Depart
        {
            get; set;
        }

        public decimal Fare
        {
            get; set;
        }

        public string Flight
        {
            get; set;
        }
    }
}
