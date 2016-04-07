using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;

namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvUploadDAO : DataAccessBase
    {
        /// <summary>
        /// 查詢交易資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvUploadModel> GetEinvUploadListByPage(QueryModel<EinvUploadModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvUploadList");
            command.SetParameterValue(":SITE_ID", queryModel.Entity.SITE_ID);
            command.SetParameterValue(":SITE_NAME", queryModel.Entity.SITE_NAME);
            command.SetParameterValue(":MESSAGE_TYPE", queryModel.Entity.MESSAGE_TYPE);
            command.SetParameterValue(":INVOICE_IDENTIFIER", queryModel.Entity.INVOICE_IDENTIFIER);
            command.SetParameterValue(":INV_DATE", queryModel.Entity.INV_DATE);
            command.SetParameterValue(":STATUS", queryModel.Entity.STATUS);
            command.SetParameterValue(":USER_ID", queryModel.Entity.USER_ID);
            command.SetParameterValue(":ROW_NUM", queryModel.Entity.ROW_NUM);
            

            int total;
            if (queryModel.PageSize != 0)
            {
                command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
                queryModel.TotalRecords = total;
            }
            return command.ExecuteEntityList<EinvUploadModel>();
        }

        /// <summary>
        /// 依照條件找錯誤資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public EinvUploadModel GetEinvUpdateDataBykey(string _strMsgType, string _strSeqNo, string _strSubSeqNo, string _strUuid)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvUploadByKey");
            command.SetParameterValue(":MESSAGE_TYPE", _strMsgType.ToString());
            command.SetParameterValue(":SEQNO", _strSeqNo.ToString());
            command.SetParameterValue(":SUBSEQNO", _strSubSeqNo.ToString());
            //command.SetParameterValue(":UUID", _strUuid.ToString());            

            
            return command.ExecuteEntity<EinvUploadModel>();
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
