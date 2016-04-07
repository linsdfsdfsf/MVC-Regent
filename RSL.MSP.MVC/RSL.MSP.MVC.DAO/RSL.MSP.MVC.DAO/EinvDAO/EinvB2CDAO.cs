using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;

namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvB2CDAO : DataAccessBase
    {
        /// <summary>
        /// 查詢發票資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvModel> GetB2CEinvListByPage(QueryModel<EinvModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetB2CEinvInvList");
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
        public EinvModel GetB2CEinvInvByKey(int _intTKey)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetB2CEinvInvByKey");
            command.SetParameterValue(":T_KEY", _intTKey);
            
            return command.ExecuteEntity<EinvModel>();
        }



        /// <summary>
        /// 更新發票基本檔
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int UpdatB2CEinvData(EinvModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("UpdateB2CEinvData");

            command.SetParameterValue(":CUSER", queryModel.CUSER);
            command.SetParameterValue(":T_KEY", queryModel.T_KEY);
            command.SetParameterValue(":INV_YM", queryModel.INV_YM);
            command.SetParameterValue(":TRACK", queryModel.TRACK);
            command.SetParameterValue(":INV_NO_B", queryModel.INV_NO_B);
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);
            return command.ExecuteNonQuery(); 
        }

    }
}
