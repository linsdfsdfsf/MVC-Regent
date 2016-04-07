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
        public OrderModel GetOrderByOrdermId(int User_ID)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetOrderByOrdermId");
            command.SetParameterValue("@User_ID", User_ID);
            return command.ExecuteEntity<OrderModel>();
        }

        //修改訂單資料 送出修改資料
        public void  UpdateOrder(OrderModel order)
        {
            DataCommand command = DataCommandManager.GetDataCommand("UpdateOrder");
            command.SetParameterValue("@User_Account", order.ORDERM_ID);
            //command.SetParameterValue("@User_pwd", order.User_PWD);
            //command.SetParameterValue("@User_Name", order.User_Name);
            //command.SetParameterValue("@Customer_ID", order.Customer_ID);
            //command.SetParameterValue("@User_Email", order.User_Email);
            //command.SetParameterValue("@User_Tel", order.User_Tel);
            //command.SetParameterValue("@Is_Valid", order.IS_VALID);
            //command.SetParameterValue("@LAST_MODIFIED_BY", order.LAST_MODIFIED_BY);
            command.ExecuteNonQuery();
        
        }

    }
}
