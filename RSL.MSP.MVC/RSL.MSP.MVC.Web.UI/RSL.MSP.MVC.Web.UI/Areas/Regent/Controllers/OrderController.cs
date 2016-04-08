using System;
using System.Data;
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
using System.Text;


namespace RSL.MSP.MVC.Web.UI.Areas.Regent.Controllers
{
    public class OrderController : Controller
    {
        OrderBLL MyOrderBLL = new OrderBLL();
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

        //========================================新增==============================//
        /// 新增訂單資料 取得資料
        public ActionResult Add()
        {
            //取得餐廳資料填入下拉選單
            List<RestaurantModel> myRestaurantList = MyOrderBLL.GetRestaurant();
            ViewBag.RestaurantList = myRestaurantList;

            //取得訂餐目的資料填入下拉選單
            List<DataRow> myPurpost = MyOrderBLL.GetPurpose();
            ViewBag.PurposeList = myPurpost;

            //取得開放訂位最後期階
            string mySeatEndDate = MyOrderBLL.GetOpenSeatEndDate();
            ViewBag.OpenSeatEndDate = mySeatEndDate;

           // ViewBag.CustomerList = new OrderBLL().GetCustomerList().Select(item => new SelectListItem { Value = item.CUSTOMER_ID.ToString(), Text = item.CUSTOMER_NAME });
            return View();

        }

        //新增訂單資料 送出資料
        [HttpPost]
        public JsonResult AddModel(OrderModel model)
        {
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("参数错误");

                OrderBLL _BLL = new OrderBLL();
                OrderModel OrderModel = new OrderModel();
                //UserModel.User_Account = model.User_Account;
                //UserModel.User_Name = model.User_Name;
                //UserModel.IS_CHANGEPWD = model.IS_CHANGEPWD;
                //UserModel.User_Tel = model.User_Tel;
                //UserModel.User_Email = model.User_Email;
                //UserModel.IS_VALID = 1;
                //UserModel.User_PWD = model.User_PWD.ToMD5();//密码加密
                //UserModel.CREATE_BY = this.LoginedUserID;
                //UserModel.CREATE_DATE = System.DateTime.Now;
                //UserModel.Customer_ID = model.Customer_ID;


                _BLL.AddOrder(OrderModel);

            }
            catch (Exception ex)
            {
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //========================================編輯==============================//


        // 取得要編輯的訂單資料
        public ActionResult Edit(string id)
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

        //=====================Ajax 取得資料===============//
        [HttpPost]

        public ActionResult AjaxGetDailyPeriodId(string RestaurantId, string BookingDate)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(RestaurantId) && !string.IsNullOrWhiteSpace(BookingDate))
                {
                    var res = this.MyOrderBLL.AjaxGetDailyPeriodId(RestaurantId, BookingDate);
                    //將取出來的datarow資料依照Period_group_name分組
                    var TimeByPeriod = from car in res
                                     group car by car.Field<string>("PERIOD_GROUP_NAME")
                                         into PeriodGroup
                                           select new { Type = PeriodGroup.Key, Period = PeriodGroup.ToList() };

                    //串dropDownList語法
                    foreach (var type in TimeByPeriod)
                    {
                        sb.AppendFormat("<optgroup label=\"{0}\">",
                            type.Type
                        );

                        foreach (var item in type.Period)
                        {
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>",
                                item[0].ToString(),
                                item[1].ToString()
                            );
                        }

                        sb.AppendFormat("</optgroup>");
                    }
                    ///////////////
                    //var counties = this.MyOrderBLL.AjaxGetDailyPeriodId(RestaurantId, BookingDate);

                    //foreach (var item in counties)
                    //{

                    //    sb.AppendFormat("<option value=\"{0}\">{1}({2})</option>",
                    //        item[0].ToString(),
                    //        item[2].ToString(),
                    //        item[1].ToString()
                    //    );
                    //}

                }

                return Content(sb.ToString());
            }
            catch (Exception e) {
                throw e;
            }

        } 


    }
}
