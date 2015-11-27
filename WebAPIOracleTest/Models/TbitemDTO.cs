using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIOracleTest.Models
{
    public class TbitemDTO
    {

        public long ItemId { get; set; }//序号
        public string Item { get; set; } //项目名称

        public string ItemClient { get; set; } //客户名称
        public string Remark { get; set; } //备注
       


    }
}