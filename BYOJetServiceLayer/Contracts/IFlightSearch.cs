using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Contracts
{
    public interface IFlightSearch
    {
        Task<List<IFlightSearchResult>> PerformFlightSearch(IFlightSearchRequest search);

    }
}
