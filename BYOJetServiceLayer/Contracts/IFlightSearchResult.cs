using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Contracts
{
    public interface IFlightSearchResult
    {
        string Carrier { get; set; }

        string Flight { get; set; }

        string Depart { get; set; }

        string Arrive { get; set; }

        decimal Fare { get; set; }

    }
}
