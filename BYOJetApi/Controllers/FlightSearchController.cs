using Autofac;
using BYOJetServiceLayer.Contracts;
using BYOJetServiceLayer.DAL;
using BYOJetServiceLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BYOJetApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/FlightSearch")]
    public class FlightSearchController : ApiController
    {

        private static IContainer Container { get; set; }

        public FlightSearchController()
        {
            var builder = new ContainerBuilder();

            // determine which search provider we will use
            string searchProvider = ConfigurationManager.AppSettings["SearchProvider"];

            // register the search provider type we are going to use,
            // by default we use OneWayTravel
            switch (searchProvider.ToLower())
            {
                case "cheapflightsrus":
                    builder.RegisterType<CheapFlightsRUs>().As<IFlightSearch>();
                    break;
                default:
                    builder.RegisterType<OneWayFlights>().As<IFlightSearch>();
                    break;
            }

            Container = builder.Build();
        }



        // POST api/FlightSearch
        public async Task<IHttpActionResult> Post(Models.FlightSearchBindingModels.FlightSearchBindingModel model)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<IFlightSearchResult> result;

            try
            {
                // IOC to resolve the flight search provider that we want to use
                // retrieved from web.config and set when the controller is constructed
                using (var scope = Container.BeginLifetimeScope())
                {
                    var search = scope.Resolve<IFlightSearch>(new NamedParameter("dao", new MockDataLayer()));
                    result = await search.PerformFlightSearch(model);
                }

                // Return our list of FlightSearchResult
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
