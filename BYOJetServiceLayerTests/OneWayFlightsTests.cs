using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BYOJetApi.Controllers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using BYOJetServiceLayer.Models;
using BYOJetServiceLayer.Contracts;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace BYOJetServiceLayerTests
{
    [TestClass]
    public class OneWayFlightsTests
    {
        [TestMethod]
        public void RetrieveDataTest()
        {
            FlightSearchController searchController = new FlightSearchController();

            // Arrange
            searchController.Request = new HttpRequestMessage();
            searchController.Configuration = new HttpConfiguration();

            // Act
            var response = searchController.Post(new BYOJetApi.Models.FlightSearchBindingModels.FlightSearchBindingModel()
            { From = "Brisbane", To = "Sydney", Date = DateTime.Now });

            OkNegotiatedContentResult<List<IFlightSearchResult>> results = 
                (OkNegotiatedContentResult<List<IFlightSearchResult>>)response.Result;

            // Assert
            Assert.AreEqual(response.Status, TaskStatus.RanToCompletion);
            Assert.AreNotEqual(results.Content.Count, 0);
        }
    }
}
