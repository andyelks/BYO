using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BYOJetApi.Controllers
{
    [RoutePrefix("api/Booking")]
    public class BookingController : ApiController
    {

        // GET api/Booking
        public async Task<IHttpActionResult> Get(string flightNumber)
        {
            return BadRequest("We aren't setup to take your booking just yet");
        }

    }
}
