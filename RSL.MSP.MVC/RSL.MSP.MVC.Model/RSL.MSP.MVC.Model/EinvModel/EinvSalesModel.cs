using RSL.MSP.MVC.Model.EinvModel;
using Application.Framework.Data.Entity;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvSalesModel : EinvBaseModel
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
        /// 狀態旗標(第1位'1':外交官第2位'1':事後登錄第3位'1':員購第4位'1':預售第5位'1':訂金)
        /// </summary>
        [DataMapping("STATUS", DbType.String)]
        public string STATUS { get; set; }

        /// <summary>
        /// 記錄日期
        /// </summary>
        [DataMapping("TDATE", DbType.String)]
        public string TDATE { get; set; }

        /// <summary>
        /// 交易開始時間
        /// </summary>
        [DataMapping("RECORD_BEGIN", DbType.String)]
        public string RECORD_BEGIN { get; set; }

        /// <summary>
        /// 交易結束時間
        /// </summary>
        [DataMapping("RECORD_END", DbType.String)]
        public string RECORD_END { get; set; }

        /// <summary>
        /// 交易型態(01一般交易02退貨交易03一般作廢
        /// </summary>
        [DataMapping("TRANS_TYPE", DbType.String)]
        public string TRANS_TYPE { get; set; }

        /// <summary>
        /// 正項金額
        /// </summary>
        [DataMapping("GROSSPLUS", DbType.Decimal)]
        public decimal GROSSPLUS { get; set; }

        /// <summary>
        /// 負項金額
        /// </summary>
        [DataMapping("GROSSNG", DbType.Decimal)]
        public decimal GROSSNG { get; set; }

        /// <summary>
        /// 發票金額
        /// </summary>
        [DataMapping("NET", DbType.Decimal)]
        public decimal NET { get; set; }

        /// <summary>
        /// 應稅金額
        /// </summary>
        [DataMapping("TAX_AMT", DbType.Decimal)]
        public decimal TAX_AMT { get; set; }

        /// <summary>
        /// 免稅總金額
        /// </summary>
        [DataMapping("NORATE_AMT", DbType.Decimal)]
        public decimal NORATE_AMT { get; set; }

        /// <summary>
        /// 未稅總金額
        /// </summary>
        [DataMapping("FREETAX_AMT", DbType.Decimal)]
        public decimal FREETAX_AMT { get; set; }

        /// <summary>
        /// 稅額
        /// </summary>
        [DataMapping("RATE_AMT", DbType.Decimal)]
        public decimal RATE_AMT { get; set; }

        /// <summary>
        /// 訂金結帳之訂金金額
        /// </summary>
        [DataMapping("PREPAY_AMT", DbType.Decimal)]
        public decimal PREPAY_AMT { get; set; }

        /// <summary>
        /// 溢收金額
        /// </summary>
        [DataMapping("EXTRA_AMT", DbType.Decimal)]
        public decimal EXTRA_AMT { get; set; }

        /// <summary>
        /// 商品禮券溢收金額
        /// </summary>
        [DataMapping("TH_EXTRA_AMT", DbType.Decimal)]
        public decimal TH_EXTRA_AMT { get; set; }

        /// <summary>
        /// 外交官零稅金額
        /// </summary>
        [DataMapping("ZERO_TAX_AMT", DbType.Decimal)]
        public decimal ZERO_TAX_AMT { get; set; }

        /// <summary>
        /// 發票起號
        /// </summary>
        [DataMapping("GUI_BEGIN", DbType.String)]
        public string GUI_BEGIN { get; set; }

        /// <summary>
        /// 發票字軌
        /// </summary>
        [DataMapping("RECE_TRACK", DbType.String)]
        public string RECE_TRACK { get; set; }

        /// <summary>
        /// 總購買數量
        /// </summary>
        [DataMapping("TOT_QTY", DbType.String)]
        public string TOT_QTY { get; set; }

        /// <summary>
        /// 聯名卡號
        /// </summary>
        [DataMapping("VIP_NO", DbType.String)]
        public string VIP_NO { get; set; }

        /// <summary>
        ///被作廢發票的日期
        /// </summary>
        [DataMapping("ORG_GUI_DATE", DbType.String)]
        public string ORG_GUI_DATE { get; set; }

        /// <summary>
        ///被作廢發票的機號
        /// </summary>
        [DataMapping("ORG_POS_ID", DbType.String)]
        public string ORG_POS_ID { get; set; }

        /// <summary>
        ///被作廢發票的交易流水號
        /// </summary>
        [DataMapping("ORG_TRANS_NO", DbType.String)]
        public string ORG_TRANS_NO { get; set; }

        /// <summary>
        ///備註
        /// </summary>
        [DataMapping("MEMO", DbType.String)]
        public string MEMO { get; set; }

        /// <summary>
        ///外交官編號
        /// </summary>
        [DataMapping("NRT_CARDNO", DbType.String)]
        public string NRT_CARDNO { get; set; }

        /// <summary>
        ///電子發票載具種類
        /// </summary>
        [DataMapping("EUI_VEHICLE_TYPE", DbType.String)]
        public string EUI_VEHICLE_TYPE { get; set; }

        /// <summary>
        ///電子發票載具卡號
        /// </summary>
        [DataMapping("EUI_VEHICLE_NO", DbType.String)]
        public string EUI_VEHICLE_NO { get; set; }

        /// <summary>
        ///電子發票防偽隨機碼
        /// </summary>
        [DataMapping("EUI_RANDOM_CODE", DbType.String)]
        public string EUI_RANDOM_CODE { get; set; }

        /// <summary>
        ///紙本發票列印狀態'0':沒有'1':有
        /// </summary>
        [DataMapping("EUI_PRINT", DbType.String)]
        public string EUI_PRINT { get; set; }

        /// <summary>
        ///銷售清單列印狀態'0':沒有'1':有
        /// </summary>
        [DataMapping("EUI_PRINT_TRANS", DbType.String)]
        public string EUI_PRINT_TRANS { get; set; }

        /// <summary>
        ///發票捐贈狀態'0':沒有'1':有
        /// </summary>
        [DataMapping("EUI_DONATE", DbType.String)]
        public string EUI_DONATE { get; set; }

        /// <summary>
        ///愛心碼(左靠右補空白)
        /// </summary>
        [DataMapping("EUI_DONATE_NO", DbType.String)]
        public string EUI_DONATE_NO { get; set; }

        /// <summary>
        ///愛心碼捐贈狀態'0':沒有'1':有
        /// </summary>
        [DataMapping("EUI_DONATE_STATUS", DbType.String)]
        public string EUI_DONATE_STATUS { get; set; }

        /// <summary>
        ///共通載具狀態'0':沒有'1':有
        /// </summary>
        [DataMapping("EUI_UNIVERSAL_STATUS", DbType.String)]
        public string EUI_UNIVERSAL_STATUS { get; set; }

        /// <summary>
        ///電子發票載具類別編號(左靠右補空白)
        /// </summary>
        [DataMapping("EUI_VEHICLE_TYPE_NO", DbType.String)]
        public string EUI_VEHICLE_TYPE_NO { get; set; }


    }
}
