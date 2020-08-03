using CityTour.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityTour.WebApp.Models
{
    public class SummaryPointInfoViewModel
    {
        public string Name { get; set; }

        public int Distance { get; set; }

        public IList<String> GuestInfo { get; set; }
        
        public String GuestInfoToString()
        {
            if (GuestInfo == null || GuestInfo.Count == 0) return String.Empty;
            return String.Join(",", GuestInfo.ToArray());
        }
        
    }
}