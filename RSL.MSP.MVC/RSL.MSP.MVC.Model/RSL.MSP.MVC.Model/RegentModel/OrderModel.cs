using Application.Framework.Data.Entity;
using System.Data;
using RSL.MSP.MVC.Model.Base;
using RSL.MSP.MVC.Model.Common;

namespace RSL.MSP.MVC.Model.RegentModel
{
    public class OrderModel : ModelBase
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [DataMapping("ORDERM_ID", DbType.String)]
        public string ORDERM_ID { get; set; }

        /// <summary>
        /// 訂位方式(A:網頁 B:電話)
        /// </summary>
        [DataMapping("BOOKING_TYPE", DbType.String)]
        public string BOOKING_TYPE { get; set; }

        /// <summary>
        /// 餐廰編號
        /// </summary>
        [DataMapping("RESTAURANT_ID", DbType.String)]
        public string RESTAURANT_ID { get; set; }

        /// <summary>
        /// 餐廳名稱
        /// </summary>
        [DataMapping("RESTAURANT_NAME", DbType.String)]
        public string RESTAURANT_NAME { get; set; }

        /// <summary>
        /// 每日時段編號
        /// </summary>
        [DataMapping("DAILY_PERIOD_ID", DbType.String)]
        public string DAILY_PERIOD_ID { get; set; }

        /// <summary>
        /// 用餐日期(YYYY/MM/dd)
        /// </summary>
        [DataMapping("BOOKING_DATE", DbType.String)]
        public string BOOKING_DATE { get; set; }


        /// <summary>
        /// 用餐日期(YYYY/MM/dd)
        /// </summary>
        [DataMapping("BOOKING_DATE_B", DbType.String)]
        public string BOOKING_DATE_B { get; set; }


        /// <summary>
        /// 用餐日期(YYYY/MM/dd)
        /// </summary>
        [DataMapping("BOOKING_DATE_E", DbType.String)]
        public string BOOKING_DATE_E { get; set; }


        /// <summary>
        /// 時段群組名稱
        /// </summary>
        [DataMapping("PERIOD_GROUP_NAME", DbType.String)]
        public string PERIOD_GROUP_NAME { get; set; }

        /// <summary>
        /// 時段名稱
        /// </summary>
        [DataMapping("PERIOD_NAME", DbType.String)]
        public string PERIOD_NAME { get; set; }

        /// <summary>
        /// 用餐人數
        /// </summary>
        [DataMapping("RESERVATION_NUMBER", DbType.String)]
        public string RESERVATION_NUMBER { get; set; }

        /// <summary>
        /// 訂位狀態
        /// </summary>
        [DataMapping("BOOKING_STATUS", DbType.String)]
        public string BOOKING_STATUS { get; set; }

        /// <summary>
        /// 手機號碼(傳送驗證碼)
        /// </summary>
        [DataMapping("VERIFICATION_MOBILE", DbType.String)]
        public string VERIFICATION_MOBILE { get; set; }

        /// <summary>
        /// 手機驗證碼
        /// </summary>
        [DataMapping("VERIFICATION_CODE", DbType.String)]
        public string VERIFICATION_CODE { get; set; }

        /// <summary>
        /// 驗證碼發送時間
        /// </summary>
        [DataMapping("VCODE_SEND_TIME", DbType.String)]
        public string VCODE_SEND_TIME { get; set; }

        /// <summary>
        /// (必填)顧客姓名
        /// </summary>
        [DataMapping("CUS_NAME", DbType.String)]
        public string CUS_NAME { get; set; }

        /// <summary>
        /// (必填)顧客性別
        /// </summary>
        [DataMapping("CUS_GENDER", DbType.String)]
        public string CUS_GENDER { get; set; }

        /// <summary>
        /// (必填)顧客Email
        /// </summary>
        [DataMapping("CUS_EMAIL", DbType.String)]
        public string CUS_EMAIL { get; set; }

        /// <summary>
        /// (必填)顧客連絡電話
        /// </summary>
        [DataMapping("CUS_TEL", DbType.String)]
        public string CUS_TEL { get; set; }

        /// <summary>
        /// 用餐目的
        /// </summary>
        [DataMapping("PURPOSE", DbType.String)]
        public string PURPOSE { get; set; }

        /// <summary>
        /// 特殊需求
        /// </summary>
        [DataMapping("CUS_NOTE", DbType.String)]
        public string CUS_NOTE { get; set; }

        /// <summary>
        /// 完成訂位的時間
        /// </summary>
        [DataMapping("BOOKING_OK_DATE", DbType.String)]
        public string BOOKING_OK_DATE { get; set; }

        /// <summary>
        /// 取消訂位的時間
        /// </summary>
        [DataMapping("BOOKING_CANCEL_DATE", DbType.String)]
        public string BOOKING_CANCEL_DATE { get; set; }

        /// <summary>
        /// 取消訂位的原因
        /// </summary>
        [DataMapping("BOOKING_CANCEL_NOTE", DbType.String)]
        public string BOOKING_CANCEL_NOTE { get; set; }

        /// <summary>
        /// 最後修改訂單的時間
        /// </summary>
        [DataMapping("BOOKING_EDIT_DATE", DbType.String)]
        public string BOOKING_EDIT_DATE { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        [DataMapping("ORDER_STATUS", DbType.String)]
        public string ORDER_STATUS { get; set; }

        /// <summary>
        /// 入場時間
        /// </summary>
        [DataMapping("ORDER_OK_DATE", DbType.String)]
        public string ORDER_OK_DATE { get; set; }

        /// <summary>
        /// 建立者代碼
        /// </summary>
        [DataMapping("BUSER", DbType.String)]
        public string BUSER { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [DataMapping("BTIME", DbType.String)]
        public string BTIME { get; set; }

        /// <summary>
        /// 變更者代碼
        /// </summary>
        [DataMapping("CUSER", DbType.String)]
        public string CUSER { get; set; }

        /// <summary>
        /// 變更者時間
        /// </summary>
        [DataMapping("CTIME", DbType.String)]
        public string CTIME { get; set; }


    }
}
