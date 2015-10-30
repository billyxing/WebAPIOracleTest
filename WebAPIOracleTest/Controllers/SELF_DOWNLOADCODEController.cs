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
using WebAPIOracleTest.Models;

namespace WebAPIOracleTest.Controllers
{
    [RoutePrefix("api/downcode")]
    public class SELF_DOWNLOADCODEController : ApiController
    {
        private SelfDbEntities db = new SelfDbEntities();

       

        // GET: api/SELF_DOWNLOADCODE/5
        [Route("{id:int}")]
        [ResponseType(typeof(SELF_DOWNLOADCODE))]
        public async Task<IHttpActionResult> GetSELF_DOWNLOADCODEByOrderId(long id)
        {
            SELF_DOWNLOADCODE sELF_DOWNLOADCODE = await db.SELF_DOWNLOADCODE.FindAsync(id);
            if (sELF_DOWNLOADCODE == null)
            {
                return NotFound();
            }

            return Ok(sELF_DOWNLOADCODE);
        }

        // PUT: api/SELF_DOWNLOADCODE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSELF_DOWNLOADCODE(long id, SELF_DOWNLOADCODE sELF_DOWNLOADCODE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sELF_DOWNLOADCODE.ID)
            {
                return BadRequest();
            }

            db.Entry(sELF_DOWNLOADCODE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SELF_DOWNLOADCODEExists(id))
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
        // POST: api/SELF_DOWNLOADCODE
        [ResponseType(typeof(SELF_DOWNLOADCODE))]
        public async Task<IHttpActionResult> PostSELF_DOWNLOADCODE(SELF_DOWNLOADCODE sELF_DOWNLOADCODE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SELF_DOWNLOADCODE.Add(sELF_DOWNLOADCODE);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SELF_DOWNLOADCODEExists(sELF_DOWNLOADCODE.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sELF_DOWNLOADCODE.ID }, sELF_DOWNLOADCODE);
        }

        // DELETE: api/SELF_DOWNLOADCODE/5
        [ResponseType(typeof(SELF_DOWNLOADCODE))]
        public async Task<IHttpActionResult> DeleteSELF_DOWNLOADCODE(long id)
        {
            SELF_DOWNLOADCODE sELF_DOWNLOADCODE = await db.SELF_DOWNLOADCODE.FindAsync(id);
            if (sELF_DOWNLOADCODE == null)
            {
                return NotFound();
            }

            db.SELF_DOWNLOADCODE.Remove(sELF_DOWNLOADCODE);
            await db.SaveChangesAsync();

            return Ok(sELF_DOWNLOADCODE);
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

        private bool SELF_DOWNLOADCODEExists(long id)
        {
            return db.SELF_DOWNLOADCODE.Count(e => e.ID == id) > 0;
        }
    }
}