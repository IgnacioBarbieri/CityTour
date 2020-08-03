using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityTour.WebApp.Models
{
    public class GuestViewModel
    {
        public int Id { get; private set; }

        [Required]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string FirstName { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string LastName { get; set; }    
    }
}