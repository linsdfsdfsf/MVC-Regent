using RSL.MSP.MVC.Web.UI.App_Start;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RSL.MSP.MVC.Web.UI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //加入身份验证过滤器
            GlobalFilters.Filters.Add(new AuthFilter());

            //注册AutoMapper
            //AutoMapperConfiguration.InitMapper();

            //设置MEF依赖注入容器
            DirectoryCatalog catalog = new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            MefDependencySolver solver = new MefDependencySolver(catalog);
            DependencyResolver.SetResolver(solver);

            //根据变更，初始化数据库
            //DatabaseInitializer.Initialize();
        }
    }
}