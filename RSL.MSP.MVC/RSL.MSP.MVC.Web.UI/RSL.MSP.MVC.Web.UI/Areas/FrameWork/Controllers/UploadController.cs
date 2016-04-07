using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class UploadController : BaseController
    {
        [HttpPost]
        public JsonResult UploadFile()
        {

            var result = new Result<string>();

            var filessss = HttpContext.Request.Files;

            try
            {

                HttpPostedFileBase files = Request.Files["file"];
                FileInfo fileInfo = new FileInfo(files.FileName);//获取文件名称
                string type = fileInfo.Extension.ToLower();//获取后缀
                string name = Guid.NewGuid().ToString();//创建文件名称
                string filepath = Server.MapPath("~/Image/Upload/" + System.DateTime.Now.ToString("yyyyMMdd"));

                //文件夹不存在创建文件夹
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                files.SaveAs(filepath + "/" + name + type);//保存文件

                string url = HttpContext.Request.Url.Host;
                int port = HttpContext.Request.Url.Port;

                if (port == 80)
                {
                    result.msg = "/Image/Upload/" + System.DateTime.Now.ToString("yyyyMMdd") + "/" + name + type;//返回文件路径
                }
                else
                {
                    result.msg = "/Image/Upload/" + System.DateTime.Now.ToString("yyyyMMdd") + "/" + name + type;//返回文件路径
                }
                result.flag = true;
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet); ;
        }

    }
}
