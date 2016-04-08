using Application.Framework.Data.Entity;
using System.Data;
using RSL.MSP.MVC.Model.Base;
using RSL.MSP.MVC.Model.Common;

namespace RSL.MSP.MVC.Model.RegentModel
{
    public class RestaurantModel : ModelBase
    {
        /// <summary>
        /// 餐廳編號
        /// </summary>
        [DataMapping("RESTAURANT_ID", DbType.String)]
        public string RESTAURANT_ID { get; set; }
        /// <summary>
        /// 餐廳名稱
        /// </summary>
        [DataMapping("RESTAURANT_NAME", DbType.String)]
        public string RESTAURANT_NAME { get; set; }
        /// <summary>
        /// 餐廳電話
        /// </summary>
        [DataMapping("RESTAURANT_TEL", DbType.String)]
        public string RESTAURANT_TEL { get; set; }
        /// <summary>
        /// 餐廳傳真
        /// </summary>
        [DataMapping("RESTAURANT_FAX", DbType.String)]
        public string RESTAURANT_FAX { get; set; }
        /// <summary>
        /// 餐廳地址
        /// </summary>
        [DataMapping("RESTAURANT_ADDRESS", DbType.String)]
        public string RESTAURANT_ADDRESS { get; set; }
        /// <summary>
        /// 餐廳狀態
        /// </summary>
        [DataMapping("RESTAURANT_STATUS", DbType.String)]
        public string RESTAURANT_STATUS { get; set; }
        /// <summary>
        /// 餐廳連結參數
        /// </summary>
        [DataMapping("LINK_PARAMETER", DbType.String)]
        public string LINK_PARAMETER { get; set; }
    }
}
