using BYOJetServiceLayer.Contracts;
using BYOJetServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYOJetServiceLayer.DAL
{
    public class MockDataLayer : IDataLayer
    {

        private List<IFlightSearchResult> mockSearchData = new List<IFlightSearchResult>();

        // Our list of available carriers
        private List<string> carriers = new List<string>() { "Jetstar", "Qantas", "Virgin", "Paper Planes", "Emirates" };


        public List<IFlightSearchResult> RetrieveFlightSearchResults(IFlightSearchRequest searchProperties)
        {
            mockSearchData = new List<IFlightSearchResult>();
            Random numberGen = new Random();

            // Want to return a random number of results between 1 and 6
            int searchResults = numberGen.Next(1, 6);

            // Fill the mock results
            while (mockSearchData.Count < searchResults)
                mockSearchData.Add(CreateMockDataList(numberGen, searchProperties));

            return mockSearchData;
        }

        private IFlightSearchResult CreateMockDataList(Random numberGen, IFlightSearchRequest searchProperties)
        {
            // pick a random carrier
            string randomCarrier = carriers[numberGen.Next(0, 4)];

            // Departure can be anywhere between 4am and 9pm
            TimeSpan departureTime = new TimeSpan(numberGen.Next(4, 21), numberGen.Next(0, 59), 0);
            // journey length is anywhere between 2 and 3 hours
            int journeyLength = numberGen.Next(120, 180);

            return new FlightSearchResponse()
            {
                Carrier = randomCarrier,
                // Our flight number will be the first 2 digits of the carrier name and 3 random numbers
                Flight = string.Format("{0}{1}", randomCarrier.Substring(0, 2).ToUpper(), numberGen.Next(100, 500)),
                // Add our journey length to the departure time
                Arrive = departureTime.Add(TimeSpan.FromMinutes(journeyLength)).ToString(@"hh\:mm"),
                Depart = departureTime.ToString(@"hh\:mm"),
                // Fare will be anywhere between 49 and 249
                Fare = numberGen.Next(49, 249)
            };
        }



    }
}
