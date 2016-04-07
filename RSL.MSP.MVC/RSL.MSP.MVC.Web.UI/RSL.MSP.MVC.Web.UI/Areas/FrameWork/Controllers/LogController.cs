using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    /// <summary>
    /// Sys_Log
    /// </summary>
    [Export]
    public class LogController : BaseController
    {

        // GET: Adm/Sys_Log
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
                ResultDto<SysLogModel> dto = _BLL.GetSysLogDataByPage(query);
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
