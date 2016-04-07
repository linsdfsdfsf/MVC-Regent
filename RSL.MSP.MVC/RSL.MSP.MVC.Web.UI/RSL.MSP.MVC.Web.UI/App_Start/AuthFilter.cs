using System.Web.Mvc;
using System.Web.Security;


namespace RSL.MSP.MVC.Web.UI.App_Start
{
    /// <summary>
    /// 身份认证过滤器
    /// </summary>
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAnoy = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            var identity = filterContext.HttpContext.User.Identity;

            if (!isAnoy && !identity.IsAuthenticated)
            {
                string returnUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}