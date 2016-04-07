using Application.Framework.Data.Entity;
using RSL.MSP.MVC.Model.Common;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvBaseModel : ModelBase
    {
        /// <summary>
        /// 鍵值
        /// </summary>
        [DataMapping("T_KEY", DbType.Decimal)]
        public decimal T_KEY { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>
        [DataMapping("USER_ID", DbType.Decimal)]
        public string USER_ID { get; set; }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataMapping("BUSER", DbType.String)]
        public string BUSER { get; set; }

        /// <summary>
        /// 新增時間
        /// </summary>
        [DataMapping("BTIME", DbType.Date)]
        public string BTIME { get; set; }

        /// <summary>
        /// 修改人員
        /// </summary>
        [DataMapping("CUSER", DbType.String)]
        public string CUSER { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        [DataMapping("CTIME", DbType.Date)]
        public string CTIME { get; set; }

        /// <summary>
        /// 分店代號
        /// </summary>
        [DataMapping("SITE_ID", DbType.String)]
        public string SITE_ID { get; set; }

        /// <summary>
        /// 分店簡稱
        /// </summary>
        [DataMapping("SITE_NAME", DbType.String)]
        public string SITE_NAME { get; set; }

        /// <summary>
        /// 上層公司代號
        /// </summary>
        [DataMapping("P_SITE_ID", DbType.String)]
        public string P_SITE_ID { get; set; }

        /// <summary>
        /// 發票類別
        /// </summary>
        [DataMapping("CONTENT", DbType.String)]
        public string CONTENT { get; set; }

        /// <summary>
        /// 發票類別
        /// </summary>
        [DataMapping("TAG", DbType.String)]
        public string TAG { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        [DataMapping("CENTER_ID", DbType.String)]
        public string CENTER_ID { get; set; }

        /// <summary>
        /// 限制查詢筆數
        /// </summary>
        [DataMapping("ROW_NUM", DbType.Decimal)]
        public decimal ROW_NUM { get; set; }

        
    }
}
