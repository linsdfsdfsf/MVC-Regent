using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.Regent
{
    public class RegentAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Regent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Regent_default",
                "Regent/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
