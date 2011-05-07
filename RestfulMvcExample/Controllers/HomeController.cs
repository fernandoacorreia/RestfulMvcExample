using System.Web.Mvc;

namespace RestfulMvcExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
