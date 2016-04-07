using RSL.MSP.MVC.BLL.Framework;
using RSL.MSP.MVC.Common.ControllerHelper;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.Enums;
using RSL.MSP.MVC.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers
{
    public class CustomerController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Adm/User/Add
        public ActionResult Add()
        {

            return View();
        }


        // GET: Adm/User/Edit
        public ActionResult Edit(int id)
        {
            CustomerBLL _BLL = new CustomerBLL();
            CustomerModel myCustomerModel = _BLL.GetCustomerModelInfo(id);
            return View(myCustomerModel);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddModel(CustomerModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");



                CustomerBLL _BLL = new CustomerBLL();
                CustomerModel myCustomerModel = new CustomerModel();

                if (_BLL.isCustomerNameExists(model.CUSTOMER_NAME.Trim()))
                    throw new ArgumentException("特店名稱已經存在!");
                else
                {
                    myCustomerModel.CUSTOMER_NAME = model.CUSTOMER_NAME;
                    myCustomerModel.CUSTOMER_REMARK = model.CUSTOMER_REMARK;
                    myCustomerModel.DB_NAME = model.DB_NAME;
                    myCustomerModel.CREATE_BY = this.LoginedUserID;

                    if (_BLL.AddCustomerInfo(myCustomerModel))
                    {
                        result.flag = true;
                    }
                }
                if (result.flag)
                {
                    ActionLog("Sys_Customer", model, MVCActionTypeEnum.Insert, LoginedUserInfo);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditModel(CustomerModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                CustomerBLL _BLL = new CustomerBLL();
                CustomerModel myCustomerModel = new CustomerModel();

                if (_BLL.isCustomerNameExists(model.CUSTOMER_NAME))
                {
                    throw new ArgumentException("角色已经存在");
                }
                else
                {
                    myCustomerModel.CUSTOMER_ID = model.CUSTOMER_ID;
                    myCustomerModel.CUSTOMER_NAME = model.CUSTOMER_NAME;
                    myCustomerModel.CUSTOMER_REMARK = model.CUSTOMER_REMARK;
                    myCustomerModel.DB_NAME = model.DB_NAME;
                    myCustomerModel.LAST_MODIFIED_BY = this.LoginedUserID;

                    _BLL.UpdateCustomerInfo(myCustomerModel);
                    result.flag = true;
                }
                ActionLog("Sys_Customer", model, MVCActionTypeEnum.Update, LoginedUserInfo);
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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
                CustomerBLL MyCustomerBLL = new CustomerBLL();

                QueryModel<CustomerModel> queryModel = new QueryModel<CustomerModel>();
                ResultDto<CustomerModel> dto = MyCustomerBLL.GetCustomerListByPage(query);
                return Json(dto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log(ex);
                return Json(new ResultDto<CustomerModel>(), JsonRequestBehavior.AllowGet);
            }
        }

    }
}