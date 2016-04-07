using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;


namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvRollDAO
    {
        /// <summary>
        /// 查詢卷數資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvRollModel> GetEinvRollListByPage(QueryModel<EinvRollModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvRollList");
            command.SetParameterValue(":SITE_ID", queryModel.Entity.SITE_ID);
            command.SetParameterValue(":USER_ID", queryModel.Entity.USER_ID);
            int total;
            command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
            queryModel.TotalRecords = total;
            return command.ExecuteEntityList<EinvRollModel>();
        }

        /// <summary>
        /// 查詢配號卷數資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvRollModel> GetEinvSiteRollList(QueryModel<EinvRollModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvSiteRoll");
            command.SetParameterValue(":P_SITE_ID", queryModel.Entity.P_SITE_ID);
            command.SetParameterValue(":USER_ID", queryModel.Entity.USER_ID);
            int total;
            command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
            queryModel.TotalRecords = total;
            return command.ExecuteEntityList<EinvRollModel>();
        }


        /// <summary>
        /// 查詢卷數資訊
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public EinvRollModel GetEinvRollByKey(int _intTKey)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvRollByTkey");
            command.SetParameterValue(":T_KEY", _intTKey);

            return command.ExecuteEntity<EinvRollModel>();
           
        }

        /// <summary>
        /// 修改發票卷數
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public void UpdateEinvRoll(EinvRollModel _mEinvRoll)
        {
            DataCommand command = DataCommandManager.GetDataCommand("UpdateEinvRoll");
            command.SetParameterValue(":CUSER", _mEinvRoll.CUSER);
            command.SetParameterValue(":AUTO_INV_ROLL", _mEinvRoll.AUTO_INV_ROLL);
            command.SetParameterValue(":T_KEY", _mEinvRoll.T_KEY);
            command.SetParameterValue(":SITE_ID", _mEinvRoll.SITE_ID);

            command.ExecuteNonQuery();

        }

        /// <summary>
        /// 新增發票卷數
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int iInsertEinvRoll(EinvRollModel _mEinvRoll)
        {
            DataCommand command = DataCommandManager.GetDataCommand("InsertEinvRoll");
            command.SetParameterValue(":BUSER", _mEinvRoll.BUSER);
            command.SetParameterValue(":AUTO_INV_ROLL", _mEinvRoll.AUTO_INV_ROLL);
            command.SetParameterValue(":MANUAL_INV_ROLL", _mEinvRoll.MANUAL_INV_ROLL);
            command.SetParameterValue(":SITE_ID", _mEinvRoll.SITE_ID);

            return command.ExecuteNonQuery();

        }

        /// <summary>
        /// 新增分店配號卷數
        /// </summary>
        /// <param name="_mEinvRoll"></param>
        public void vInsertSiteSupplyRoll(EinvRollModel _mEinvRoll)
        {

            DataCommand command = DataCommandManager.GetDataCommand("AddInvSupplyRoll");

            command.SetParameterValue(":SUPPLY_NO", _mEinvRoll.SUPPLY_NO);
            command.SetParameterValue(":SITE_ID", _mEinvRoll.SITE_ID);
            command.SetParameterValue(":INV_ROLL", _mEinvRoll.INV_ROLL);
            command.SetParameterValue(":SUPPLY_MODE", _mEinvRoll.SUPPLY_MODE);
            command.SetParameterValue(":BUSER", _mEinvRoll.BUSER);
            command.SetParameterValue(":P_SITE_ID", _mEinvRoll.P_SITE_ID);

            command.ExecuteNonQuery();
        }


        /// <summary>
        /// 發票配號處理
        /// </summary>
        /// <param name="_Inv_Ym"></param>
        /// <param name="_supply_no"></param>
        /// <param name="_Track"></param>
        /// <param name="_inv_no_b"></param>
        /// <param name="_inv_no_e"></param>
        /// <param name="_buser"></param>
        /// <returns>int</returns>
        public int iGetEinvHqToBase(string _Inv_Ym, string _supply_no, string _Track, string _inv_no_b, string _inv_no_e, string _buser )
        {
            int iresult = 0;

            string p_sql = "IMS_FA.SP_SITE_EINV_SUPPLY";
            using (DataCommandProcedure cmd = DataCommandFactory.CreateDataCommand(p_sql, CommandType.StoredProcedure))
            {
                cmd.AddParameter("i_inv_ym", _Inv_Ym);
                cmd.AddParameter("i_supply_no", _supply_no);
                cmd.AddParameter("i_track", _Track);
                cmd.AddParameter("i_inv_no_b", _inv_no_b);
                cmd.AddParameter("i_inv_no_e", _inv_no_e);
                cmd.AddParameter("i_buser", _buser);

                iresult = cmd.ExecuteNonQuery();
            }
  
            return iresult;

        }
    }
}
