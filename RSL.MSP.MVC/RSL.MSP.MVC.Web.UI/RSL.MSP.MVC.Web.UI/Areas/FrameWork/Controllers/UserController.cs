using System.Linq;
using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.Framework;
using RSL.MSP.MVC.Utility.ExtensionHelp;
using System;
using System.Web.Mvc;
using RSL.MSP.MVC.Utility;
using RSL.MSP.MVC.Model.Enums;
using System.Collections.Generic;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Common.AttributeHelper;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /FrameWork/User/

        public ActionResult Index()
        {

            return View();
        }

        [MSPAuthorizeAttribute]
        // GET: Adm/User/Add
        public ActionResult Add()
        {
            ViewBag.CustomerList = new UserBLL().GetCustomerList().Select(item => new SelectListItem { Value = item.CUSTOMER_ID.ToString(), Text = item.CUSTOMER_NAME });
            return View();
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(QueryBase query)
        {
            try
            {
                UserBLL MyUserBLL = new UserBLL();

                QueryModel<UserModel> queryModel = new QueryModel<UserModel>();
                ResultDto<UserModel> dto = MyUserBLL.GetUserListByPage(query);
                return Json(dto, JsonRequestBehavior.AllowGet);

                return null;
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<UserModel>(), JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddModel(UserModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                UserBLL _BLL = new UserBLL();
                UserModel UserModel = new UserModel();
                UserModel.User_Account = model.User_Account;
                UserModel.User_Name = model.User_Name;
                UserModel.IS_CHANGEPWD = model.IS_CHANGEPWD;
                UserModel.User_Tel = model.User_Tel;
                UserModel.User_Email = model.User_Email;
                UserModel.IS_VALID = 1;
                UserModel.User_PWD = model.User_PWD.ToMD5();//密码加密
                UserModel.CREATE_BY = this.LoginedUserID;
                UserModel.CREATE_DATE = System.DateTime.Now;
                UserModel.CUSTOMER_ID = model.CUSTOMER_ID;

                if (_BLL.isUserAccountExit(model.User_Account.Trim()))
                    throw new ArgumentException("账号已经存在");
                else
                {
                    decimal user_id = _BLL.AddUser(UserModel);
                    if (user_id > 0)
                    {
                        result.flag = true;

                    }
                }

                if (result.flag)
                {
                    ActionLog("Sys_User", model, MVCActionTypeEnum.Insert, LoginedUserInfo);
                }


            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Adm/User/Edit
        public ActionResult Edit(int id)
        {
            UserBLL myUserBLL = new UserBLL();
            UserModel myUserModel = myUserBLL.GetUserInfoByUserID(id);

            ViewBag.CustomerList = new UserBLL().GetCustomerList().Select(item => new SelectListItem { Value = item.CUSTOMER_ID.ToString(), Text = item.CUSTOMER_NAME, Selected = (myUserModel.CUSTOMER_ID.ToString() == item.CUSTOMER_ID.ToString()) });


            return View(myUserModel);
        }

        /// <summary>
        /// 删除Sys_User
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

                UserBLL myUserBLL = new UserBLL();

                if (ids.Contains(int.Parse(this.LoginedUserNumber)))
                {
                    throw new ArgumentException("不能删除当前登录用户");
                }
                foreach (int item in ids)
                {
                    myUserBLL.DeleteAllUserInfo(item);
                }
                result.flag = true;
                ActionLog("Sys_Role", string.Format("删除了(用户),ID集合={0}", string.Join(",", ids)), MVCActionTypeEnum.Delete, this.LoginedUserInfo);

                /*
                result.flag = UserService.Delete(ids, CurrentUser);

                if (result.flag)
                {
                    ActionLog("Sys_Role", string.Format("删除了(用户),ID集合={0}", string.Join(",", ids)), ActionType.Delete, CurrentUser);
                }
                 */
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditModel(UserModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                UserBLL myUserBLL = new UserBLL();
                model.User_PWD = model.User_PWD.ToMD5();
                model.IS_VALID = 1;
                model.LAST_MODIFIED_BY = this.LoginedUserID;
                myUserBLL.UpdateUser(model);
                result.flag = true;
                ActionLog("Sys_User", model, MVCActionTypeEnum.Update, this.LoginedUserInfo);
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
