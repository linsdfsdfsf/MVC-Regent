using RSL.MSP.MVC.Model.EinvModel;
using Application.Framework.Data.Entity;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvModel : EinvBaseModel
    {
        /// <summary>
        /// 發票年月
        /// </summary>
        [DataMapping("INV_YM", DbType.String)]
        public string INV_YM { get; set; }

        /// <summary>
        /// 申報年月
        /// </summary>
        [DataMapping("DEC_YM", DbType.String)]
        public string DEC_YM { get; set; }

        /// <summary>
        /// 字軌
        /// </summary>
        [DataMapping("TRACK", DbType.String)]
        public string TRACK { get; set; }

        /// <summary>
        /// 發票起號
        /// </summary>
        [DataMapping("INV_NO_B", DbType.String)]
        public string INV_NO_B { get; set; }

        /// <summary>
        /// 發票迄號
        /// </summary>
        [DataMapping("INV_NO_E", DbType.String)]
        public string INV_NO_E { get; set; }
       
        /// <summary>
        /// 發票類別
        /// </summary>
        [DataMapping("INV_TYPE", DbType.String)]
        public string INV_TYPE { get; set; }

        /// <summary>
        /// 發票類別
        /// </summary>
        [DataMapping("INV_FORMAT", DbType.String)]
        public string INV_FORMAT { get; set; }

        
         /// <summary>
        /// 發票券數
        /// </summary>
        [DataMapping("INV_ROLL", DbType.Decimal)]
        public decimal INV_ROLL { get; set; }
        
        /// <summary>
        /// 發票券數
        /// </summary>
        [DataMapping("STATUS", DbType.String)]
        public string STATUS { get; set; }
       

    }
}
