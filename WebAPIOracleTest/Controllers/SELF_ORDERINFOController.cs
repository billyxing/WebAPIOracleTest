﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Tracing;
using WebAPIOracleTest.Models;

namespace WebAPIOracleTest.Controllers
{
    [RoutePrefix("api/orderinfoes")]
    public class SELF_ORDERINFOController : ApiController
    {
        private SelfDbEntities db = new SelfDbEntities();
        
        //分页查询
        [Route("{pageNum:int}/{pageSize:int}")]
        // GET: api/SELF_ORDERINFO
        [ResponseType(typeof(OrderInfoDTO))]
        public  IHttpActionResult GetSELF_ORDERINFOByPage(int pageNum,int pageSize)
        {
            try
            {
                
                if (pageNum < 0) pageNum = 0;
                if (pageSize < 1) pageSize = 40;

                var resultlist = (from _order in db.SELF_ORDERINFO
                                  join _item in db.TBITEMs on _order.ITEMID equals _item.ITEMID
                                  join _user in db.SELF_USRS on _order.USER_ID equals _user.ID


                                  select new OrderInfoDTO
                                  {
                                      Id = _order.ID,
                                      OrderId = _order.ORDER_ID,
                                      OrderStatus = _order.ORDER_STATE,
                                      OrderTime = _order.ORDER_DATE,
                                      CertSN = _order.CERTSN,
                                      NewCertSN = _order.NEWCERTSN,
                                      CompanyName = _user.UNAME,
                                      ItemName = _item.ITEM,
                                      Itemid = _order.ITEMID.HasValue ? _order.ITEMID.Value : 0,
                                      PaymentType = _order.PAYMENT_TYPE.HasValue?_order.PAYMENT_TYPE.Value:0,
                                      PaymentStatus = _order.PAYMENT_STATE,
                                      PaymentTime = _order.PAYMENT_DATE,
                                      PaymentId = _order.PAYMENT_ID,
                                      Fee = _order.FEE.HasValue ? _order.FEE.Value : 0,
                                      ShippingName = _order.MAIL_NAME,
                                      ShippingStatus = _order.MAIL_STATE,
                                      ShippingAddress = _order.MAIL_ADDRESS,
                                     ShippingType = _order.MAILTYPE.HasValue ? _order.MAILTYPE.Value : 0,
                                      ShippingTime = _order.MAIL_DATE,
                                      ShippingSN = _order.MAIL_SN,
                                      ShippingPhone = _order.MAIL_TELNUM,
                                      ShippingCode = _order.MAIL_POSTCODE,
                                      //DownloadCode = _dcode.DOWNLOADCODE,
                                      Misc = _order.MISC
                                  }).OrderByDescending(p=>p.OrderTime).Skip(pageNum * pageSize).Take(pageSize);

               // IResultObj<OrderInfoDTO> result = new OrderRequestResultObj();
                //result.Msg = "Success";
                if (resultlist.Count() > 0)
                {
                    //result.ResultCode = "200";  //查询成功，有数据
                    // result.Result = resultlist;
                    return Ok(resultlist);
                }
                else
                {
                    //result.ResultCode = "201"; //查询成功，无数据
                    return NotFound();
                }

                //return result;

                //return db.SELF_ORDERINFO.OrderByDescending(p => p.ORDER_DATE).Skip(pageNum * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_ORDERINFO_GetOrderByPage", ex);
                //IResultObj<OrderInfoDTO> result = new OrderRequestResultObj();
                //result.Msg = "Exception"; //异常
                //result.ResultCode = "202"; //查询失败，异常
                return BadRequest();
                //return result;
            }
        }

        //按订单号查询
        [Route("OrderId/{orderId}")]
        [ResponseType(typeof(OrderInfoDTO))]
        public async Task<IHttpActionResult> GetSELF_ORDERINFO(string orderId)
        {
            OrderInfoDTO sELF_ORDERINFO;
            try
            {

                sELF_ORDERINFO = await (from _order in db.SELF_ORDERINFO
                 join _item in db.TBITEMs on _order.ITEMID equals _item.ITEMID
                 join _user in db.SELF_USRS on _order.USER_ID equals _user.ID
                 where _order.ORDER_ID == orderId
                 orderby _order.ORDER_DATE descending
                 select new OrderInfoDTO
                 {
                     Id = _order.ID,
                     OrderId = _order.ORDER_ID,
                     CertSN = _order.CERTSN,
                     NewCertSN = _order.NEWCERTSN,
                     OrderStatus = _order.ORDER_STATE,
                     OrderTime = _order.ORDER_DATE,
                     CompanyName = _user.UNAME,
                     ItemName = _item.ITEM,
                     Itemid = _order.ITEMID.HasValue ? _order.ITEMID.Value : 0,
                     PaymentType = _order.PAYMENT_TYPE.HasValue?_order.PAYMENT_TYPE.Value:(0),
                     PaymentStatus = _order.PAYMENT_STATE,
                     PaymentTime = _order.PAYMENT_DATE,
                     PaymentId = _order.PAYMENT_ID,
                     Fee = _order.FEE.HasValue ? _order.FEE.Value : 0,
                     ShippingName = _order.MAIL_NAME,
                     ShippingStatus = _order.MAIL_STATE,
                     ShippingAddress = _order.MAIL_ADDRESS,
                     ShippingType = _order.MAILTYPE.HasValue?_order.PAYMENT_TYPE.Value:(0),
                     ShippingTime = _order.MAIL_DATE,
                     ShippingSN = _order.MAIL_SN,
                     ShippingPhone = _order.MAIL_TELNUM,
                     ShippingCode = _order.MAIL_POSTCODE,
                     
                     Misc = _order.MISC
                 }).SingleOrDefaultAsync();
                
               // sELF_ORDERINFO = await db.SELF_ORDERINFO.SingleOrDefaultAsync(p => p.ORDER_ID == orderId);
            }
            catch (Exception ex)
            {
                //sELF_ORDERINFO = null;
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_ORDERINFO_GetOrderByOrderId", ex);
                return BadRequest();
            }

            if (sELF_ORDERINFO == null)
            {
                return NotFound();
            }

            return Ok(sELF_ORDERINFO);
        }

