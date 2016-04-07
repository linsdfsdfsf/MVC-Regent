using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Login", new { area = "FrameWork" });
        }


        public ActionResult Error()
        {
            return View("Error");
        }

    }
}
