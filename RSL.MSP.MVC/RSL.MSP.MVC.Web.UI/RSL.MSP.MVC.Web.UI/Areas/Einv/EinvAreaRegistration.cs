using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.Einv
{
    public class EinvAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Einv";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Einv_default",
                "Einv/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
