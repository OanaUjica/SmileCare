using Microsoft.AspNetCore.Mvc;


namespace SmileCare.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// EndPoint maps to this action method to view the main page.
        /// </summary>
        /// <returns> The main page View. </returns>
        public IActionResult Index()
        {     

            return View();
        }
    }
}
