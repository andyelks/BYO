using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BYOJetServiceLayer.Contracts;

namespace BYOJetApi.Models
{
    public class FlightSearchBindingModels
    {
        public class FlightSearchBindingModel : IFlightSearchRequest
        {
            [Required]
            [Display(Name = "From Location")]
            public string From { get; set; }

            [Required]
            [Display(Name = "To Location")]
            public string To { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date of Travel")]
            public DateTime Date { get; set; }
        }

    }
}