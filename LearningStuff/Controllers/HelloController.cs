using System.Web.Mvc;

namespace LearningStuff.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}