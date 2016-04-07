using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;

namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvSalesDAO : DataAccessBase
    {
        /// <summary>
        /// 查詢交易資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvSalesModel> GetEinvSalesListByPage(QueryModel<EinvSalesModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvSalesList");
            command.SetParameterValue(":SITE_ID", queryModel.Entity.SITE_ID);
            command.SetParameterValue(":SALES_DATE", queryModel.Entity.SALES_DATE);
            command.SetParameterValue(":POS_ID", queryModel.Entity.POS_ID);
            command.SetParameterValue(":TRANS_NO", queryModel.Entity.TRANS_NO);
            command.SetParameterValue(":TRANS_TYPE", queryModel.Entity.TRANS_TYPE);
            command.SetParameterValue(":RECE_TRACK", queryModel.Entity.RECE_TRACK);
            command.SetParameterValue(":GUI_BEGIN", queryModel.Entity.GUI_BEGIN);
            command.SetParameterValue(":USER_ID", queryModel.Entity.USER_ID);


            
            int total;
            if (queryModel.PageSize != 0)
            {
                command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
                queryModel.TotalRecords = total;
            }

            return command.ExecuteEntityList<EinvSalesModel>();
        }

        /// <summary>
        /// 依照key 查詢交易主檔資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public List<EinvSalesModel> GetEinvSalesDataMainByTkey(string _strSales_date, string _strPosId, string _strTransNo)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvSalesMainByKey");
            command.SetParameterValue(":SALES_DATE", _strSales_date.ToString());
            command.SetParameterValue(":TRANS_NO", _strTransNo.ToString());
            command.SetParameterValue(":POS_ID", _strPosId.ToString());

            return command.ExecuteEntityList<EinvSalesModel>();
        }

        /// <summary>
        /// 依照key 查詢交易主檔資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public List<EinvSalesDetailModel> GetEinvSalesDataDetailByTkey(string _strSales_date, string _strPosId, string _strTransNo)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvSalesDetailByKey");
            command.SetParameterValue(":SALES_DATE", _strSales_date.ToString());
            command.SetParameterValue(":TRANS_NO", _strTransNo.ToString());
            command.SetParameterValue(":POS_ID", _strPosId.ToString());

            return command.ExecuteEntityList<EinvSalesDetailModel>();
        }
        
    }
}
