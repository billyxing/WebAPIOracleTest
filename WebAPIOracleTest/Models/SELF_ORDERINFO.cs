//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIOracleTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SELF_ORDERINFO
    {
        public long ID { get; set; }
        public Nullable<long> ITEMID { get; set; }
        public string CERTSN { get; set; }
        public string NEWCERTSN { get; set; }
        public string ORDER_STATE { get; set; }
        public Nullable<System.DateTime> ORDER_DATE { get; set; }
        public Nullable<int> PAYMENT_TYPE { get; set; }
        public string PAYMENT_STATE { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATE { get; set; }
        public string PAYMENT_ID { get; set; }
        public Nullable<decimal> FEE { get; set; }
        public Nullable<int> MAILTYPE { get; set; }
        public string MAIL_ADDRESS { get; set; }
        public string MAIL_NAME { get; set; }
        public string MAIL_TELNUM { get; set; }
        public string MAIL_STATE { get; set; }
        public Nullable<System.DateTime> MAIL_DATE { get; set; }
        public string MISC { get; set; }
        public string ORDER_ID { get; set; }
        public Nullable<long> USER_ID { get; set; }
        public string MAIL_POSTCODE { get; set; }
        public string MAIL_SN { get; set; }
    }
}
