using AutoMapper;
using CityTour.Domain;
using CityTour.WebApp.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace CityTour.WebApp.Profiles
{
    public class ItineraryProfle : Profile
    {
        public ItineraryProfle()
        {
            CreateMap<GuestItineraryPoint, SummaryPointInfoViewModel>()
                .ForMember(dest => dest.GuestInfo, opt => opt.MapFrom(src => src.Guests.Select(t => t.Name + " " + t.FirstName).ToList()));
        }
    }    
}