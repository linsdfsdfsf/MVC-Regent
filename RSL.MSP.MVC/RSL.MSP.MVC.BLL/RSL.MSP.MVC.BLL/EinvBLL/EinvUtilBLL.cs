using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.DAO.Common;
using RSL.MSP.MVC.DAO.Common.Data;
using RSL.MSP.MVC.DAO.EinvDAO;
using System.Data.Common;

namespace RSL.MSP.MVC.BLL.EinvBLL
{
    public class EinvUtilBLL
    {
        /// <summary>
        /// 取INV_YM並填回物件
        /// </summary>
        /// <param name="iMonth">DateTime</param>
        /// <param name="dl">DropDownList</param>
        public void getInvYm(string iMonth, DropDownList dl)
        {
            string[,] strArrInvYm = new string[6, 2];
            for (int i = 2; i <= 12; i += 2)
            {
                //增加物件行數
                dl.Items.Add(new ListItem(String.Format("{0}月~{1}月", i - 1, i),
                    String.Format("{0}{1}", (i - 1).ToString().PadLeft(2, '0'), (i).ToString().PadLeft(2, '0'))));
                //設定預設值
                if (iMonth == i.ToString() || iMonth == (i - 1).ToString())
                {
                    dl.SelectedValue =
                        String.Format("{0}{1}", (i - 1).ToString().PadLeft(2, '0'), (i).ToString().PadLeft(2, '0'));
                }
            }
        }

        /// <summary>
        /// 取INV_YM並回傳LIST
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns>List</returns>
        public List<SelectListItem> ListGetInvYm(string iMonth)
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();
            for (int i = 2; i <= 12; i += 2)
            {
                ddlList.Add(new SelectListItem()
                {
                    Text = String.Format("{0}月~{1}月", i - 1, i),
                    Value = String.Format("{0}{1}", (i - 1).ToString().PadLeft(2, '0'), (i).ToString().PadLeft(2, '0')),
                    Selected = (iMonth == i.ToString() || iMonth == (i - 1).ToString() ||
                        String.Format("{0}{1}", (i - 1).ToString().PadLeft(2, '0'), (i).ToString().PadLeft(2, '0')) == iMonth)

                });
            }
            return ddlList;
        }

        /// <summary>
        /// 取得當下發票年月
        /// </summary>
        /// <param name="strMonth"></param>
        /// <returns></returns>
        public string strGetInvYm(string strMonth)
        {
            int iMonth = 0;
            string strReInvYm = "";
            if (int.TryParse(strMonth, out iMonth))
            {
                if (iMonth % 2 == 0)
                {
                    strReInvYm = String.Format("{0}{1}", (iMonth - 1).ToString().PadLeft(2, '0'), (iMonth).ToString().PadLeft(2, '0'));
                }
                else
                {
                    strReInvYm = String.Format("{0}{1}", (iMonth).ToString().PadLeft(2, '0'), (iMonth + 1).ToString().PadLeft(2, '0'));
                }
                
            }
            else
            {
                strReInvYm = "";
            }


            return strReInvYm;
        }


        /// <summary>
        /// 取得發票類別
        /// </summary>
        /// <returns>List</returns>
        public List<EinvUtilModel> GetInvType()
        {
            //string CommandText = @"SELECT TAG,CONTENT FROM IMS3_BASE.PARAM WHERE TITLE='INV_TYPE'"; 
            string CommandText = @"SELECT TAG,CONTENT FROM IMS3_BASE.PARAM WHERE TITLE='INV_TYPE'";

            EinvUtilDAO EinvUtilDao = new EinvUtilDAO();
            return EinvUtilDao.GetInvType(CommandText);
  
        }


