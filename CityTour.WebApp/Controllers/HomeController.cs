using System.Web.Mvc;

namespace CityTour.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }    
    }
}