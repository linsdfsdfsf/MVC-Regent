﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.RegentModel;
using RSL.MSP.MVC.Model;
using RSL.MSP.MVC.DAO.RegentDAO;
using RSL.MSP.MVC.Model.Base;

namespace RSL.MSP.MVC.BLL.Regent
{
    public class OrderBLL
    {
        private OrderDAO m_orderDAL = new OrderDAO();

        //=============================修改====================/

        //取得"訂單統計表"的資料
        public ResultDto<OrderModel> GetOrderListByPage(SearchModel<OrderModel> queryModel, bool page = true)
        {
            return m_orderDAL.GetOrderListByPage(queryModel, page);
        }

        //修改訂單資料 取得欲修改資料
        public OrderModel GetOrderByOrdermId(string ORDERM_ID)
        {
            return this.m_orderDAL.GetOrderByOrdermId(ORDERM_ID);
        }

        //修改訂單資料 更新資料庫
        public void UpdateOrder(OrderModel order)
        {
            m_orderDAL.UpdateOrder(order);
        }
        //=======================新增=============================//

        //新增訂單資料 取得需要的值
        //public OrderModel AddOrderGetDropDownList(OrderModel order)
        //{
        //   return this.m_orderDAL.AddOrderGetDropDownList(order);
        //}

        //新增訂單資料 送出資料 更新資料庫
        public void AddOrder(OrderModel order)
        {
            m_orderDAL.AddOrder(order);
        }
        

        //============================產生下拉選單資料====================//
        // 取得餐廳資料
        public List<RestaurantModel> GetRestaurant()
        {
            return m_orderDAL.GetRestaurant();
        }
        
        // 取得用餐目的資料
        public List<DataRow> GetPurpose()
        {
            return m_orderDAL.GetPurpose();
        }
        
        // 取得開放訂位期限
        public string GetOpenSeatEndDate()
        {
            return m_orderDAL.GetOpenSeatEndDate();
        }


        //取得用餐時段
        public List<DataRow> AjaxGetDailyPeriodId(string RestaurantId, string BookingDate)
        {
            return m_orderDAL.AjaxGetDailyPeriodId(RestaurantId,BookingDate);
        }

        //============其他==================//

        
         //取得用餐人數最大值
        public string GetReservationNumber()
        {
            return m_orderDAL.GetReservationNumber();
        }

        //取得訂單流水號
        public string GetOrderSingleNumber()
        {
            return m_orderDAL.GetOrderSingleNumber();
        }

        //判斷是否超過該時段人數上限
        public bool Check_If_Exceed_Max_Period_Number(string DAILY_PERIOD_ID, string RESERVATION_NUMBER)
        {
            return m_orderDAL.Check_If_Exceed_Max_Period_Number(DAILY_PERIOD_ID, RESERVATION_NUMBER);
        }
    }
}
