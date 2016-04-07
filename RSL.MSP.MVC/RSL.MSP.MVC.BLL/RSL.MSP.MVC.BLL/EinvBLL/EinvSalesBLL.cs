using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;
using RSL.MSP.MVC.DAO.EinvDAO;

namespace RSL.MSP.MVC.BLL.EinvBLL
{
    public class EinvSalesBLL
    {
        EinvSalesDAO MyEinvSalesDAO = new EinvSalesDAO();
        /// <summary>
        /// 查詢交易資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvSalesModel> GetEinvSalesListByPage(QueryModel<EinvSalesModel> queryModel)
        {
            return MyEinvSalesDAO.GetEinvSalesListByPage(queryModel);
        }

        /// <summary>
        /// 依照T_key 找發票M資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public List<EinvSalesModel> GetEinvSalesDataMainByTkey(string _strSales_date, string _strPosId, string _strTransNo)
        {
            return MyEinvSalesDAO.GetEinvSalesDataMainByTkey(_strSales_date, _strPosId, _strTransNo);
        }

        /// <summary>
        /// 依照T_key 找發票D資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public List<EinvSalesDetailModel> GetEinvSalesDataDetailByTkey(string _strSales_date, string _strPosId, string _strTransNo)
        {
            return MyEinvSalesDAO.GetEinvSalesDataDetailByTkey(_strSales_date, _strPosId, _strTransNo);
        }


    }
}
