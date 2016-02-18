using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Contracts
{
    public interface IFlightSearchRequest
    {

        string From { get; set; }

        string To { get; set; }

        DateTime Date { get; set; }

    }
}
