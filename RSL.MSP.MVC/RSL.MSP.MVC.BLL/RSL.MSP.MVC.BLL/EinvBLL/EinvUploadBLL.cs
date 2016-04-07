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
    public class EinvUploadBLL
    {
        EinvUploadDAO MyEinvExangeDAO = new EinvUploadDAO();
        /// <summary>
        /// 查詢交易資訊List
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public List<EinvUploadModel> GetEinvUploadListByPage(QueryModel<EinvUploadModel> queryModel)
        {
            return MyEinvExangeDAO.GetEinvUploadListByPage(queryModel);
        }

        /// <summary>
        /// 依照條件找錯誤資訊
        /// <returns></returns>
        public EinvUploadModel GetEinvUploadDataBykey(string _strMsgType, string _strSeqNo, string _strSubSeqNo, string _strUuid)
        {
            return MyEinvExangeDAO.GetEinvUpdateDataBykey(_strMsgType, _strSeqNo, _strSubSeqNo, _strUuid);
        }



    }
}
