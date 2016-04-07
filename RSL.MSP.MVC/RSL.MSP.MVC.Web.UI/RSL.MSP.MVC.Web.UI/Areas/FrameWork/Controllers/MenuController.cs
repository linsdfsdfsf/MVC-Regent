using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.Enums;
using RSL.MSP.MVC.Model.Framework;
using RSL.MSP.MVC.Utility;
using RSL.MSP.MVC.Utility.ExtensionHelp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    [Export]
    public class MenuController : BaseController
    {
        //[Import]
        //public ISys_MenuSiteContract Sys_MenuService { get; set; }

        // GET: Adm/Sys_Menu
        public ActionResult Index()
        {

            return View();
        }



        // GET: Adm/Sys_Menu/Add
        public ActionResult Add()
        {
            ViewBag.isDisable = 0; //是否鎖定父級菜單：1：鎖定；2：不鎖定；
            InitPageData(0);
            return View();
        }

        public ActionResult AddSubMenu(int menu_id)
        {
            InitPageData(menu_id);
            ViewBag.isDisable = 1; //是否鎖定父級菜單：1：鎖定；2：不鎖定；
            return View("Add");
        }


        public ActionResult ActionList(int menu_id, int isSelected)
        {
            MenuBLL myMenuBLL = new MenuBLL();
            List<ActionModel> myActionList = myMenuBLL.GetMenuActionListIsSelected(menu_id);
            ViewBag.ActionList = myActionList;
            ViewBag.isSelected = isSelected;
            return PartialView("ActionList");
        }

        // GET: Adm/Sys_Menu/Edit/{id}
        public ActionResult Edit(int id)
        {
            //var model = Sys_MenuService.GetByKeyId(id);
            MenuBLL myMenuBLL = new MenuBLL();
            MenuModel myMenuModel = myMenuBLL.GetMenuInfoByID(id);
            InitPageData(myMenuModel.P_Menu_ID.ToInt32());
            return View(myMenuModel);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedId"></param>
        private void InitPageData(int selectedId)
        {
            //父类
            //var list = Sys_MenuService.Query(item => !item.IsDeleted && !item.IsButton, item => item.Id);
            MenuBLL myMenuBLL = new MenuBLL();
            List<MenuModel> list = myMenuBLL.GetAllMenuModelList();
            TreeHelper th = new TreeHelper();
            th.BuildTree(list, 0, selectedId);
            ViewBag.ParentList = th.Results;


            //List<ActionModel> myActionList = myMenuBLL.GetAllActionList();
            //ViewBag.ActionList=myActionList;

        }

        /// <summary>
        /// 分页获取Sys_Menu
        /// </summary>
        /// <param name="query">QueryBase</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(QueryBase query)
        {
            try
            {
                MenuBLL myMenuBLL = new MenuBLL();
                ResultDto<MenuModel> dto = myMenuBLL.GetMenuListByPage(query);
                return Json(dto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<MenuModel>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 添加Sys_Menu
        /// </summary>
        /// <param name="model">Sys_MenuDto</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddModel(MenuModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                MenuBLL myMenuBLL = new MenuBLL();

                model.CREATE_BY = this.LoginedUserID;
                model.IS_VALID = 1;
                myMenuBLL.AddMenu(model);
                result.flag = true;
                ActionLog("Sys_Menu", model, MVCActionTypeEnum.Insert, this.LoginedUserInfo);

            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据前端传进来的已经选择的ActionList，得到List对象
        /// </summary>
        /// <param name="strSlectedActionList"></param>
        /// <returns></returns>
        private List<MenuActionModel> GetMenuActionList(string strSlectedActionList)
        {

            if (strSlectedActionList != null && strSlectedActionList.Trim().Length > 0)
            {
                string[] str = strSlectedActionList.Split(',');
                List<MenuActionModel> myActionList = new List<MenuActionModel>();
                foreach (var item in str)
                {
                    MenuActionModel myMenuActionModel = new MenuActionModel();
                    myMenuActionModel.Action_Name = item;
                    myMenuActionModel.CREATE_BY = this.LoginedUserID;
                    myActionList.Add(myMenuActionModel);
                }

                return myActionList;
            }
            else
            {
                return null;
            }



        }


        /// <summary>
        /// 编辑Sys_Menu
        /// </summary>
        /// <param name="model">Sys_MenuDto</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditModel(MenuModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                MenuBLL myMenuBLL = new MenuBLL();
                model.LAST_MODIFIED_BY = this.LoginedUserID;
                //model.MenuActionList = GetMenuActionList(model.Menu_URL);
                model.IS_VALID = 1;
                model.CREATE_BY = this.LoginedUserID;
                myMenuBLL.UpdateMenu(model);
                result.flag = true;
                ActionLog("Sys_Menu", model, MVCActionTypeEnum.Update, this.LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除Sys_Menu
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteModel(List<int> ids)
        {
            var result = new Result<string>();
            MenuBLL myMenuBLL = new MenuBLL();
            try
            {
                if (ids == null || ids.Count == 0)
                    throw new ArgumentException("参数错误");

                foreach (int item in ids)
                {

                    if (myMenuBLL.CheckMenuExistsChild(item))
                    {
                        throw new ArgumentException("请先删除子菜单");
                    }
                }

                foreach (int item in ids)
                {

                    myMenuBLL.DelMenuInfo(item);
                }
                result.flag = true;
                ActionLog("Sys_Menu", string.Format("删除了(菜单),ID集合={0}", string.Join(",", ids)), MVCActionTypeEnum.Delete, this.LoginedUserInfo);

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
