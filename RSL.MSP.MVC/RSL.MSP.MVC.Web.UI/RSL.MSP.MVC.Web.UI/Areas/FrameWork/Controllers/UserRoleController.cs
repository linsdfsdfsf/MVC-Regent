using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.Enums;
using RSL.MSP.MVC.Model.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    [Export]
    public class UserRoleController : BaseController
    {
        //
        // GET: /FrameWork/UserRole/

        public ActionResult Index()
        {

            return View();
        }

        // GET: Adm/UserRole/Users
        public ActionResult Users()
        {
            return View();
        }

        /// <summary>
        /// 获取所有的角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRoles()
        {
            RoleBLL myRoleBLL = new RoleBLL();
            var list = myRoleBLL.GetRoleList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMenus()
        {
            MenuBLL myMenuBLL = new MenuBLL();

            var list = myMenuBLL.GetAllMenuList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取指定角色拥有的菜单权限
        /// </summary>
        /// <param name="id">RoleId</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMenuRoleByRoleId(string id)
        {
            //var list = RightService.Query(item => !item.IsDeleted && item.ObjId.Equals(id) && item.ObjType.Equals(0), item => item.Id);

            MenuBLL myMenuBll = new MenuBLL();
            var list = myMenuBll.GetMenuIdListByRoleID(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取不是该角色的菜单权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetNotMenuRoleByRoleId(string id)
        {
            //var list = RightService.Query(item => !item.IsDeleted && item.ObjId.Equals(id) && item.ObjType.Equals(0), item => item.Id);

            MenuBLL myMenuBll = new MenuBLL();
            var list = myMenuBll.GetNotMenuListByRole(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 分配用户角色
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="datas">角色id集合</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRoleMenu(int id, List<RoleMenuModel> datas)
        {
            var result = new Result<string>();
            try
            {

                RoleBLL myRoleBLL = new RoleBLL();


                #region 删除角色菜单关系表，角色菜单按钮关系表

                RoleModel myRoleModel = new RoleModel();
                myRoleModel.ROLE_ID = id;
                myRoleBLL.DeleteMenuRoleAndAction(myRoleModel);


                #endregion

                myRoleBLL.SaveRoleMenuRelation(datas.Where(p => p.ObjType == 0).ToList(), this.LoginedUserID);
                myRoleBLL.SaveRoleMenuActionRelation(datas.Where(p => p.ObjType == 1).ToList(), this.LoginedUserID);

                result.flag = true;
                ActionLog("Sys_UserRoleDto", string.Format("分配了用户角色[{0}]", string.Join(",", datas.Select(item => item.ROLE_ID))), MVCActionTypeEnum.Update, LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 分配用户角色
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="datas">角色id集合</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveUserRole(int id, List<UserRoleModel> datas)
        {
            var result = new Result<string>();
            try
            {
                UserBLL MyUserBLL = new UserBLL();

                foreach (var item in datas)
                {
                    item.IS_VALID = 1;
                    item.CREATE_BY = this.LoginedUserID;
                    MyUserBLL.SaveUserRoleRelation(item);
                }

                //SaveUserRoleRelation

                #region edit by Oceanchai 2016.03.27 註釋掉如下部分

                //RoleBLL myRoleBLL = new RoleBLL();

                #region 删除角色菜单关系表，角色菜单按钮关系表

                //RoleModel myRoleModel = new RoleModel();
                //myRoleModel.ROLE_ID = id;
                //myRoleBLL.DeleteMenuRoleAndAction(myRoleModel);


                #endregion

                //myRoleBLL.SaveRoleMenuRelation(datas.Where(p => p.ObjType == 0).ToList(), this.LoginedUserID);
                //myRoleBLL.SaveRoleMenuActionRelation(datas.Where(p => p.ObjType == 1).ToList(), this.LoginedUserID);

                //foreach (var item in datas)
                //{
                //    RoleMenuModel myRoleMenuModel = new RoleMenuModel();
                //    myRoleMenuModel.ROLE_ID = id;
                //    myRoleMenuModel.MENU_ID = item.MENU_ID;
                //    myRoleMenuModel.Parenet_ID = item.Parenet_ID;
                //    myRoleMenuModel.ObjType = item.ObjType;

                //    myRoleMenuModel.CREATE_BY = this.LoginedUserID;
                //    myRoleMenuModel.IS_VALID = 1;

                //    myRoleBLL.SaveRoleMenuInfo(myRoleMenuModel);

                //}

                #endregion



                result.flag = true;
                ActionLog("Sys_UserRoleDto", string.Format("分配了用户角色[{0}]", string.Join(",", datas.Select(item => item.ROLE_ID))), MVCActionTypeEnum.Update, LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="datas">角色id集合</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ReSaveUserRole(int id, List<UserRoleModel> datas)
        {
            var result = new Result<string>();
            try
            {
                UserBLL myUserBLL = new UserBLL();
                foreach (var item in datas)
                {
                    UserRoleModel model = new UserRoleModel();
                    model.USER_ID = id;
                    model.ROLE_ID = item.ROLE_ID;
                    myUserBLL.DeleteRoleUserByUserID(model);
                }
                result.flag = true;
                ActionLog("Sys_UserRoleDto", string.Format("分配了用户角色[{0}]", string.Join(",", datas.Select(item => item.ROLE_ID))), MVCActionTypeEnum.Update, LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 分页获取Sys_Role
        /// </summary>
        /// <param name="query">QueryBase</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRoleList(int id, QueryBase query)
        {
            try
            {
                UserBLL myUserBLL = new UserBLL();
                ResultDto<RoleModel> dto = myUserBLL.GetNotMyRoleListByUserID(id.ToString(), query);
                return Json(dto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<RoleModel>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 分页获取我的Sys_Role
        /// </summary>
        /// <param name="query">QueryBase</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMyRoleList(int id, QueryBase query)
        {
            try
            {
                UserBLL myUserBLL = new UserBLL();
                ResultDto<RoleModel> dto = myUserBLL.GetRoleInfoListByUserAccount(id.ToString(), query);

                return Json(dto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<RoleModel>(), JsonRequestBehavior.AllowGet);
            }
        }

    }
}