using RSL.MSP.MVC.Model.EinvModel;
using Application.Framework.Data.Entity;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvSalesDetailModel : EinvBaseModel
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
        /// 專櫃編號
        /// </summary>
        [DataMapping("STORE_ID", DbType.String)]
        public string STORE_ID { get; set; }

        /// <summary>
        /// 交易日
        /// </summary>
        [DataMapping("SALES_DATE", DbType.String)]
        public string SALES_DATE { get; set; }

        /// <summary>
        /// 統編
        /// </summary>
        [DataMapping("COMP_ID", DbType.String)]
        public string COMP_ID { get; set; }

        /// <summary>
        /// 狀態旗標
        /// </summary>
        [DataMapping("STATUS", DbType.String)]
        public string STATUS { get; set; }
        		

        /// <summary>
        /// 商品原售價
        /// </summary>
        [DataMapping("LIST_PRICE", DbType.Decimal)]
        public decimal LIST_PRICE { get; set; }

        /// <summary>
        /// 商品售價
        /// </summary>
        [DataMapping("SELL_PRICE", DbType.Decimal)]
        public decimal SELL_PRICE { get; set; }

		/// <summary>
        /// 數量
        /// </summary>
        [DataMapping("QTY", DbType.Decimal)]
        public decimal QTY { get; set; }

        /// <summary>
        /// 單項總售價
        /// </summary>
        [DataMapping("SELL_AMT", DbType.Decimal)]
        public decimal SELL_AMT { get; set; }

		/// <summary>
        /// 單項折讓金額
        /// </summary>
        [DataMapping("DISC_AMT", DbType.Decimal)]
        public decimal DISC_AMT { get; set; }
		
        /// <summary>
        /// 單項折扣率(折率 * 100)
        /// </summary>
        [DataMapping("DISC_RATE", DbType.Decimal)]
        public decimal DISC_RATE { get; set; }

        /// <summary>
        /// 單項折扣/讓後售價
        /// </summary>
        [DataMapping("SALES_AMT", DbType.Decimal)]
        public decimal SALES_AMT { get; set; }
		
        /// <summary>
        /// 課稅別
        /// </summary>
        [DataMapping("TAX_FLAG", DbType.String)]
        public string TAX_FLAG { get; set; }
		
        /// <summary>
        /// 小計後總折金額
        /// </summary>
        [DataMapping("AFTER_TOT_DISC", DbType.Decimal)]
        public decimal AFTER_TOT_DISC { get; set; }
	
		/// <summary>
        /// 折扣別
        /// </summary>
        [DataMapping("ND", DbType.String)]
        public string ND { get; set; }

	    /// <summary>
        /// 發票號碼
        /// </summary>
        [DataMapping("GUI_NO", DbType.String)]
        public string GUI_NO { get; set; }

	    /// <summary>
        /// 抽成類別
        /// </summary>
        [DataMapping("ND_TYPE", DbType.String)]
        public string ND_TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMapping("SN", DbType.String)]
        public string SN { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        [DataMapping("ITEM_NAME", DbType.String)]
        public string ITEM_NAME { get; set; }


    }
}
