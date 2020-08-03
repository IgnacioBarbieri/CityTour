using CityTour.Domain.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CityTour.WebApp.Models
{
    public class GuestItineraryRequestViewModel
    {
        private IList<SelectListItem> guests;
        private IList<SelectListItem> points;

        public IList<SelectListItem> Guests
        {
            get
            {
                guests = guests ?? new List<SelectListItem>();
                return guests;
            }
            set
            {
                guests = value;
            }
        }

        public IList<SelectListItem> ItineraryPoints
        {
            get
            {
                points = points ?? new List<SelectListItem>();
                return points;
            }
            set
            {
                points = value;
            }
        }


        [Required]
        [Display(Name ="Huesped") ]
        public string GuestId { get; set; }
     
        [Required]
        [Display(Name = "Itinerario")]
        public string ItineraryPointId { get; set; }
    }
}