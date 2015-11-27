using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIOracleTest.Models
{
    public class TbcertDTO
    {
        public long Id { get; set; } //cert id
        public long RecordId { get; set; }  //tbcustomer id
        public string CN { get; set; }
        public string DN { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate{ get; set; }
        public string CertType { get; set; }
        public string Status  { get; set; }
        public long ItemId { get; set; }    //tbitem id
        public string EncSN { get; set; } //加密证书sn
        public string SignSN { get; set; }  //签名证书sn
        public string AuthorizeCode { get; set; }   //授权码
        public string CTMLName { get; set; } //证书模板名称(从RA导入)
        public string LastCertSN { get; set; } //上一个证书签名证书序列号



        }
}