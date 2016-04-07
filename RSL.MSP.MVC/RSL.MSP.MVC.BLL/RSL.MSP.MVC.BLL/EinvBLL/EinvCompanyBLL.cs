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
    public class EinvCompanyBLL
    {
        EinvCompanyDAO ECompanyDAO = new EinvCompanyDAO();
        /// <summary>
        /// 查詢商家資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvCompanyModel> GetEinvCompanyListByPage(QueryModel<EinvCompanyModel> queryModel)
        {
            return ECompanyDAO.GetEinvCompanyListByPage(queryModel);
        }

        /// <summary>
        /// 查詢商家資訊 BY ID
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public EinvCompanyModel GetEinvCompanyListById(string _strSId)
        {
            return ECompanyDAO.GetEinvCompanyListById(_strSId);
        }

        public int iUpdateEinvCompany(EinvCompanyModel queryModel)
        {
            return ECompanyDAO.iUpdateEinvCompany(queryModel);
        }

        public int iInsertEinvCompany(EinvCompanyModel queryModel)
        {
            return ECompanyDAO.iInsertEinvCompany(queryModel);
        }
    }
}
