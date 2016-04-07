using RSL.MSP.MVC.Model.EinvModel;
using Application.Framework.Data.Entity;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvUploadModel : EinvBaseModel
    {
       
        
        /// <summary>
        /// 交易日
        /// </summary>
        [DataMapping("INV_DATE", DbType.String)]
        public string INV_DATE { get; set; }


        /// <summary>
        /// 發票號碼
        /// </summary>
        [DataMapping("INV_NO", DbType.String)]
        public string INV_NO { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [DataMapping("STATUS", DbType.String)]
        public string STATUS { get; set; } 
        
        /// <summary>
        /// 發票類別
        /// </summary>
        [DataMapping("MESSAGE_TYPE", DbType.String)]
        public string MESSAGE_TYPE { get; set; } 
        
        /// <summary>
        /// 發票上傳日期
        /// </summary>
        [DataMapping("MESSAGE_DTS", DbType.String)]
        public string MESSAGE_DTS { get; set; }
        
        /// <summary>
        /// 訊息序號
        /// </summary>
        [DataMapping("SEQNO", DbType.String)]
        public string SEQNO { get; set; }

        /// <summary>
        /// 訊息子序號
        /// </summary>
        [DataMapping("SUBSEQNO", DbType.String)]
        public string SUBSEQNO { get; set; }

        /// <summary>
        /// 通用唯一識別碼
        /// </summary>
        [DataMapping("UUID", DbType.String)]
        public string UUID { get; set; }

        [DataMapping("INVOICE_IDENTIFIER", DbType.String)]
        public string INVOICE_IDENTIFIER { get; set; } 
        
        [DataMapping("EVENTDTS", DbType.String)]
        public string EVENTDTS { get; set; } 

        [DataMapping("MESSAGE1", DbType.String)]
        public string MESSAGE1 { get; set; } 

        [DataMapping("MESSAGE2", DbType.String)]
        public string MESSAGE2 { get; set; } 

        [DataMapping("MESSAGE3", DbType.String)]
        public string MESSAGE3 { get; set; } 

        [DataMapping("MESSAGE4", DbType.String)]
        public string MESSAGE4 { get; set; } 

        [DataMapping("MESSAGE5", DbType.String)]
        public string MESSAGE5 { get; set; } 

        [DataMapping("MESSAGE6", DbType.String)]
        public string MESSAGE6 { get; set; }

         [DataMapping("ERR_MESSAGE", DbType.String)]
        public string ERR_MESSAGE { get; set; } 

        
    }
}
