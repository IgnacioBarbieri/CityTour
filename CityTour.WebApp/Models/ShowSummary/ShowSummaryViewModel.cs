using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CityTour.WebApp.Models
{
    public class ShowSummaryViewModel
    {
        private IList<SelectListItem> points;
        private IList<SummaryPointInfoViewModel> summaryInfoResults;

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

        public IList<SummaryPointInfoViewModel> SummaryInfoResults
        {
            get
            {
                summaryInfoResults = summaryInfoResults ?? new List<SummaryPointInfoViewModel>();
                return summaryInfoResults;
            }
            set
            {
                summaryInfoResults = value;
            }
        }


        [Required]
        [Display(Name = "Punto de Interés")]
        public string ItineraryPointId { get; set; }

    }
}