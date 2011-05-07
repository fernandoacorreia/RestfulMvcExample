using System.Web.Mvc;

namespace RestfulMvcExample.Controllers
{
    // Home page
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
