using Application.Framework.Data.Entity;
using RSL.MSP.MVC.Model.EinvModel;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvCompanyModel : EinvBaseModel
    {

        /// <summary>
        /// 公司名稱
        /// </summary>
        [DataMapping("CENTER_NAME",DbType.String)]
        public string CENTER_NAME { get; set; }

        /// <summary>
        /// 公司英文名稱
        /// </summary>
        [DataMapping("CENTER_NAME_E",DbType.String)]
        public string CENTER_NAME_E { get; set; }

        /// <summary>
        /// 稅籍編號
        /// </summary>
        [DataMapping("TAX_ID",DbType.String)]
        public string TAX_ID { get; set; }

        /// <summary>
        /// 負責人
        /// </summary>
        [DataMapping("CHARGE_STAFF",DbType.String)]
        public string CHARGE_STAFF { get; set; }

        /// <summary>
        /// 聯絡人
        /// </summary>
        [DataMapping("CONTACT_STAFF",DbType.String)]
        public string CONTACT_STAFF { get; set; }

        /// <summary>
        /// 聯絡人電話
        /// </summary>
        [DataMapping("CONTACT_TEL",DbType.String)]
        public string CONTACT_TEL { get; set; }

        /// <summary>
        /// 聯絡人傳真
        /// </summary>
        [DataMapping("CONTACT_FAX",DbType.String)]
        public string CONTACT_FAX { get; set; }

        /// <summary>
        /// 公司(營業處)地址(中文)
        /// </summary>
        [DataMapping("CENTER_ADDR",DbType.String)]
        public string CENTER_ADDR { get; set; }

        /// <summary>
        /// 公司(營業處)地址(英文)
        /// </summary>
        [DataMapping("CENTER_ADDR_E",DbType.String)]
        public string CENTER_ADDR_E { get; set; }

        /// <summary>
        /// 公司登記地址(中文)
        /// </summary>
        [DataMapping("CENTER_REG_ADDR",DbType.String)]
        public string CENTER_REG_ADDR { get; set; }

        /// <summary>
        /// 公司登記地址(英文)
        /// </summary>
        [DataMapping("CENTER_REG_ADDR_E",DbType.String)]
        public string CENTER_REG_ADDR_E { get; set; }

        /// <summary>
        /// 營業登記證號
        /// </summary>
        [DataMapping("REG_ID",DbType.String)]
        public string REG_ID { get; set; }

        /// <summary>
        /// 公司電話
        /// </summary>
        [DataMapping("CENTER_TEL",DbType.String)]
        public string CENTER_TEL { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        [DataMapping("POST_ID",DbType.String)]
        public string POST_ID { get; set; }

        /// <summary>
        /// 郵寄電話
        /// </summary>
        [DataMapping("POST_TEL",DbType.String)]
        public string POST_TEL { get; set; }

        /// <summary>
        /// 郵寄傳真
        /// </summary>
        [DataMapping("POST_FAX",DbType.String)]
        public string POST_FAX { get; set; }

        /// <summary>
        /// 郵寄地址
        /// </summary>
        [DataMapping("POST_ADDR",DbType.String)]
        public string POST_ADDR { get; set; }

        /// <summary>
        /// 電子郵件信箱
        /// </summary>
        [DataMapping("EMAIL",DbType.String)]
        public string EMAIL { get; set; }

        /// <summary>
        /// 公司網址
        /// </summary>
        [DataMapping("CENTER_URL",DbType.String)]
        public string CENTER_URL { get; set; }

        /// <summary>
        /// 發票地址
        /// </summary>
        [DataMapping("TAX_ADDR",DbType.String)]
        public string TAX_ADDR { get; set; }

        /// <summary>
        /// 公司營業型態
        /// </summary>
        [DataMapping("CORPORATION",DbType.String)]
        public string CORPORATION { get; set; }

        /// <summary>
        /// 公司營業型態(英文)
        /// </summary>
        [DataMapping("CORPORATION_E",DbType.String)]
        public string CORPORATION_E { get; set; }

        /// <summary>
        /// 分店代號
        /// </summary>
        [DataMapping("SHOP_ID",DbType.String)]
        public string SHOP_ID { get; set; }

        [DataMapping("SITE_IP",DbType.String)]
        public string SITE_IP { get; set; }

        [DataMapping("VM_DIR",DbType.String)]
        public string VM_DIR { get; set; }

        [DataMapping("MERCHANT_ID",DbType.String)]
        public string MERCHANT_ID { get; set; }

        [DataMapping("TERMINAL_ID",DbType.String)]
        public string TERMINAL_ID { get; set; }

        /// <summary>
        /// 上層(總)公司統編
        /// </summary>
        [DataMapping("P_CENTER_ID",DbType.String)]
        public string P_CENTER_ID { get; set; }

        /// <summary>
        /// 是否為總公司 1:總2:分
        /// </summary>
        [DataMapping("SITE_TYPE",DbType.String)]
        public string SITE_TYPE { get; set; }


    }
}
