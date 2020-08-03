using AutoMapper;
using CityTour.Domain;
using CityTour.WebApp.Models;

namespace CityTour.WebApp.Profiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<Guest, GuestViewModel>()
                .ReverseMap();
        }
    }
}