using Autofac;
using BYOJetServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.Implementation
{
    public class CheapFlightsRUs : IFlightSearch
    {

        IDataLayer dataAccessLayer = null;

        public CheapFlightsRUs(IDataLayer dao)
        {
            if (dao == null)
                throw new Exception("Data Access Layer is null, you must supply a valid DAL object.");
            else
                dataAccessLayer = dao;
        }


        public Task<List<IFlightSearchResult>> PerformFlightSearch(IFlightSearchRequest search)
        {
            // Cheap fights r us implementation of flight search
            var searchData = dataAccessLayer.RetrieveFlightSearchResults(search);

            // Only going to return 1 result but it's half the price of One Way Flights :)
            List<IFlightSearchResult> returnSearchData = new List<IFlightSearchResult>();
            returnSearchData.Add(searchData[0]);
            returnSearchData[0].Fare = returnSearchData[0].Fare * 0.5m;


            return Task.FromResult<List<IFlightSearchResult>>(returnSearchData);
        }

    }
}
