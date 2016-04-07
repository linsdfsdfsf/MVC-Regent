using System.Collections.Generic;
using System.Data;
using Application.Framework.Data.DataAccess;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;

namespace RSL.MSP.MVC.DAO.EinvDAO
{
    public class EinvCompanyDAO : DataAccessBase
    {
        /// <summary>
        /// 查詢商家資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvCompanyModel> GetEinvCompanyListByPage(QueryModel<EinvCompanyModel> queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvCompanyList");
            command.SetParameterValue(":SITE_ID", queryModel.Entity.SITE_ID);
            command.SetParameterValue(":SITE_NAME", queryModel.Entity.SITE_NAME);
            command.SetParameterValue(":CENTER_ID", queryModel.Entity.CENTER_ID);
            command.SetParameterValue(":SITE_TYPE", queryModel.Entity.SITE_TYPE);
            command.SetParameterValue(":P_SITE_ID", queryModel.Entity.P_SITE_ID);
            int total;
            command.SetPageInfo(queryModel.PageIndex, queryModel.PageSize, out total);
            queryModel.TotalRecords = total;
            return command.ExecuteEntityList<EinvCompanyModel>();
        }

        /// <summary>
        /// 查詢商家資料BY SITE ID
        /// </summary>
        /// <param name="_strSId"></param>
        /// <returns></returns>
        public EinvCompanyModel GetEinvCompanyListById(string _strSId)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetEinvCompanyById");
            command.SetParameterValue(":SITE_ID", _strSId.ToString());
            
            return command.ExecuteEntity<EinvCompanyModel>();
        }

        public int iUpdateEinvCompany(EinvCompanyModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("UpdateEinvCompany");
            
            command.SetParameterValue(":SITE_NAME", queryModel.SITE_NAME);   
            command.SetParameterValue(":CENTER_NAME", queryModel.CENTER_NAME); 
            command.SetParameterValue(":CHARGE_STAFF", queryModel.CHARGE_STAFF);
            command.SetParameterValue(":EMAIL", queryModel.EMAIL);       
            command.SetParameterValue(":TAX_ID", queryModel.TAX_ID);      
            command.SetParameterValue(":CENTER_TEL", queryModel.CENTER_TEL);
            command.SetParameterValue(":CONTACT_STAFF", queryModel.CONTACT_STAFF);
            command.SetParameterValue(":CONTACT_TEL", queryModel.CONTACT_TEL);
            command.SetParameterValue(":CENTER_REG_ADDR", queryModel.CENTER_REG_ADDR);  
            command.SetParameterValue(":SITE_TYPE", queryModel.SITE_TYPE);   
            command.SetParameterValue(":P_SITE_ID", queryModel.P_SITE_ID);   
            command.SetParameterValue(":CUSER", queryModel.CUSER);       
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);
            command.SetParameterValue(":CENTER_ID", queryModel.CENTER_ID);   
            return command.ExecuteNonQuery();
        }

        public int iInsertEinvCompany(EinvCompanyModel queryModel)
        {
            DataCommand command = DataCommandManager.GetDataCommand("InsertEinvCompany");

            command.SetParameterValue(":SITE_NAME", queryModel.SITE_NAME);
            command.SetParameterValue(":CENTER_NAME", queryModel.CENTER_NAME);
            command.SetParameterValue(":CHARGE_STAFF", queryModel.CHARGE_STAFF);
            command.SetParameterValue(":EMAIL", queryModel.EMAIL);
            command.SetParameterValue(":TAX_ID", queryModel.TAX_ID);
            command.SetParameterValue(":CENTER_TEL", queryModel.CENTER_TEL);
            command.SetParameterValue(":SITE_TYPE", queryModel.SITE_TYPE);
            command.SetParameterValue(":CONTACT_STAFF", queryModel.CONTACT_STAFF);
            command.SetParameterValue(":CONTACT_TEL", queryModel.CONTACT_TEL);
            command.SetParameterValue(":CENTER_REG_ADDR", queryModel.CENTER_REG_ADDR);  
            command.SetParameterValue(":P_SITE_ID", queryModel.P_SITE_ID);
            command.SetParameterValue(":BUSER", queryModel.BUSER);
            command.SetParameterValue(":SITE_ID", queryModel.SITE_ID);
            command.SetParameterValue(":CENTER_ID", queryModel.CENTER_ID);

            return command.ExecuteNonQuery();
        }
    }
}
