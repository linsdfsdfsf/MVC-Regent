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
    public class EinvBLL
    {
        EinvDAO MyEinvDAO = new EinvDAO();
        /// <summary>
        /// 查詢發票資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvModel> GetEinvListByPage(QueryModel<EinvModel> queryModel)
        { 
            return MyEinvDAO.GetEinvListByPage(queryModel);
        }
        /// <summary>
        /// 查詢可配號資訊
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvModel> GetEinvGetNumberList(QueryModel<EinvModel> queryModel)
        {

            return MyEinvDAO.GetEinvGetNumberList(queryModel);
        }

        /// <summary>
        /// 依照T_key 找發票資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public EinvModel GetEinvListByTkey(int _intTKey)
        {
            return MyEinvDAO.GetEinvListByKey(_intTKey);
        }



        /// <summary>
        /// 新增發票基本檔
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int intAddInvBaseHq(EinvModel queryModel)
        {
            return MyEinvDAO.intAddInvBaseHq(queryModel);
        }

        /// <summary>
        /// 更新發票基本檔
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int UpdatInvHqData(EinvModel queryModel)
        {
            return MyEinvDAO.UpdatInvHqData(queryModel);
        }

        public int CheckInvBaseHq(EinvModel queryModel)
        {
            return MyEinvDAO.CheckInvBaseHq(queryModel);
        }

        public int GetInvBaseCount(EinvModel queryModel)
        {
            return MyEinvDAO.GetInvBaseCount(queryModel);
        }

        public int DelInvFormat32(EinvModel queryModel)
        {
            return MyEinvDAO.DelInvBase(queryModel);
        }

        public int intAddInvBase(EinvModel queryModel)
        {
            return MyEinvDAO.intAddInvBase(queryModel);
        }
    }
}
