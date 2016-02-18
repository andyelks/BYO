using BYOJetServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Implementation
{
    public class OneWayFlights : IFlightSearch
    {
        IDataLayer dataAccessLayer = null;

        public OneWayFlights(IDataLayer dao)
        {
            if (dao == null)
                throw new Exception("Data Access Layer is null, you must supply a valid DAL object.");
            else
                dataAccessLayer = dao;
        }


        public Task<List<IFlightSearchResult>> PerformFlightSearch(IFlightSearchRequest search)
        {
            // One Way Flights implementation of flight search
            var searchData = dataAccessLayer.RetrieveFlightSearchResults(search);
            return Task.FromResult<List<IFlightSearchResult>>(searchData);
        }

    }
}
