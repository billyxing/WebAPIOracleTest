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
    
    public partial class SELF_DOWNLOADCODE
    {
        public long ID { get; set; }
        public string DOWNLOADCODE { get; set; }
        public Nullable<long> ORDERID { get; set; }
        public string REF_CODE { get; set; }
        public string AUTH_CODE { get; set; }
        public Nullable<System.DateTime> CREATE_TIME { get; set; }
        public string STATE { get; set; }
    }
}
