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
    public class EinvRollBLL
    {
        EinvRollDAO MyEinvRollDAO = new EinvRollDAO();
        /// <summary>
        /// 查詢卷數資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvRollModel> GetEinvRollListByPage(QueryModel<EinvRollModel> queryModel)
        {
            return MyEinvRollDAO.GetEinvRollListByPage(queryModel);
        }

        /// <summary>
        /// 查詢配號卷數資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvRollModel> GetEinvSiteRollList(QueryModel<EinvRollModel> queryModel)
        {
            return MyEinvRollDAO.GetEinvSiteRollList(queryModel);
        }

        /// <summary>
        /// 查詢單筆卷數資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public EinvRollModel GetEinvRollByKey(int _intTkey)
        {
            return MyEinvRollDAO.GetEinvRollByKey(_intTkey);
        }

        public void UpdateEinvRoll(EinvRollModel _mEinvRoll)
        {
            MyEinvRollDAO.UpdateEinvRoll(_mEinvRoll);
        }

        public int iInsertEinvRoll(EinvRollModel _mEinvRoll)
        {
            return MyEinvRollDAO.iInsertEinvRoll(_mEinvRoll);
        }
        
        public void vInsertSiteSupplyRoll(EinvRollModel _mEinvRoll)
        {
            MyEinvRollDAO.vInsertSiteSupplyRoll(_mEinvRoll);
        }

        public int iGetEinvHqToBase(string _Inv_Ym, string _supply_no, string _Track, string _inv_no_b, string _inv_no_e, string _buser)
        {
            return MyEinvRollDAO.iGetEinvHqToBase(_Inv_Ym, _supply_no, _Track, _inv_no_b, _inv_no_e, _buser);
        }


    }
}
