using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSL.MSP.MVC.Model.Base;
using RSL.MSP.MVC.Model.RegentModel;
using RSL.MSP.MVC.Model;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.DAO.Common;
using System.Data;
using Oracle.DataAccess.Client;
using RSL.MSP.MVC.DAO.Common.Data;
using System.Web;
using System.Web.Mvc;
//using System.Data.OracleClient;
//using System.Data;

namespace RSL.MSP.MVC.DAO.RegentDAO
{
    public class OrderDAO
    {
        //取得訂單資料 用於jqGrid
        public ResultDto<OrderModel> GetOrderListByPage(SearchModel<OrderModel> queryModel, bool page = true)
        {
            ResultDto<OrderModel> _Result = new ResultDto<OrderModel>();
            try
            {
                DataCommand command = DataCommandManager.GetDataCommand("GetOrderByPage");
                string a = command.CommandText;
                command.SetParameterValue(":ORDERM_ID", queryModel.SearchKey == null ? Convert.DBNull : queryModel.SearchKey[0].ORDERM_ID);
                command.SetParameterValue(":BOOKING_TYPE", queryModel.SearchKey == null ? Convert.DBNull : queryModel.SearchKey[0].BOOKING_TYPE);
                command.SetParameterValue(":BOOKING_DATE_B", queryModel.SearchKey == null ? Convert.DBNull : queryModel.SearchKey[0].BOOKING_DATE_B);
                command.SetParameterValue(":BOOKING_DATE_E", queryModel.SearchKey == null ? Convert.DBNull : queryModel.SearchKey[0].BOOKING_DATE_E);
                command.SetParameterValue(":BOOKING_STATUS", queryModel.SearchKey == null ? Convert.DBNull : queryModel.SearchKey[0].BOOKING_STATUS);

                if (page)
                {
                    int total;
                    command.SetPageInfo(queryModel.page - 1, queryModel.rows, out total);
                    _Result.rows = command.ExecuteEntityList<OrderModel>();
                    _Result.records = total;
                    _Result.page = queryModel.page;
                    _Result.pagesize = queryModel.rows;
                }
                else
                {
                    _Result.rows = command.ExecuteEntityList<OrderModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        //修改訂單資料 取得欲修改訂單的資料
        public OrderModel GetOrderByOrdermId(string ORDERM_ID)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetOrderByOrdermId");
            command.SetParameterValue(":ORDERM_ID", ORDERM_ID);
            return command.ExecuteEntity<OrderModel>();
        }

        //修改訂單資料 送出修改資料
        public void  UpdateOrder(OrderModel order)
        {
            try
            {
                DataCommand command = DataCommandManager.GetDataCommand("UpdateOrder");
                command.SetParameterValue(":ORDERM_ID", order.ORDERM_ID);
                command.SetParameterValue(":BOOKING_TYPE", order.BOOKING_TYPE);
                command.SetParameterValue(":RESTAURANT_ID", order.RESTAURANT_ID);
                command.SetParameterValue(":DAILY_PERIOD_ID", order.DAILY_PERIOD_ID);
                command.SetParameterValue(":BOOKING_DATE", order.BOOKING_DATE);
                command.SetParameterValue(":RESERVATION_NUMBER", order.RESERVATION_NUMBER);
                command.SetParameterValue(":BOOKING_STATUS", order.BOOKING_STATUS);
                command.SetParameterValue(":CUS_NAME", order.CUS_NAME);
                command.SetParameterValue(":CUS_GENDER", order.CUS_GENDER);
                command.SetParameterValue(":CUS_EMAIL", order.CUS_EMAIL);
                command.SetParameterValue(":CUS_TEL", order.CUS_TEL);
                command.SetParameterValue(":PURPOSE", order.PURPOSE);
                command.SetParameterValue(":CUS_NOTE", order.CUS_NOTE);
                command.SetParameterValue(":CUSER", order.CUSER);
                command.SetParameterValue(":ORDER_OK_DATE", order.ORDER_OK_DATE);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }

        //================================新增==============================//

        //新增訂單資料 取得需要的值
        //public OrderModel AddOrderGetDropDownList(OrderModel order)
        //{
        //    DataCommand command = DataCommandManager.GetDataCommand("AddOrderGetDropDownList");
        //    command.SetParameterValue(":ORDERM_ID", order.ORDERM_ID);
        //    return command.ExecuteEntity<OrderModel>();
        //}

        //新增訂單資料 送出訂單資料
        public void AddOrder(OrderModel order)
        {
            try
            {
                DataCommand command = DataCommandManager.GetDataCommand("AddOrder");
                command.SetParameterValue(":ORDERM_ID", order.ORDERM_ID);
                command.SetParameterValue(":BOOKING_TYPE", order.BOOKING_TYPE);
                command.SetParameterValue(":RESTAURANT_ID", order.RESTAURANT_ID);
                command.SetParameterValue(":DAILY_PERIOD_ID", order.DAILY_PERIOD_ID);
                command.SetParameterValue(":BOOKING_DATE", order.BOOKING_DATE);
                command.SetParameterValue(":RESERVATION_NUMBER", order.RESERVATION_NUMBER);
                command.SetParameterValue(":BOOKING_STATUS", order.BOOKING_STATUS);
                command.SetParameterValue(":CUS_NAME", order.CUS_NAME);
                command.SetParameterValue(":CUS_GENDER", order.CUS_GENDER);
                command.SetParameterValue(":CUS_EMAIL", order.CUS_EMAIL);
                command.SetParameterValue(":CUS_TEL", order.CUS_TEL);
                command.SetParameterValue(":PURPOSE", order.PURPOSE);
                command.SetParameterValue(":ORDER_OK_DATE", order.ORDER_OK_DATE);
                command.SetParameterValue(":CUS_NOTE", order.CUS_NOTE);
                command.SetParameterValue(":BUSER", order.BUSER);
                command.ExecuteNonQuery();
            }
            catch(Exception e){
                throw e;
                }
            
        }
        
        //========================取得下拉選單資料====================//

        //取得餐廳資料
        public List<RestaurantModel> GetRestaurant()
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetRestaurant");
            return command.ExecuteEntityList<RestaurantModel>();
        }
        
        //取得用餐目的資料
        public List<DataRow> GetPurpose()
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetPurpose");
            var ds = command.ExecuteDataSet();
            List<DataRow> list = ds.Tables[0].AsEnumerable().ToList();
            return list;
        }
        
        //取得開放訂位期限
        public string GetOpenSeatEndDate()
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetOpenSeatEndDate");
            var ds = command.ExecuteDataSet();
            string result = ds.Tables[0].Rows[0]["PARAMETER_VALUE"].ToString();
            return result;
        }

