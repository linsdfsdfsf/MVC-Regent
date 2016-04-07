using RSL.MSP.MVC.Model.EinvModel;
using Application.Framework.Data.Entity;
using System.Data;

namespace RSL.MSP.MVC.Model.EinvModel
{
    public class EinvRollModel : EinvBaseModel
    {

        /// <summary>
        /// 自動下傳卷數
        /// </summary>
        [DataMapping("AUTO_INV_ROLL", DbType.Decimal)]
        public decimal AUTO_INV_ROLL { get; set; }

        /// <summary>
        /// 手動下傳卷數
        /// </summary>
        [DataMapping("MANUAL_INV_ROLL", DbType.Decimal)]
        public decimal MANUAL_INV_ROLL { get; set; }

		
        /// <summary>
        /// 配號序號
        /// </summary>
        [DataMapping("SUPPLY_NO", DbType.String)]
        public string SUPPLY_NO { get; set; }
        
        /// <summary>
        /// 配號模式
        /// </summary>
        [DataMapping("SUPPLY_MODE", DbType.String)]
        public string SUPPLY_MODE { get; set; }

        /// <summary>
        /// 配號卷數
        /// </summary>
        [DataMapping("INV_ROLL", DbType.Decimal)]
        public decimal INV_ROLL { get; set; }
        
    }
}
