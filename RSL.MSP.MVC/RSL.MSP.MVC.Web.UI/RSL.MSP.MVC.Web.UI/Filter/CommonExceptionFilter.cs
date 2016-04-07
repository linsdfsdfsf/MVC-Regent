using System;
using System.Text;
using System.Web.Mvc;
using log4net;
using System.ComponentModel.Composition;
using RSL.MSP.MVC.Utility;

namespace RSL.MSP.MVC.Web.UI.Filter
{

    /// <summary>
    /// 通用日志处理器
    /// </summary>
    [Export]
    public class CommonExceptionFilter : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }


            StringBuilder error = new StringBuilder();
            string enter = "\r\n";
            error.Append(enter);
            error.Append("发生时间:" + DateTime.Now.ToString());
            error.Append(enter);

            error.Append("用户IP:" + LoginUserInfoHelper.GetClientIP());
            error.Append(enter);

            error.Append("发生异常页: " + filterContext.HttpContext.Request.Url.ToString());
            error.Append(enter);

            error.Append("控制器: " + filterContext.RouteData.Values["controller"]);
            error.Append(enter);

            error.Append("Action: " + filterContext.RouteData.Values["action"]);
            error.Append(enter);

            LogManager.GetLogger("LogExceptionAttribute").Error(error.ToString(), filterContext.Exception);

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var data = new
                {
                    flag = false,
                    data = string.Empty,
                    msg = filterContext.Exception.Message
                };
                filterContext.Result = new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                //filterContext.Result = new JavaScriptResult { Script = string.Format("alert('{0}')", filterContext.Exception.Message) };
            }
            else
            {
                var view = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml"
                };
                filterContext.Result = view;
            }
            filterContext.ExceptionHandled = true;
        }
    }

}