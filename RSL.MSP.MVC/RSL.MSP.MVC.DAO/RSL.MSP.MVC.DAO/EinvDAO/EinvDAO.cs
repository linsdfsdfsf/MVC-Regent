using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;

namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvDAO : DataAccessBase
    {
        /// <summary>
        /// 查詢發票資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvModel> GetEinvListByPage(QueryModel<EinvModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvInvList");
            command.SetParameterValue(":INV_YM", queryModel.Entity.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.Entity.TRACK);
            command.SetParameterValue(":SITE_ID", queryModel.Entity.SITE_ID);
            command.SetParameterValue(":USER_ID", queryModel.Entity.USER_ID);
            
            int total;
            command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
            queryModel.TotalRecords = total;
            return command.ExecuteEntityList<EinvModel>();
        }

        /// <summary>
        /// 查詢可配號發票資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvModel> GetEinvGetNumberList(QueryModel<EinvModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvInvGetList");
            command.SetParameterValue(":INV_YM", queryModel.Entity.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.Entity.TRACK);
            command.SetParameterValue(":SITE_ID", queryModel.Entity.SITE_ID);
            command.SetParameterValue(":USER_ID", queryModel.Entity.USER_ID);

            int total;
            command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
            queryModel.TotalRecords = total;
            return command.ExecuteEntityList<EinvModel>();
        }

        /// <summary>
        /// 依照T_key 找發票資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public EinvModel GetEinvListByKey(int _intTKey)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvInvByKey");
            command.SetParameterValue(":T_KEY", _intTKey);
            
            return command.ExecuteEntity<EinvModel>();
        }




        /// <summary>
        /// 新增發票基本檔
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int intAddInvBaseHq(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("AddInvData");

            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":INV_NO_E", queryModel.INV_NO_E);
            command.SetParameterValue(":INV_TYPE", queryModel.INV_TYPE);
            command.SetParameterValue(":INV_FORMAT", queryModel.INV_FORMAT);
            command.SetParameterValue(":BUSER", queryModel.BUSER);
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);
            command.SetParameterValue(":INV_ROLL", queryModel.INV_ROLL);
            return command.ExecuteNonQuery(); 
        }

        /// <summary>
        /// 更新發票基本檔
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int UpdatInvHqData(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("UpdateInvHqData");

            command.SetParameterValue(":T_KEY", queryModel.T_KEY);
            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":INV_NO_E", queryModel.INV_NO_E);
            command.SetParameterValue(":INV_TYPE", queryModel.INV_TYPE);
            command.SetParameterValue(":INV_ROLL", queryModel.INV_ROLL);
            command.SetParameterValue(":CUSER", queryModel.CUSER);
            return command.ExecuteNonQuery(); 
        }

        /// <summary>
        /// 檢查是否有維護相同號碼
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int CheckInvBaseHq(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("CheckInvBaseHq");
            
            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":INV_NO_E", queryModel.INV_NO_E);
            command.SetParameterValue(":INV_TYPE", queryModel.INV_TYPE);
            DataTable NoticeCountTable = command.ExecuteDataSet().Tables[0];
            return int.Parse(NoticeCountTable.Rows[0][0].ToString());
        }

        public int GetInvBaseCount(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetInvBaseCount");
            
            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":INV_NO_E", queryModel.INV_NO_E);
            command.SetParameterValue(":INV_TYPE", queryModel.INV_TYPE);
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);
            DataTable NoticeCountTable = command.ExecuteDataSet().Tables[0];
            return int.Parse(NoticeCountTable.Rows[0][0].ToString());
        }

        public int DelInvBase(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("DelInvBase");

            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":INV_NO_E", queryModel.INV_NO_E);
            command.SetParameterValue(":INV_TYPE", queryModel.INV_TYPE);
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);
            return command.ExecuteNonQuery();
        }

        public int intAddInvBase(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("AddInvBase");

            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":DEC_YM", queryModel.DEC_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":INV_NO_E", queryModel.INV_NO_E);
            command.SetParameterValue(":INV_TYPE", queryModel.INV_TYPE);
            command.SetParameterValue(":BUSER", queryModel.BUSER);
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);

            return command.ExecuteNonQuery();
        }

    }
}
