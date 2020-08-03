using AutoMapper;
using CityTour.Domain;
using CityTour.Domain.Services;
using CityTour.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CityTour.WebApp.Controllers
{
    public class GuestController : Controller
    {        
        private readonly IGuestService guestService;
        private readonly IGuestItineararyRequestService requestService;
        private readonly IItineararyService itinerarryService;

        private readonly IMapper mapper;

        private const string tempDataGuestsKey = nameof(GuestItineraryRequestViewModel.Guests);
        private const string tempDataPointsKey = nameof(GuestItineraryRequestViewModel.ItineraryPoints);
        
        public GuestController(
              IGuestService guestService
            , IGuestItineararyRequestService requestService
            , IItineararyService itineraryService
            , IMapper mapper)
        {
            if (guestService == null)
            {
                throw new ArgumentNullException(nameof(guestService));
            }

            if (requestService == null)
            {
                throw new ArgumentNullException(nameof(requestService));
            }

            if (itineraryService == null)
            {
                throw new ArgumentNullException(nameof(itineraryService));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this.guestService = guestService;
            this.requestService = requestService;
            this.itinerarryService = itineraryService;
            this.mapper = mapper;
        }
           
        // GET: Guest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuestViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                Guest guest = new Guest();
                mapper.Map(viewModel, guest);

                guestService.Save(guest);

               
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(viewModel);
            }
                       
        }

        // GET: Guest/CreateItineraryRequest
        public ActionResult CreateItineraryRequest()
        {            
            GuestItineraryRequestViewModel viewModel = new GuestItineraryRequestViewModel();
            Populate(viewModel, needsRefresh:true);

            return View(viewModel);
        }

        // POST: Guest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItineraryRequest(GuestItineraryRequestViewModel viewModel)
        {
            try
            {
                Guest guest = guestService.GetById(int.Parse(viewModel?.GuestId));
                GuestItineraryPoint endPoint = itinerarryService.GetBydId(int.Parse(viewModel?.ItineraryPointId));

                if (endPoint?.Guests.Any(item => item.Id == guest.Id) == true)
                {
                    ModelState.AddModelError(nameof(GuestItineraryRequestViewModel.GuestId), "Este huésped ya ha solicitado viajar al punto de interés selecionado");                    
                }

                if (ModelState.IsValid)
                {                    
                    endPoint.Guests.Add(guest);

                    requestService.Save(new GuestItineraryRequest() { EndPoint = endPoint });
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {

            }

            Populate(viewModel);
            return View(viewModel);
        }

        private void Populate(GuestItineraryRequestViewModel viewModel, bool needsRefresh = false)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }


            if (needsRefresh)
            {
                if (TempData.ContainsKey(tempDataGuestsKey)) TempData.Remove(tempDataGuestsKey);
                if (TempData.ContainsKey(tempDataPointsKey)) TempData.Remove(tempDataPointsKey);
            }
            

            if (!TempData.ContainsKey(tempDataGuestsKey))
            {
                var items = guestService
                    .GetAll()
                    .Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name + " " + item.FirstName })
                    .ToList();

                TempData.Add(tempDataGuestsKey, items);
            }
                        
            
            if (!TempData.ContainsKey(tempDataPointsKey))
            {
                var items = itinerarryService
                    .GetRequestedPoints()
                    .Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name })
                    .ToList();

                TempData.Add(tempDataPointsKey, items);
            }
            

            viewModel.Guests = TempData.Peek(nameof(GuestItineraryRequestViewModel.Guests)) as IList<SelectListItem>;
            viewModel.ItineraryPoints = TempData.Peek(nameof(GuestItineraryRequestViewModel.ItineraryPoints)) as IList<SelectListItem>;
        }
    }
}


