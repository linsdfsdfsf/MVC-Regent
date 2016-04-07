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
    public class EinvB2CBLL
    {
        EinvB2CDAO EinvB2CDAO = new EinvB2CDAO();
        /// <summary>
        /// 查詢發票資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvModel> GetB2CEinvListByPage(QueryModel<EinvModel> queryModel)
        {
            return EinvB2CDAO.GetB2CEinvListByPage(queryModel);
        }

        /// <summary>
        /// 依照T_key 找發票資訊
        /// </summary>
        /// <param name="_intTKey"></param>
        /// <returns></returns>
        public EinvModel GetB2CEinvInvByKey(int _intTKey)
        {
            return EinvB2CDAO.GetB2CEinvInvByKey(_intTKey);
        }


        /// <summary>
        /// 更新發票基本檔
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public int UpdatB2CEinvData(EinvModel queryModel)
        {
            return EinvB2CDAO.UpdatB2CEinvData(queryModel);
        }

    }
}
