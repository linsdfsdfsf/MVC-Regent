using RSL.MSP.MVC.DAO.Common.Entity;
using RSL.MSP.MVC.Model.EinvModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace RSL.MSP.MVC.Web.UI.Areas.Einv.Models
{
    public class EinvEditModel : EinvModel
    {
        /// <summary>
        /// 統一編號
        /// </summary>
        [DataMapping("OLD_CENTER_ID", DbType.String)]
        public string OLD_CENTER_ID { get; set; }


        /// <summary>
        /// 發票年月
        /// </summary>
        [DataMapping("OLD_INV_YM", DbType.String)]
        public string OLD_INV_YM { get; set; }


        /// <summary>
        /// 字軌
        /// </summary>
        [DataMapping("OLD_TRACK", DbType.String)]
        public string OLD_TRACK { get; set; }

        /// <summary>
        /// 發票起號
        /// </summary>
        [DataMapping("OLD_INV_NO_B", DbType.String)]
        public string OLD_INV_NO_B { get; set; }

        /// <summary>
        /// 發票迄號
        /// </summary>
        [DataMapping("OLD_INV_NO_E", DbType.String)]
        public string OLD_INV_NO_E { get; set; }

        /// <summary>
        /// 發票類別
        /// </summary>
        [DataMapping("OLD_INV_TYPE", DbType.String)]
        public string OLD_INV_TYPE { get; set; }

        
    }
}