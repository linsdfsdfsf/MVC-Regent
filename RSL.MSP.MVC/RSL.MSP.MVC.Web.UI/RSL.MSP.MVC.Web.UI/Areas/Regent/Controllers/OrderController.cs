using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.RegentModel;
using RSL.MSP.MVC.BLL.Regent;
using System.Net;
using RSL.MSP.MVC.Model.Base;
using RSL.MSP.MVC.Common;


namespace RSL.MSP.MVC.Web.UI.Areas.Regent.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Regent/Order/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(SearchModel<OrderModel> queryModel)
        {
            try
            {
                OrderBLL MyOrderBLL = new OrderBLL();

                ResultDto<OrderModel> dto = MyOrderBLL.GetOrderListByPage(queryModel, true);
                return Json(dto, JsonRequestBehavior.AllowGet);
                //return null;
            }
            catch (Exception ex)
            {
                return Json(new ResultDto<OrderModel>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// function: 特店管理系統 - 基本資料
        /// Editor: Kafaka Lin
        [AcceptVerbs(WebRequestMethods.Http.Get, WebRequestMethods.Http.Post)]
        public ActionResult Add(string merchantId)
        {
            return View();

        }

        // 取得要編輯的訂單資料
        public ActionResult Edit(int id)
        {
            OrderBLL MyOrderBLL = new OrderBLL();
            OrderModel myUserModel = MyOrderBLL.GetOrderByOrdermId(id);

           // ViewBag.CustomerList = new UserBLL().GetCustomerList().Select(item => new SelectListItem { Value = item.CUSTOMER_ID.ToString(), Text = item.CUSTOMER_NAME, Selected = (myUserModel.Customer_ID == item.CUSTOMER_ID.ToString()) });


            return View(myUserModel);
        }

        //編輯訂單資料 送出
        [HttpPost]
        public JsonResult EditModel(OrderModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("參數錯誤");

                OrderBLL myOrderBLL = new OrderBLL();
                model.CUSER = Session["LoginedUserID"] == null ? "" : Session["LoginedUserID"].ToString();
                model.CTIME = null;
                myOrderBLL.UpdateOrder(model);
                result.flag = true;
            }
            catch (Exception ex)
            {
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
