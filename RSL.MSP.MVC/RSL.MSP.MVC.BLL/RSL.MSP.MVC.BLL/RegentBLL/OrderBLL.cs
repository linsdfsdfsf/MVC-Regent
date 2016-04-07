using System;
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

        //取得"訂單統計表"的資料
        public ResultDto<OrderModel> GetOrderListByPage(SearchModel<OrderModel> queryModel, bool page = true)
        {
            return m_orderDAL.GetOrderListByPage(queryModel, page);
        }

        //修改訂單資料 取得欲修改資料
        public OrderModel GetOrderByOrdermId(int User_ID)
        {
            return this.m_orderDAL.GetOrderByOrdermId(User_ID);
        }

        //修改訂單資料 更新資料庫
        public void UpdateOrder(OrderModel order)
        {
            m_orderDAL.UpdateOrder(order);
        }
    }
}
