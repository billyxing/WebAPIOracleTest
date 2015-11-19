using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIOracleTest.Models
{
    public interface IResultObj<T>
    {
         string ResultCode { get; set; } //返回结果代码

         string Msg { get; set; } //返回结果原因
       
        IEnumerable<T> Result{ get; set; }
        


    }
}