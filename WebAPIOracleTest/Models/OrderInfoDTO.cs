using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIOracleTest.Models
{
    public class OrderInfoDTO
    {
        public long Id { get; set; }//序号
        public string OrderId { get; set; } //订单号
        
        public string OrderStatus { get; set; } //订单状态
        public string CompanyName { get; set; } //客户（或单位）名称
        public string ItemName { get; set; } //项目名称
       
        public DateTime? OrderTime { get; set; } //订单创建时间

        public string PaymentType { get; set; } //支付方式
        public string PaymentStatus { get; set; } //支付状态
        public DateTime? PaymentTime { get; set; } //支付时间
        public string PaymentId { get; set; } //支付流水号
        public decimal Fee { get; set; } //金额

        public string ShippingType { get; set; } //邮寄类型
        public string ShippingStatus { get; set; } //邮寄状态
        public DateTime? ShippingTime { get; set; } //邮寄时间
        public string ShippingAddress { get; set; } //邮寄地址
        public string ShippingSN { get; set; }//快递单号
        public string ShippingName { get; set; }//收件人
        public string ShippingPhone { get; set; }//收件人电话
        public string ShippingCode { get; set; }//邮编
        //public string DownloadCode { get; set; }//下载码
        public string Misc { get; set; }//备注


    }
}