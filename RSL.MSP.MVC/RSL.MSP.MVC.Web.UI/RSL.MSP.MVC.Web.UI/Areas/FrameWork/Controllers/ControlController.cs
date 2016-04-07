using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.Enums;
using RSL.MSP.MVC.Model.Framework;
using RSL.MSP.MVC.Utility;
using RSL.MSP.MVC.Utility.ExtensionHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class ControlController : BaseController
    {
        //
        // GET: /FrameWork/Control/
        public string[] icons = { "fa-th-large", "fa-diamond", "fa-bar-chart-o", "fa fa-envelope", "fa-pie-chart", "fa-flask", "fa-edit", "fa-desktop", "fa-files-o" };

        public ActionResult Index()
        {
            var MenuList = getMenuList();
            ViewBag.myMenus = MenuList;
            ViewBag.LoginUserName = this.LoginedUserName;
            return View();
        }

        public string getMenuList()
        {
            string[] tmp = HttpContext.Request.Url.AbsolutePath.Split('/');
            return this.get_navigation_list(tmp[tmp.Length - 1]);
        }

        #region 获取后台导航字符串==============================
        private string get_navigation_list(string page = "")
        {
            MenuBLL myMenuBLL = new MenuBLL();
            List<MenuModel> myMenuInfoList = this.LoginedUserAuthMenu;//获取当前登录人员菜单权限信息
            return this.get_navigation_childs(myMenuInfoList, 0, page);
        }
        private string get_navigation_childs(List<MenuModel> MenuInfoList, decimal Menu_ID, string page)
        {
            string output = "";
            int seq = 0;
            Regex reg = new Regex(page, RegexOptions.IgnoreCase);
            var ParentMenuList = MenuInfoList.Where(p => p.P_Menu_ID == Menu_ID);

            foreach (var item in ParentMenuList)
            {
                if (item.IS_VALID == 1)
                {
                    string tmp = this.get_navigation_childs(MenuInfoList, item.MENU_ID, page);
                    string arrow = ((tmp != "") ? "<span class='fa arrow'></span>" : "");
                    string url = String.IsNullOrEmpty(item.CONTROLLER_ACTION) ? "url" : item.CONTROLLER_ACTION; //将原有web from 菜单路径修改为 MVC 菜单路径 edit by OceanChai@2016.02.29
                    string aLink = "";
                    if (item.P_Menu_ID == 0)
                    {
                        aLink = "<a href='" + url + "'><i class='fa " + icons[seq % icons.Length] + "'></i><span class='nav-label'>" + item.MENU_NAME + "</span>";
                        seq++;
                    }
                    else if (item.CONTROLLER_ACTION != null)
                    {
                        aLink = "<a class='J_menuItem' href='" + url + "/" + item.MENU_ID + "'>" + item.MENU_NAME;
                    }
                    output += "<li" + (reg.IsMatch(url) ? " class='active'" : "") + ">" + aLink + arrow + "</a>";
                    output += (tmp != "") ? "<ul class='nav nav-second-level collapse'>" + tmp + "</ul>" : "";
                    output += "</li>";
                }
            }

            return output;
        }
        #endregion


        // GET: Adm/Welcome
        public ActionResult Welcome()
        {
            return View();
        }


        public ActionResult ChangePassWord()
        {
            UserBLL myUserBLL = new UserBLL();
            UserModel myUserModel = myUserBLL.GetUserInfoByUserAccount(this.LoginedUserName);
            return View(myUserModel);
        }

        public ActionResult UserChangePassWord(string UserAccount)
        {
            UserBLL myUserBLL = new UserBLL();
            UserModel myUserModel = myUserBLL.GetUserInfoByUserAccount(UserAccount);
            return View("ChangePassWord");
        }


        [HttpPost]
        public JsonResult updatepassword(UserModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                UserBLL myUserBLL = new UserBLL();

                model.User_PWD = model.User_PWD.ToMD5().ToUpper();
                model.CREATE_BY = LoginedUserName;
                model.LAST_MODIFIED_BY = LoginedUserName;
                model.PASSWORD = model.PASSWORD.ToMD5().ToUpper();

                myUserBLL.UpdateUserPassWord(model);
                result.flag = true;

                ActionLog("Sys_User", string.Format("{0}用户更新了密码,新密码", model.User_Account), MVCActionTypeEnum.Update, this.LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult checkpassword(UserModel model)
        {
            var result = new Result<string>();
            try
            {
                UserBLL myUserBLL = new UserBLL();

                UserModel NewModel = myUserBLL.GetUserInfoByUserAccount(model.User_Account);

                if (model.User_PWD.ToMD5().ToUpper() == NewModel.User_PWD.ToUpper())
                {
                    result.flag = true;
                }
                else
                {
                    result.flag = false;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