        public List<SelectListItem> GetInvType(string strInvType)
        {
            //string CommandText = @"SELECT TAG,CONTENT FROM IMS3_BASE.PARAM WHERE TITLE='INV_TYPE'"; 
            string CommandText = @"SELECT TAG,CONTENT FROM IMS3_BASE.PARAM WHERE TITLE='INV_TYPE'";

            EinvUtilDAO EinvUtilDao = new EinvUtilDAO();
     
            List<EinvUtilModel> EinvType = new List<EinvUtilModel>();

            EinvType = EinvUtilDao.GetInvType(CommandText);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            foreach (var LInvType in EinvType)
            {
                ddlList.Add(new SelectListItem()
                {
                    Text = LInvType.CONTENT,
                    Value = LInvType.TAG,
                    Selected = (LInvType.TAG == strInvType)  

                });
            }
            return ddlList;

        }

        /// <summary>
        /// 取得分店代號
        /// </summary>
        /// <returns></returns>
        public string GetCenterSiteId(string _strCenterId)
        {
            //string CommandText = @"SELECT TAG,CONTENT FROM IMS3_BASE.PARAM WHERE TITLE='INV_TYPE'";
            string CommandText = @"SELECT SITE_ID FROM IMS3_BASE.CENTER WHERE SITE_TYPE='1' AND CENTER_ID= '"+ _strCenterId+"'";

            EinvUtilDAO EinvUtilDao = new EinvUtilDAO();
            return EinvUtilDao.GetCenterSiteId(CommandText);

        }

        /// <summary>
        /// 檢查有無維護水位及有無此店家資料
        /// </summary>
        /// <returns></returns>
        public bool bCheckSiteRollData(string _strSid)
        {
            bool bCheck = false;
            string CommandText = string.Format(
                                @"SELECT COUNT(C.SITE_ID) AS C_CENTER,
                                        COUNT(S.SITE_ID) AS C_SITEROLL
                                        FROM {0}CENTER C 
                                        LEFT JOIN {1}SITE_INV_ROLL S 
                                        ON C.SITE_ID = S.SITE_ID 
                                        WHERE C.SITE_ID='{2}'",
                                "IMS3_BASE.",
                                "IMS_FA.",
                                _strSid);

            EinvUtilDAO EinvUtilDao = new EinvUtilDAO();

            DataRow dtCheckRoll = EinvUtilDao.GetCenterData(CommandText);
            if (dtCheckRoll != null)
            {
                int iCenter = int.Parse(dtCheckRoll["C_CENTER"].ToString());
                int iSiteRoll = int.Parse(dtCheckRoll["C_SITEROLL"].ToString());
                //center 有 site roll 有 不可新增
                if (iSiteRoll > 0 && iCenter > 0) { bCheck = false; }
                //center 有 site roll 沒有 可新增
                else if (iSiteRoll == 0 && iCenter > 0) { bCheck = true; }
                //center 沒有不可新增
                else if (iCenter == 0) { bCheck = false; }

            }
            return bCheck;

        }

        /// <summary>
        /// 取得發票配號卷數單號
        /// </summary>
        /// <returns>string SiteRollId</returns>
        public String GetSiteRollId()
        {
            string strSiteRollId ="";
            //string CommandText = @"SELECT TAG,CONTENT FROM IMS3_BASE.PARAM WHERE TITLE='INV_TYPE'";
            string CommandText = string.Format(
                                @"SELECT MAX(SUPPLY_NO) + 1 AS SUPPLY_NO
                                FROM {0}EINV_SUPPLY_ROLL 
                                WHERE TRUNC(BTIME) = '{1}' ",
                                "IMS_FA.",
                                DateTime.Now.ToString("yyyy/MM/dd"));
            EinvUtilDAO EinvUtilDao = new EinvUtilDAO();
            DataRow dtSiteRollId = EinvUtilDao.GetSiteRollId(CommandText);
            if (dtSiteRollId != null)
            {
                //檢查是否為空值
                if (string.IsNullOrEmpty(dtSiteRollId["SUPPLY_NO"].ToString()))
                {
                    strSiteRollId = DateTime.Now.ToString("yyyyMMdd") + "01";
                }
                else {
                    strSiteRollId = dtSiteRollId["SUPPLY_NO"].ToString();
                }
            }
            
            return strSiteRollId;
        }

        
    }
}