        //取得用餐時段
        public List<DataRow> AjaxGetDailyPeriodId(string RestaurantId, string BookingDate)
        {
            DataCommand command = DataCommandManager.GetDataCommand("AjaxGetDailyPeriodId");
            command.SetParameterValue(":RESTAURANT_ID", RestaurantId);
            command.SetParameterValue(":BOOKING_DATE", BookingDate);
            var ds = command.ExecuteDataSet();
            List<DataRow> list = ds.Tables[0].AsEnumerable().ToList();
            return list;
        }

        //=========================其他========================//


        //取得用餐人數最大值(單筆訂單的限制 非計算該時段是否超過總訂單人數)
        public string GetReservationNumber()
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetReservationNumber");
            var ds = command.ExecuteDataSet();
            string result = ds.Tables[0].Rows[0]["PARAMETER_VALUE"].ToString();
            return result;
        }
        
        //取得訂單流水號
        public string GetOrderSingleNumber() {
            string p_sql = "REGENT_BS.SP_GET_SINGLE_NUMBER";
            using (DataCommandProcedure cmd = DataCommandFactory.CreateDataCommand2(p_sql, CommandType.StoredProcedure))
            {
                cmd.AddParameter("sdbtablename", "ORDERM");
                cmd.AddParameter("stablecolumn", "ORDERM_ID");
                cmd.AddParameter("sLENGTH", 5);//流水號補零
                cmd.AddParameter("sparameter_01", "132");
                cmd.AddParameter("sparameter_02", "");
                cmd.AddParameter("sparameter_03", "");
                cmd.AddParameter("sparameter_04", "");
                cmd.AddParameter("sparameter_05", "");
                cmd.AddParameter("sSYSTEM_SEQ", "1",DataType.String, ParameterDirection.Output,50);//將storeProcedure的回傳結果丟到這個參數

                cmd.ExecuteNonQuery();
                string result = cmd.GetParameterValue("sSYSTEM_SEQ").ToString();

                //var ds = cmd.ExecuteDataRow();
                //string result = ds.;
                return result;
            }
        }

        //判斷訂位人數是否大於時段上限
        public bool Check_If_Exceed_Max_Period_Number(string DAILY_PERIOD_ID, string RESERVATION_NUMBER)
        {
            bool result = false;
            DataCommand command = DataCommandManager.GetDataCommand("Check_If_Exceed_Max_Period_Number");
            command.SetParameterValue(":DAILY_PERIOD_ID", DAILY_PERIOD_ID);
            command.SetParameterValue(":RESERVATION_NUMBER", RESERVATION_NUMBER);
            string a=command.CommandText;
            var ds = command.ExecuteDataSet();
            string msg = ds.Tables[0].Rows[0][0].ToString();
            if (msg.ToUpper() == "超過") {
                result = true;
            }
            else if (msg.ToUpper() == "未超過")
            {
                result = false;
            }
            return result;
        }
    }
}
