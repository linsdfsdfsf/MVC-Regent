using RSL.MSP.MVC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class CheckCodeController : Controller
    {
        //
        // GET: /FrameWork/CheckCode/

        [AllowAnonymous]
        public ActionResult Index()
        {

            CheckCodeHelper.MakeCheckCode();

            return View();
        }

    }
}
