using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.Framework;
using System;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class LoginLogController : BaseController
    {
        //
        // GET: /FrameWork/LoginLog/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页获取Sys_Log
        /// </summary>
        /// <param name="query">QueryBase</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(QueryBase query)
        {
            try
            {

                SysLogBLL _BLL = new SysLogBLL();
                ResultDto<LoginLogModel> dto = _BLL.GetLoginLogDataByPage(query);
                return Json(dto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<SysLogModel>(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
