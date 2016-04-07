using System.Collections.Generic;
using System;
using System.Data;
using RSL.MSP.MVC.Model.Common;

namespace RSL.MSP.MVC.Model.Base
{
    public class SearchModel<T> where T : ModelBase
    {
        public SearchModel()
        {
            this.page = 0;
            this.rows = 10;
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// 分页索引，从0开始
        /// </summary>
        public int PageIndex { get { return page; } }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get { return rows; } }
        /// <summary>
        /// 返回结果总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public T Entity { get; set; }

        public List<T> SearchKey { get; set; }
    }
}
