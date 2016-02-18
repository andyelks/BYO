using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Contracts
{
    public interface IDataLayer
    {

        List<IFlightSearchResult> RetrieveFlightSearchResults(IFlightSearchRequest searchProperties);

    }
}
