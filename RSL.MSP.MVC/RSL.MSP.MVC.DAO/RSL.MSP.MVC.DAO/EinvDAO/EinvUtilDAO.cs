using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;

namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvUtilDAO : DataAccessBase
    {

        public List<EinvUtilModel> GetInvType(string _strSql)
        {
            //組SQL 方式 暫時不能使用
            DataCommandProcedure cmd = DataCommandFactory.CreateDataCommand(_strSql, CommandType.Text);
            //DataCommand cmd = DataCommandManager.GetDataCommand("GetEinvInvType");

            return cmd.ExecuteEntityList<EinvUtilModel>();
        }

        public string GetCenterSiteId(string _strSql)
        {
            DataCommandProcedure cmd = DataCommandFactory.CreateDataCommand(_strSql, CommandType.Text);
            //DataCommand cmd = DataCommandManager.GetDataCommand("GetEinvInvType");

            EinvBaseModel Ebase = new EinvBaseModel();
            Ebase = cmd.ExecuteEntity<EinvBaseModel>();

            return Ebase.SITE_ID;
        }
        public DataRow GetCenterData(string _strSql)
        {
            //組SQL 方式 暫時不能使用
            DataCommandProcedure cmd = DataCommandFactory.CreateDataCommand(_strSql, CommandType.Text);
            //DataCommand cmd = DataCommandManager.GetDataCommand("GetEinvInvType");

            return cmd.ExecuteDataRow();
        }

        public DataRow GetSiteRollId(string _strSql)
        {
            //組SQL 方式 暫時不能使用
            DataCommandProcedure cmd = DataCommandFactory.CreateDataCommand(_strSql, CommandType.Text);
            //DataCommand cmd = DataCommandManager.GetDataCommand("GetEinvInvType");

            return cmd.ExecuteDataRow();
        }

    }
}
