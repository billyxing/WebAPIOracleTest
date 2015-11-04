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
    [RoutePrefix("api/users")]
    public class SELF_USRSController : ApiController
    {
        private SelfDbEntities db = new SelfDbEntities();

        // GET: api/SELF_USRS
        [Route("{pageNum:int}/{pageSize:int}")]
        public IQueryable<SELF_USRS> GetSELF_USRSByPage(int pageNum, int pageSize)
        {
          

            try
            {

                if (pageNum < 1) pageNum = 1;
                if (pageSize < 1) pageSize = 40;

                return db.SELF_USRS.OrderByDescending(p => p.ID).Skip(pageNum * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_USRSController_GetUSRSByPage", ex);
                return null;
            }
        }

        // GET: api/SELF_USRS/5
        [Route("{id:int}")]
        [ResponseType(typeof(SELF_USRS))]
        public async Task<IHttpActionResult> GetSELF_USRS(long id)
        {
            SELF_USRS sELF_USRS = await db.SELF_USRS.FindAsync(id);
            if (sELF_USRS == null)
            {
                return NotFound();
            }

            return Ok(sELF_USRS);
        }

        // GET: api/SELF_USRS
        [Route("CN/{strcn}")]
        public IQueryable<SELF_USRS> GetSELF_USRSByCN(string cn)
        {


            try
            {

                if (string.IsNullOrEmpty(cn))
                {
                    Configuration.Services.GetTraceWriter().Error(Request, "SELF_USRSController_GetUSRSByPage", "CN项不能为空");
                    return null;
                }


                return db.SELF_USRS.Where(p => p.UNAME.Contains(cn));
            }
            catch (Exception ex)
            {
                Configuration.Services.GetTraceWriter().Error(Request, "SELF_USRSController_GetUSRSByCN", ex);
                return null;
            }
        }


        // PUT: api/SELF_USRS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSELF_USRS(long id, SELF_USRS sELF_USRS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sELF_USRS.ID)
            {
                return BadRequest();
            }

            db.Entry(sELF_USRS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SELF_USRSExists(id))
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

        /*
        // POST: api/SELF_USRS
        [ResponseType(typeof(SELF_USRS))]
        public async Task<IHttpActionResult> PostSELF_USRS(SELF_USRS sELF_USRS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SELF_USRS.Add(sELF_USRS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SELF_USRSExists(sELF_USRS.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sELF_USRS.ID }, sELF_USRS);
        }

        // DELETE: api/SELF_USRS/5
        [ResponseType(typeof(SELF_USRS))]
        public async Task<IHttpActionResult> DeleteSELF_USRS(long id)
        {
            SELF_USRS sELF_USRS = await db.SELF_USRS.FindAsync(id);
            if (sELF_USRS == null)
            {
                return NotFound();
            }

            db.SELF_USRS.Remove(sELF_USRS);
            await db.SaveChangesAsync();

            return Ok(sELF_USRS);
        }

    */


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SELF_USRSExists(long id)
        {
            return db.SELF_USRS.Count(e => e.ID == id) > 0;
        }
    }
}