using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BYOJetServiceLayer.Contracts;
using BYOJetServiceLayer.DAL;
using BYOJetServiceLayer.Models;
using System.Collections.Generic;

namespace BYOJetServiceLayerTests
{
    [TestClass]
    public class DataAccessLayer
    {
        [TestMethod]
        public void MockDataLayerData()
        {

            IDataLayer dao = new MockDataLayer();
            List<IFlightSearchResult> searchData = dao.RetrieveFlightSearchResults(
                new FlightSearchRequest() {
                    From = "Brisbane", To = "Sydney",
                    Date = DateTime.Now.AddDays(2) }
                );

            if (searchData.Count == 0)
                Assert.Fail("No data returned from search");



        }

        [TestMethod]
        public void SQLDataLayerData()
        {

            IDataLayer dao = new MockDataLayer();
            List<IFlightSearchResult> searchData = dao.RetrieveFlightSearchResults(
                new FlightSearchRequest()
                {
                    From = "Brisbane",
                    To = "Sydney",
                    Date = DateTime.Now.AddDays(2)
                }
                );

            if (searchData.Count == 0)
                Assert.Fail("No data returned from SQL search");



        }


    }
}
