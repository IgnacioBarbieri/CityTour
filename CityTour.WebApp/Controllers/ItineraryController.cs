using AutoMapper;
using CityTour.Domain;
using CityTour.Domain.Services;
using CityTour.WebApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CityTour.WebApp.Controllers
{
    public class ItineraryController : Controller
    {
        private readonly IItineararyService itinerarryService;
        private readonly IMapper mapper;

        private const string tempDataPointsKey = nameof(ShowSummaryViewModel.ItineraryPoints);

        public ItineraryController(
            IItineararyService itinerarryService,
            IMapper mapper)
        {
            if (itinerarryService == null)
            {
                throw new ArgumentNullException(nameof(itinerarryService));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this.itinerarryService = itinerarryService;
            this.mapper = mapper;
        }
       
        public ActionResult ShowSummary()
        {
            ShowSummaryViewModel viewModel = new ShowSummaryViewModel();
            Populate(viewModel, needsRefresh: true);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowSummary(ShowSummaryViewModel viewModel)
        {
            try
            {             
                if (ModelState.IsValid)
                {
                    GuestItineraryPoint startPoint = itinerarryService.GetBydId(1);
                    GuestItineraryPoint endPoint   = itinerarryService.GetBydId(int.Parse(viewModel.ItineraryPointId));

                    var summaryInfo = itinerarryService.ShowSummary(startPoint, endPoint);
                    summaryInfo?.ForEach(summaryInfoItem =>
                    {
                        SummaryPointInfoViewModel summaryPointViewmodel = new SummaryPointInfoViewModel();
                        mapper.Map(summaryInfoItem, summaryPointViewmodel);

                        viewModel.SummaryInfoResults.Add(summaryPointViewmodel);
                    });
                }
            }
            catch
            {
                
            }

            Populate(viewModel);
            return View(viewModel);
        }

        private void Populate(ShowSummaryViewModel viewModel, bool needsRefresh = false)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }


            if (needsRefresh)
            {                
                if (TempData.ContainsKey(tempDataPointsKey)) TempData.Remove(tempDataPointsKey);
            }


            if (!TempData.ContainsKey(tempDataPointsKey))
            {
                var items = itinerarryService
                    .GetRequestedPoints() 
                    .Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name })
                    .ToList();

                TempData.Add(tempDataPointsKey, items);
            }

            
            viewModel.ItineraryPoints = TempData.Peek(nameof(GuestItineraryRequestViewModel.ItineraryPoints)) as IList<SelectListItem>;
        }
    }
}
