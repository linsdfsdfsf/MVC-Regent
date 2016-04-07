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
    public class RoleController : BaseController
    {
        //
        // GET: /FrameWork/Role/

        //[Import]
        //public ISys_RoleSiteContract Sys_RoleService { get; set; }

        // GET: Adm/Role
        public ActionResult Index()
        {
        
            return View();
        }

        // GET: Adm/Role/Add
        public ActionResult Add()
        {
            return View();
        }

        // GET: Adm/Role/Edit/{id}
        public ActionResult Edit(int id)
        {
            //var model = Sys_RoleService.GetByKeyId(id);

            RoleBLL myRoleBLL = new RoleBLL();

            RoleModel model = myRoleBLL.GetRoleInfoByRoleID(id);

            return View(model);
        }

        /// <summary>
        /// 分页获取Sys_Role
        /// </summary>
        /// <param name="query">QueryBase</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(QueryBase query)
        {
            try
            {
                RoleBLL myRoleBLL = new RoleBLL();
                ResultDto<RoleModel> dto = myRoleBLL.GetRoleListByPage(query);
                return Json(dto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<RoleModel>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 添加Sys_Role
        /// </summary>
        /// <param name="model">Sys_RoleDto</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddModel(RoleModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");


                RoleBLL myRoleBLL = new RoleBLL();
                RoleModel myRoleModel = new RoleModel();
                myRoleModel.ROLE_NAME = model.ROLE_NAME.Trim();
                myRoleModel.CREATE_BY = this.LoginedUserID;
                myRoleModel.Role_Remark = model.Role_Remark;
                myRoleModel.IS_VALID = 1;

                if (myRoleBLL.GetRoleByRoleNameAdd(model.ROLE_NAME.Trim()))
                    throw new ArgumentException("角色已经存在");
                else
                {
                    RoleModel _RoleModel = myRoleBLL.AddRoleInfo(myRoleModel);
                    if (_RoleModel.ROLE_ID > 0)
                    {
                        result.flag = true;
                    }
                }

                if (result.flag)
                {
                    ActionLog("Sys_Role", model, MVCActionTypeEnum.Insert, this.LoginedUserInfo);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑Sys_Role
        /// </summary>
        /// <param name="model">Sys_RoleDto</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditModel(RoleModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                RoleBLL myRoleBLL = new RoleBLL();
                RoleModel myRoleModel = new RoleModel();
                myRoleModel.ROLE_NAME = model.ROLE_NAME.Trim();
                myRoleModel.LAST_MODIFIED_BY = this.LoginedUserID;
                myRoleModel.ROLE_ID = model.ROLE_ID;
                myRoleModel.Role_Remark = model.Role_Remark;
                myRoleModel.IS_VALID = 1;

                if (myRoleBLL.GetRoleByRoleNameUpdate(model.ROLE_NAME.Trim(), model.ROLE_ID.ToString()))
                    throw new ArgumentException("角色已经存在");
                else
                {
                    myRoleBLL.UpdateRoleInfo(myRoleModel);
                    result.flag = true;
                }
                ActionLog("Sys_Role", model, MVCActionTypeEnum.Update, LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除Sys_Role
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteModel(List<int> ids)
        {
            var result = new Result<string>();
            try
            {
                if (ids == null || ids.Count == 0)
                    throw new ArgumentException("参数错误");


                RoleBLL myRoleBLL = new RoleBLL();
                foreach (int item in ids)
                {
                    myRoleBLL.DelRoleInfo(item);
                }
                result.flag = true;
                ActionLog("Sys_Role", string.Format("删除了(角色),ID集合={0}", string.Join(",", ids)), MVCActionTypeEnum.Delete, LoginedUserInfo);
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
