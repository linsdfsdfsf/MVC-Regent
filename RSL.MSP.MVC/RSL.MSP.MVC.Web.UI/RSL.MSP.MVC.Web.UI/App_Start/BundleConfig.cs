using System;
using System.Web.Optimization;

namespace RSL.MSP.MVC.Web.UI.App_Start
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //重新处理bundle忽略资源的规则
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            #region JS

            //控制面板通用js
            bundles.Add(new ScriptBundle("~/js/adm/control").Include(
                "~/content/template/js/jquery-2.1.1.min.js",
                "~/content/template/js/bootstrap.min.js",
                "~/content/template/js/plugins/metisMenu/jquery.metisMenu.js",
                "~/content/template/js/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/content/template/js/contabs-iframe.js",
                "~/content/template/js/plugins/pace/pace.min.js"));

            bundles.Add(new ScriptBundle("~/Content/template/js/plugins/layer/ly").Include(
                "~/Content/template/js/plugins/layer/layer.min.js"));

            bundles.Add(new ScriptBundle("~/Content/template/plus").Include(
                "~/Content/template/js/plus.js"));

            //空白模版通用Js
            bundles.Add(new ScriptBundle("~/js/adm/blank").Include(
                "~/content/template/js/jquery-2.1.1.min.js",
                "~/content/template/js/bootstrap.min.js",
                "~/content/template/js/plugins/peity/jquery.peity.min.js",
                "~/content/template/js/plugins/jqgrid/i18n/grid.locale-cn.js",
                "~/content/template/js/plugins/jqgrid/jquery.jqGrid.min.js",
                "~/content/template/js/content.js"
                ));

            bundles.Add(new ScriptBundle("~/js/adm/validate").Include(
               "~/Bootstrap/validate/bootstrap3-validation.js",
               "~/content/template/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/js/adm/base").Include(
                "~/content/template/Scripts/adm/base.js",
                "~/content/template/Scripts/ajaxfileupload.js"));

            bundles.Add(new ScriptBundle("~/js/adm/json").Include(
                "~/content/template/Scripts/json2.js"));

            bundles.Add(new ScriptBundle("~/Content/template/js/plugins/jsTree/roletree").Include(
                "~/Content/template/js/plugins/jsTree/jstree.min.js"));

            bundles.Add(new ScriptBundle("~/js/adm/jqueryWithBootStrap").Include(
                "~/content/template/js/jquery-2.1.1.min.js",
                "~/content/template/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/js/front/web").Include(
                "~/content/template/scripts/jquery-1.8.2.js",
                "~/content/template/Scripts/jquery.onepage-scroll.js"));

            bundles.Add(new ScriptBundle("~/js/adm/chosen").Include(
                "~/content/template/js/plugins/chosen/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/js/rwd-table").Include(
                "~/content/template/js/rwd-table.min.js"));

            bundles.Add(new ScriptBundle("~/js/pagination").Include(
                "~/content/template/js/pagination.js"));

            bundles.Add(new ScriptBundle("~/js/dialogs").Include(
                "~/content/template/js/dialogs.js"));

            bundles.Add(new ScriptBundle("~/js/bootstrap-datepicker").Include(
                "~/content/template/js/plugins/datapicker/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/js/bootstrap-table").Include(
                "~/content/template/js/bootstrap-table.js"));


            #endregion
            #region CSS

            //控制面板通用样式
            bundles.Add(new StyleBundle("~/css/adm/control").Include(
                "~/content/template/css/bootstrap.min.css",
                "~/content/template/css/font-awesome.css",
                "~/content/template/css/animate.css",
                "~/content/template/css/style.css"
                ));

            //login
            bundles.Add(new StyleBundle("~/css/adm/login").Include("~/content/template/css/login.css"));

            bundles.Add(new StyleBundle("~/css/adm/jqgrid").Include(
                "~/content/template/css/plugins/jqgrid/ui.jqgrid.css"));

            bundles.Add(new StyleBundle("~/Content/template/css/plugins/jsTree/style").Include(
                "~/Content/template/css/plugins/jsTree/style.min.css"));

            bundles.Add(new StyleBundle("~/css/adm/bootstrap").Include(
                "~/content/template/css/bootstrap.min.css"));

            //front 
            bundles.Add(new StyleBundle("~/css/front/web").Include(
                "~/Content/front/adm.css",
                "~/Content/front/onepage.css"));


            bundles.Add(new StyleBundle("~/css/adm/chosen").Include(
                "~/content/template/css/plugins/chosen/chosen.css"));

            //rwd table
            bundles.Add(new StyleBundle("~/css/rwd-table").Include(
                "~/content/template/css/rwd-table.min.css"));
            //radio, check-box 
            bundles.Add(new StyleBundle("~/css/checkbox-radio").Include(
                "~/content/template/css/awesome-bootstrap-checkbox.css"));
            //bootstrap datepicker 
            bundles.Add(new StyleBundle("~/css/bootstrap-datepicker").Include(
                "~/content/template/css/plugins/datapicker/datepicker3.css"));
            //custom page - paypage
            bundles.Add(new StyleBundle("~/css/paypage").Include(
                "~/content/template/css/paypage.css"));

            bundles.Add(new StyleBundle("~/css/bootstrap-table").Include(
                "~/content/template/css/bootstrap-table.css"));

            #endregion


        }

        /// <summary>   
        /// 添加bundle需要忽略的表达式的资源
        /// </summary>
        /// <param name="ignoreList"></param>
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}