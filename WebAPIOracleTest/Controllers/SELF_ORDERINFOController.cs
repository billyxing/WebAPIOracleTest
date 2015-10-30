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
        public IQueryable<SELF_ORDERINFO> GetSELF_ORDERINFOByPage(int pageNum,int pageSize)
        {
            try
            {
                
                if (pageNum < 1) pageNum = 1;
                if (pageSize < 1) pageSize = 40;

                return db.SELF_ORDERINFO.OrderByDescending(p => p.ORDER_DATE).Skip(pageNum * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_ORDERINFO_GetOrderByPage", ex);
                return null;
            }
        }

        //按订单号查询
        [Route("OrderId/{orderId:string}")]
        // GET: api/SELF_ORDERINFO
        [ResponseType(typeof(SELF_ORDERINFO))]
        public async Task<IHttpActionResult> GetSELF_ORDERINFO(string orderId)
        {
            SELF_ORDERINFO sELF_ORDERINFO;
            try
            {
                sELF_ORDERINFO = await db.SELF_ORDERINFO.SingleOrDefaultAsync(p => p.ORDER_ID == orderId);
            }
            catch (Exception ex)
            {
                sELF_ORDERINFO = null;
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_ORDERINFO_GetOrderByOrderId", ex);
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
        [ResponseType(typeof(SELF_ORDERINFO))]
        public async Task<IHttpActionResult> GetSELF_ORDERINFO(long id)
        {
            SELF_ORDERINFO sELF_ORDERINFO = await db.SELF_ORDERINFO.FindAsync(id);
            if (sELF_ORDERINFO == null)
            {
                return NotFound();
            }

            return Ok(sELF_ORDERINFO);
        }

        //更新订单信息
        // PUT: api/SELF_ORDERINFO/5
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSELF_ORDERINFO(long id, SELF_ORDERINFO sELF_ORDERINFO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sELF_ORDERINFO.ID)
            {
                return BadRequest();
            }

            db.Entry(sELF_ORDERINFO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SELF_ORDERINFOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
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