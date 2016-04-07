using RSL.MSP.MVC.Model.EinvModel;
using Application.Framework.Data.Entity;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvExchangeModel : EinvBaseModel
    {
        /// <summary>
        /// 收銀機代號
        /// </summary>
        [DataMapping("POS_ID", DbType.String)]
        public string POS_ID { get; set; }

        /// <summary>
        /// 交易流水號
        /// </summary>
        [DataMapping("TRANS_NO", DbType.String)]
        public string TRANS_NO { get; set; }

        /// <summary>
        /// 交易日
        /// </summary>
        [DataMapping("SALES_DATE", DbType.String)]
        public string SALES_DATE { get; set; }


        /// <summary>
        /// 發票號碼
        /// </summary>
        [DataMapping("INVOICENUMBER", DbType.String)]
        public string INVOICENUMBER { get; set; }

        /// <summary>
        /// 發票開立日
        /// </summary>
        [DataMapping("INVOICEDATE", DbType.String)]
        public string INVOICEDATE { get; set; }

        /// <summary>
        /// 發票作廢日
        /// </summary>
        [DataMapping("CANCELDATE", DbType.String)]
        public string CANCELDATE { get; set; }

        /// <summary>
        /// 發票註銷日
        /// </summary>
        [DataMapping("VOIDDATE", DbType.String)]
        public string VOIDDATE { get; set; }
          
        /// <summary>
        /// 發票跨期退貨日
        /// </summary>
        [DataMapping("ALLOWANCEDATE", DbType.String)]
        public string ALLOWANCEDATE { get; set; } 

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

    }
}
