using BYOJetServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.DAL
{
    public class SQLDataLayer : IDataLayer
    {
        public List<IFlightSearchResult> RetrieveFlightSearchResults(IFlightSearchRequest searchProperties)
        {

            // Go to SQL Server DB and retrieve data

            return new List<IFlightSearchResult>();
        }
    }
}
