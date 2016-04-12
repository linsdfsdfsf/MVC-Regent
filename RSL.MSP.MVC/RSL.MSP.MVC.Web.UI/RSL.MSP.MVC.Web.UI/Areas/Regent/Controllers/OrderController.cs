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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


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

        //======================================================================//
        //                                  新增
        //======================================================================//

        /// 頁面:新增訂單資料 動作:取得資料
        public ActionResult Add()
        {
            try
            {
                //取得餐廳資料填入下拉選單
                List<RestaurantModel> myRestaurantList = MyOrderBLL.GetRestaurant();
                ViewBag.RestaurantList = myRestaurantList;

                //取得訂餐目的資料填入下拉選單
                List<DataRow> myPurpost = MyOrderBLL.GetPurpose();
                ViewBag.PurposeList = myPurpost;

                //取得開放訂位最後期限
                string mySeatEndDate = MyOrderBLL.GetOpenSeatEndDate();
                ViewBag.OpenSeatEndDate = mySeatEndDate;

                //取得用餐人數最大值(單筆訂單的限制 非計算該時段是否超過總訂單人數)
                string myMaxReservationNumber = MyOrderBLL.GetReservationNumber();
                ViewBag.MaxReservationNumber = myMaxReservationNumber;

                // ViewBag.CustomerList = new OrderBLL().GetCustomerList().Select(item => new SelectListItem { Value = item.CUSTOMER_ID.ToString(), Text = item.CUSTOMER_NAME });
                return View();
            }
            catch (Exception e) {
                throw e;
            }

        }

        //頁面:新增訂單資料 動作:送出資料
        [HttpPost]
        public ActionResult AddModel(OrderModel model)
        {
            JObject jo = new JObject();
            var result = new Result<string>();
            try
            {
                if (model == null)
                    throw new ArgumentException("參數錯誤");

                OrderBLL _BLL = new OrderBLL();

                //填入訂單編號和新增者名稱
                model.ORDERM_ID = model.DAILY_PERIOD_ID+_BLL.GetOrderSingleNumber();
                model.BUSER = Session["LoginedUserID"] == null ? "" : Session["LoginedUserID"].ToString();
                
                //驗證時段是否正確
                var res = this.MyOrderBLL.AjaxGetDailyPeriodId(model.RESTAURANT_ID, model.BOOKING_DATE);
                var resultBool = res.Any(row => row["DAILY_PERIOD_ID"].Equals(model.DAILY_PERIOD_ID));
                if (!resultBool)
                {
                    throw new ArgumentException("找不到此時段");
                }

                //驗證用餐人數是否正確
                bool NumberCheck = false;
                string myMaxReservationNumber = MyOrderBLL.GetReservationNumber(); //取單筆用餐人數最大值
                //判斷用餐人數是否超過該時段上限 如果未超過會回傳false 如果已超過會回傳True
                 NumberCheck= AjaxCheck_If_Exceed_Max_Period_Number(model.DAILY_PERIOD_ID, model.RESERVATION_NUMBER);
                 if (Convert.ToInt32(model.RESERVATION_NUMBER) > Convert.ToInt32(myMaxReservationNumber) || NumberCheck)
                 {
                     throw new ArgumentException("用餐人數超過限制");
                 }


                _BLL.AddOrder(model);
                jo.Add("result", true);

                jo.Add("msg", "新增成功");


            }
            catch (Exception ex)
            {
               // result.msg = ex.Message;
                jo.Add("result", false);

                jo.Add("msg", "新增失敗");
            }
            return Content(JsonConvert.SerializeObject(jo), "application/json");
          //  return Json(result);
        }

        private void AjaxCheck_If_Exceed_Max_Period_Number()
        {
            throw new NotImplementedException();
        }

        //======================================================================//
        //                                  編輯
        //======================================================================//


        // 頁面:編輯訂單資料 動作:取得資料
        public ActionResult Edit(string id)
        {
            //取得此訂單編號的資料
            OrderBLL MyOrderBLL = new OrderBLL();
            OrderModel myUserModel = MyOrderBLL.GetOrderByOrdermId(id);

            //取得餐廳資料填入下拉選單
            List<RestaurantModel> myRestaurantList = MyOrderBLL.GetRestaurant();
            ViewBag.RestaurantList = myRestaurantList;

            //取得訂餐目的資料填入下拉選單
            List<DataRow> myPurpost = MyOrderBLL.GetPurpose();
            ViewBag.PurposeList = myPurpost;

            //取得開放訂位最後期限
            string mySeatEndDate = MyOrderBLL.GetOpenSeatEndDate();
            ViewBag.OpenSeatEndDate = mySeatEndDate;

            //取得用餐人數最大值(單筆訂單的限制 非計算該時段是否超過總訂單人數)
            string myMaxReservationNumber = MyOrderBLL.GetReservationNumber();
            ViewBag.MaxReservationNumber = myMaxReservationNumber;

            return View(myUserModel);
        }

        //頁面:編輯訂單資料 動作:送出
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

        //======================================================================//
        //                                  Ajax 取得資料
        //======================================================================//


        //取得用餐時段資料
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

                    //串dropDownList語法(外層迴圈 將select option分組 內層迴圈 傳入option的list)
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

                }

                return Content(sb.ToString());
            }
            catch (Exception e) {
                throw e;
            }

        }

        //判斷訂位人數是否大於時段上限
        [HttpPost]
        public bool AjaxCheck_If_Exceed_Max_Period_Number(string DAILY_PERIOD_ID, string RESERVATION_NUMBER)
        {
            try
            {
                return this.MyOrderBLL.Check_If_Exceed_Max_Period_Number(DAILY_PERIOD_ID, RESERVATION_NUMBER);
            }
            catch (Exception e) {
                throw e;
            }
        }

    }
}
