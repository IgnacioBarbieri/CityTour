using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTour.Domain
{
    public class Guest
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
    }
}
