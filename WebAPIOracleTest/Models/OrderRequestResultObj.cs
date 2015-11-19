using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIOracleTest.Models
{
    public class OrderRequestResultObj : IResultObj<OrderInfoDTO>
    {


        private string _msg;
        private string _resultcode;
        


        public string Msg
        {
            get
            {
                return _msg;
            }

            set
            {
                _msg=value;
            }
        }

        public string ResultCode
        {
            get
            {
                return _resultcode;
            }

            set
            {
                _resultcode = value;
            }
        }

        public IEnumerable<OrderInfoDTO> Result { get; set; }

    }
}