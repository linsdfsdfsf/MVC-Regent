using System.Linq;
using System.Web.Mvc;
using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Utility;
using RSL.MSP.MVC.Model.Common;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using RSL.MSP.MVC.Web.UI.Areas.FrameWork.Models;
using System.Net;
using RSL.MSP.MVC.Model.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /FrameWork/Login/
        //[AllowAnonymous]
        //public ActionResult Index()
        //{
        //    //檢查是否需要多站台下拉式選單
        //    Regex rgx = new Regex(@"^off$", RegexOptions.IgnoreCase);
        //    ViewBag.multiSite = false;
        //    if (!rgx.IsMatch(WebConfigurationManager.AppSettings["LoginDBList"]))
        //    {
        //        //多站台選單
        //        ViewBag.DBSiteList = new UserBLL().GetDBSiteList().Select(item => new SelectListItem { Value = item.SITE_ID.ToString(), Text = item.SITE_NAME });
        //        ViewBag.multiSite = true;
        //    }

        //    //檢查是要用哪一個Login版面
        //    switch (WebConfigurationManager.AppSettings["LoginTemplate"])
        //    {
        //        case "2":
        //            return View("~/Areas/FrameWork/Views/Login/twoColumnLogin.cshtml");
        //            break;
        //        default:
        //            return View();
        //            break;
        //    }
        //}

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.DBSiteList = new UserBLL().GetDBSiteList().Select(item => new SelectListItem { Value = item.SITE_ID.ToString(), Text = item.SITE_NAME });
            //檢查是要用哪一個Login版面
            switch (WebConfigurationManager.AppSettings["LoginTemplate"])
            {
                case"1":
                    return View("~/Areas/FrameWork/Views/Login/Index.cshtml");
                case "2":
                    return View("~/Areas/FrameWork/Views/Login/twoColumnLogin.cshtml");
                default:
                    return View();
            }
           // return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(string User_Account, string User_PWD, string choose_ID, string User_Customer, string strCheckCode)
        {
            var result = new Result<string>();
            if (ModelState.IsValid)
            {
                #region 使用者登录前选择分店，保存分店TNS
                if (Session[MSPkeys.SESSION_SYSTEM_SITE] != null)
                {
                    Session.Remove(MSPkeys.SESSION_SYSTEM_SITE);
                } Session[MSPkeys.SESSION_SYSTEM_SITE] = choose_ID;
                #endregion

                UserBLL userBLL = new UserBLL();


                if (WebConfigurationManager.AppSettings["LoginCustomer"].ToUpper() == "ON")
                {
                    if (string.IsNullOrEmpty(User_Customer.Trim()))
                    {
                        result.flag = false;
                        result.msg = "請填寫客戶ID。";
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var List = userBLL.GetCustomerList().Where(p => p.CUSTOMER_NAME.ToUpper().Equals(User_Customer.Trim().ToUpper())).ToList();
                        if (List.Count > 0)
                        {
                            if (!userBLL.isUserCustomerExstis(User_Account, User_Customer))
                            {
                                result.flag = false;
                                result.msg = "該使用者不是該客戶ID下。";
                                return Json(result, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            result.flag = false;
                            result.msg = "客戶ID不存在。";
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                    }
                }

                int outPWD = 0;
                UserModel outUserModel;

                string msg = userBLL.SystemLogin(User_Account, User_PWD, this.Session["system_session_checkcode"].ToString().ToLower(), out outPWD, out outUserModel);

                if (msg == "登錄成功")
                {
                    result.data = outUserModel.IS_CHANGEPWD.ToString();
                    result.strUser_ID = outUserModel.USER_ID.ToString();
                    result.flag = true;
                    result.msg = msg;
                }
                else
                {
                    result.flag = false;
                    result.msg = msg;
                }
            }
            else
            {
                result.flag = false;
                result.msg = "請填寫帳號名和密碼!";

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 並排登入頁面專屬認證功能
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        //[AcceptVerbs(WebRequestMethods.Http.Get, WebRequestMethods.Http.Post)]
        //public ActionResult Verify(LoginForm form) {
        //    if (WebConfigurationManager.AppSettings["LoginTemplate"] == "2")
        //    {
        //        ViewBag.postData = form;
        //        return View();
        //    }
        //    else {
        //        return RedirectToAction("Index", "Login", new { area = "FrameWork" });
        //    }
        //}

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserBLL userBLL = new UserBLL();
                userBLL.ClearLoginInfo();
            }
            return Redirect("/FrameWork/Login/Index");
        }

        #region 獲取首頁是否顯示下拉DB\是否顯示客戶輸入框 配置開關 add by OceanChai @2016.03.15

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetLoginDBisOpen()
        {
            string isLoginDBSite = WebConfigurationManager.AppSettings["LoginDBList"].ToUpper();
            return Json(isLoginDBSite, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetLoginCustomerisOpen()
        {
            string isLoginCustomer = WebConfigurationManager.AppSettings["LoginCustomer"].ToUpper();
            return Json(isLoginCustomer, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