        //TODO:search by other condition


        //按id查询
        // GET: api/SELF_ORDERINFO/5
        [Route("{id:int}")]
        [ResponseType(typeof(OrderInfoDTO))]
        public async Task<IHttpActionResult> GetSELF_ORDERINFO(long id)
        {
            //SELF_ORDERINFO sELF_ORDERINFO = await db.SELF_ORDERINFO.FindAsync(id);

            OrderInfoDTO sELF_ORDERINFO;
            try
            {

                sELF_ORDERINFO = await (from _order in db.SELF_ORDERINFO
                                        join _item in db.TBITEMs on _order.ITEMID equals _item.ITEMID
                                        join _user in db.SELF_USRS on _order.USER_ID equals _user.ID
                                        
                                        where _order.ID == id
                                        orderby _order.ORDER_DATE descending
                                        select new OrderInfoDTO
                                        {
                                            Id = _order.ID,
                                            OrderId = _order.ORDER_ID,
                                            OrderStatus = _order.ORDER_STATE,
                                            OrderTime = _order.ORDER_DATE,
                                            CertSN = _order.CERTSN,
                                            NewCertSN = _order.NEWCERTSN,
                                            CompanyName = _user.UNAME,
                                            ItemName = _item.ITEM,
                                            Itemid = _order.ITEMID.HasValue?_order.ITEMID.Value:0,
                                            PaymentType = _order.PAYMENT_TYPE.HasValue? _order.PAYMENT_TYPE.Value:0,
                                            PaymentStatus = _order.PAYMENT_STATE,
                                            PaymentTime = _order.PAYMENT_DATE,
                                            PaymentId = _order.PAYMENT_ID,
                                            Fee = _order.FEE.HasValue ? _order.FEE.Value : 0,
                                            ShippingName = _order.MAIL_NAME,
                                            ShippingStatus = _order.MAIL_STATE,
                                            ShippingAddress = _order.MAIL_ADDRESS,
                                            ShippingType = _order.MAILTYPE.HasValue?_order.MAILTYPE.Value:0,
                                            ShippingTime = _order.MAIL_DATE,
                                            ShippingSN = _order.MAIL_SN,
                                            ShippingPhone =_order.MAIL_TELNUM,
                                            ShippingCode = _order.MAIL_POSTCODE,
                                            
                                            Misc = _order.MISC
                                        }).FirstOrDefaultAsync();

                // sELF_ORDERINFO = await db.SELF_ORDERINFO.SingleOrDefaultAsync(p => p.ORDER_ID == orderId);
            }
            catch (Exception ex)
            {
                //sELF_ORDERINFO = null;
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_ORDERINFO_GetOrderByOrderId", ex);
                return BadRequest();
            }




            if (sELF_ORDERINFO == null)
            {
                return NotFound();
            }

            return Ok(sELF_ORDERINFO);
        }

        //更新订单信息
        // POST: api/SELF_ORDERINFO/5
        [Route("Update")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostSELF_ORDERINFO([FromBody]string jsonstr )
        {
            if (!string.IsNullOrEmpty(jsonstr))
            {
                OrderInfoDTO sELF_ORDERINFODTO = JsonConvert.DeserializeObject<OrderInfoDTO>(jsonstr);
                SELF_ORDERINFO sELF_ORDERINFO = await db.SELF_ORDERINFO.FirstOrDefaultAsync(p => p.ID == sELF_ORDERINFODTO.Id);

                if (sELF_ORDERINFO == null)
                {
                    return NotFound();
                }

                sELF_ORDERINFO.MAIL_ADDRESS = sELF_ORDERINFODTO.ShippingAddress;
                sELF_ORDERINFO.MAIL_TELNUM = sELF_ORDERINFODTO.ShippingPhone;
                sELF_ORDERINFO.MAIL_SN = sELF_ORDERINFODTO.ShippingSN;
                sELF_ORDERINFO.MAIL_STATE = sELF_ORDERINFODTO.ShippingStatus;
                sELF_ORDERINFO.MAIL_DATE = sELF_ORDERINFODTO.ShippingTime;

                sELF_ORDERINFO.MISC = sELF_ORDERINFODTO.Misc;

                sELF_ORDERINFO.PAYMENT_STATE = sELF_ORDERINFODTO.PaymentStatus;
                sELF_ORDERINFO.PAYMENT_TYPE = sELF_ORDERINFODTO.PaymentType;
                sELF_ORDERINFO.PAYMENT_DATE = sELF_ORDERINFODTO.PaymentTime;
                sELF_ORDERINFO.PAYMENT_ID = sELF_ORDERINFODTO.PaymentId;

                sELF_ORDERINFO.ORDER_STATE = sELF_ORDERINFODTO.OrderStatus;




                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                db.Entry(sELF_ORDERINFO).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SELF_ORDERINFOExists(sELF_ORDERINFODTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        //throw;
                        return StatusCode(HttpStatusCode.NotModified);
                    }
                }

                return StatusCode(HttpStatusCode.OK); 
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SELF_ORDERINFOExists(long id)
        {
            return db.SELF_ORDERINFO.Count(e => e.ID == id) > 0;
        }
    }
}