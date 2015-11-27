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
    [RoutePrefix("api/TBCERTs")]
    public class TBCERTsController : ApiController
    {
        private SelfDbEntities db = new SelfDbEntities();
        
        // get: api/TBCERTs
        [Route("{certsnlist}")]
        [ResponseType(typeof(TbcertDTO))]
        public IHttpActionResult GetCertPair(string certsnlist)
        {

            try
            {

                if(string.IsNullOrEmpty(certsnlist))
                {
                    return BadRequest();
                }

                string[] certs = certsnlist.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                string NewCert = "";
                string LastCert = "";
                if (certs.Length==1)
                {
                    LastCert = certs[0];
                }
                else if(certs.Length==2)
                {
                    LastCert = certs[0];
                    NewCert = certs[1];
                }
                else
                {
                    BadRequest();
                }

                var resultlist =  (from _order in db.TBCERTs
                                        where _order.SIGNSN == LastCert || _order.SIGNSN == NewCert
                                   select new TbcertDTO
                                        {
                                            Id = _order.ID,
                                            RecordId = _order.RECORDID.HasValue ? _order.RECORDID.Value : 0,
                                            CertType = _order.CERTTYPE,
                                            ItemId = _order.ITEMID.HasValue ? _order.ITEMID.Value : 0,
                                            CN = _order.CN,
                                            DN = _order.DN,
                                            StartDate = _order.STARTDATE,
                                            EndDate =_order.ENDDATE,
                                            Status = _order.STATUS,
                                            EncSN = _order.ENCSN,
                                            SignSN = _order.SIGNSN,
                                            LastCertSN = _order.LASTCERTSN,
                                            AuthorizeCode = _order.AUTHORIZECODE,
                                            CTMLName= _order.CTMLNAME
                                            
                                  });

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
                Configuration.Services.GetTraceWriter().Error(Request, "TBCERTsController_GetCertPair", ex);
                //IResultObj<OrderInfoDTO> result = new OrderRequestResultObj();
                //result.Msg = "Exception"; //异常
                //result.ResultCode = "202"; //查询失败，异常
                return BadRequest();
                //return result;
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

        private bool TBCERTExists(long id)
        {
            return db.TBCERTs.Count(e => e.ID == id) > 0;
        }
    }
}